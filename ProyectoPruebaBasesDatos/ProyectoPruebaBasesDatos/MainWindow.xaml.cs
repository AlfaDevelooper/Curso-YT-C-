using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoPruebaBasesDatos
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string conexionBBDD = ConfigurationManager.ConnectionStrings["ProyectoPruebaBasesDatos.Properties.Settings.BaseDatosPruebaConnectionString"].ConnectionString;
            
            miConexionSql=new SqlConnection(conexionBBDD);

            MuestraCliente();

            MuestraGeneralPedidos();
        }

        private SqlConnection miConexionSql;

        private void MuestraCliente()
        {
            try
            {
                string consulta = "SELECT * FROM CLIENTE";

                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

                using (miAdaptadorSql)
                {
                    DataTable clientesTabla = new DataTable();
                    miAdaptadorSql.Fill(clientesTabla);
                    listaClientes.DisplayMemberPath = "nombre";
                    listaClientes.SelectedValuePath = "Id";
                    listaClientes.ItemsSource = clientesTabla.DefaultView;

                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void MuestraPedidos()
        {
            try
            {
                string consulta = "SELECT * FROM PEDIDO P INNER JOIN CLIENTE C ON C.ID=P.cCliente WHERE C.ID=@ClienteId";

                SqlCommand sqlComando = new SqlCommand(consulta, miConexionSql);

                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(sqlComando);


                using (miAdaptadorSql)
                {
                    sqlComando.Parameters.AddWithValue("@ClienteId", listaClientes.SelectedValue);
                    DataTable pedidosTabla = new DataTable();
                    miAdaptadorSql.Fill(pedidosTabla);

                    listaPedidos.DisplayMemberPath = "fechaPedido";
                    listaPedidos.SelectedValuePath = "Id";
                    listaPedidos.ItemsSource = pedidosTabla.DefaultView;

                }
            }
            catch(Exception e) 
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void MuestraGeneralPedidos()
        {
            try
            {
                string consulta = "SELECT * , CONCAT (cCliente, '  ', fechaPedido, '  ', formaPago) AS INFOCOMPLETA FROM PEDIDO";

                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);


                using (miAdaptadorSql)
                {

                    DataTable pedidosGeneralTabla = new DataTable();
                    miAdaptadorSql.Fill(pedidosGeneralTabla);

                    listaGeneralPedidos.DisplayMemberPath = "INFOCOMPLETA";
                    listaGeneralPedidos.SelectedValuePath = "Id";
                    listaGeneralPedidos.ItemsSource = pedidosGeneralTabla.DefaultView;

                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void listaClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MuestraPedidos();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string consulta = "DELETE FROM PEDIDO WHERE ID=@PEDIDOID";

            SqlCommand sqlcommand = new SqlCommand(consulta, miConexionSql);

            miConexionSql.Open();

            sqlcommand.Parameters.AddWithValue("@PEDIDOID", listaGeneralPedidos.SelectedValue);

            sqlcommand.ExecuteNonQuery();

            miConexionSql.Close();

            MuestraGeneralPedidos();
        }

        private void Button_Add_Client(object sender, RoutedEventArgs e)
        {
            string consulta = "INSERT INTO CLIENTE (nombre) VALUES (@nombre)";

            SqlCommand sqlcommand = new SqlCommand(consulta, miConexionSql);

            miConexionSql.Open();

            sqlcommand.Parameters.AddWithValue("@nombre", instertaCliente.Text);

            sqlcommand.ExecuteNonQuery();

            miConexionSql.Close();

            instertaCliente.Text = "";

            MuestraCliente();
        }

        private void Button_Delete_Client(object sender, RoutedEventArgs e)
        {
            string consulta = "DELETE FROM CLIENTE WHERE ID=@CLIENTEID";

            SqlCommand sqlcommand = new SqlCommand(consulta, miConexionSql);

            miConexionSql.Open();

            sqlcommand.Parameters.AddWithValue("@CLIENTEID", listaClientes.SelectedValue);

            sqlcommand.ExecuteNonQuery();

            miConexionSql.Close();

            MuestraCliente();
        }


        private void actualizar_Click(object sender, RoutedEventArgs e)
        {
            Actualizar ventanaActualizar = new Actualizar((int)listaClientes.SelectedValue);

            ventanaActualizar.Show();

            try
            {
                string consulta = "SELECT nombre FROM CLIENTE WHERE ID=@CLIENTEID";
                SqlCommand sqlCommand = new SqlCommand(consulta, miConexionSql);
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(sqlCommand);

                using (miAdaptadorSql)
                {
                    sqlCommand.Parameters.AddWithValue("@CLIENTEID", listaClientes.SelectedValue);
                    DataTable clientesTabla = new DataTable();
                    miAdaptadorSql.Fill(clientesTabla);
                    ventanaActualizar.actualizaNombreCliente.Text= clientesTabla.Rows[0]["nombre"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(e.ToString());
            }

            try
            {
                string consulta = "SELECT direccion FROM CLIENTE WHERE ID=@CLIENTEID";
                SqlCommand sqlCommand = new SqlCommand(consulta, miConexionSql);
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(sqlCommand);

                using (miAdaptadorSql)
                {
                    sqlCommand.Parameters.AddWithValue("@CLIENTEID", listaClientes.SelectedValue);
                    DataTable clientesTabla = new DataTable();
                    miAdaptadorSql.Fill(clientesTabla);
                    ventanaActualizar.actualizaDireccionCliente.Text = clientesTabla.Rows[0]["direccion"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(e.ToString());
            }

            try
            {
                string consulta = "SELECT poblacion FROM CLIENTE WHERE ID=@POBLACIONID";
                SqlCommand sqlCommand = new SqlCommand(consulta, miConexionSql);
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(sqlCommand);

                using (miAdaptadorSql)
                {
                    sqlCommand.Parameters.AddWithValue("@POBLACIONID", listaClientes.SelectedValue);
                    DataTable clientesTabla = new DataTable();
                    miAdaptadorSql.Fill(clientesTabla);
                    ventanaActualizar.actualizaPoblacionCliente.Text = clientesTabla.Rows[0]["poblacion"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(e.ToString());
            }

            try
            {
                string consulta = "SELECT telefono FROM CLIENTE WHERE ID=@TELEFONOID";
                SqlCommand sqlCommand = new SqlCommand(consulta, miConexionSql);
                SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(sqlCommand);

                using (miAdaptadorSql)
                {
                    sqlCommand.Parameters.AddWithValue("@TELEFONOID", listaClientes.SelectedValue);
                    DataTable clientesTabla = new DataTable();
                    miAdaptadorSql.Fill(clientesTabla);
                    ventanaActualizar.actualizaTelefonoCliente.Text = clientesTabla.Rows[0]["telefono"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(e.ToString());
            }

            

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            MuestraCliente();
        }
    }
}
