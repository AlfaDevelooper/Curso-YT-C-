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
    
    public partial class Actualizar : Window 
    {
        private SqlConnection miConexionSql;
        private int z;
        
        public Actualizar(int IDCLIENTE)
        {
            InitializeComponent();

            z = IDCLIENTE;

            string conexionBBDD = ConfigurationManager.ConnectionStrings["ProyectoPruebaBasesDatos.Properties.Settings.BaseDatosPruebaConnectionString"].ConnectionString;

            miConexionSql = new SqlConnection(conexionBBDD);

           

        }

        private void actualizarDatosCliente_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "UPDATE Cliente SET nombre=@NOMBRENUEVO , direccion=@DIRECCIONNUEVO , poblacion=@POBLACIONNUEVO , telefono=@TELEFONONUEVO WHERE ID=" + z;

            SqlCommand sqlCommand = new SqlCommand(consulta , miConexionSql);

            miConexionSql.Open();

            sqlCommand.Parameters.AddWithValue("@NOMBRENUEVO", actualizaNombreCliente.Text);
            sqlCommand.Parameters.AddWithValue("@DIRECCIONNUEVO", actualizaDireccionCliente.Text);
            sqlCommand.Parameters.AddWithValue("@POBLACIONNUEVO", actualizaPoblacionCliente.Text);
            sqlCommand.Parameters.AddWithValue("@TELEFONONUEVO", actualizaTelefonoCliente.Text);

            sqlCommand.ExecuteNonQuery();

            miConexionSql.Close();

            this.Close();
            
            MessageBox.Show("ACTUALIZACION EXITOSA");

            
        }
    }
}
