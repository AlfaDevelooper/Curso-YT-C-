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
using System.Configuration;
using System.Windows.Markup;
using System.Data.SqlClient;

namespace WpfApp2
{
    
    public partial class MainWindow : Window
    {
        DataClasses1DataContext dataContext;
        public MainWindow()
        {
            InitializeComponent();

            string conexionBBDD = ConfigurationManager.ConnectionStrings["WpfApp2.Properties.Settings.BaseDatosPruebaConnectionString"].ConnectionString;
            
            dataContext = new DataClasses1DataContext(conexionBBDD);

            //InsertaEmpresa();

            //InsertaEmpleado();

            //InsertaCargo();

            //InsertaEmpleadoCargo();

            UpdateEmpleado();

            EraseEmpleado();

        }

        public void InsertaEmpresa()
        {
            dataContext.ExecuteCommand("DELETE FROM Empresa");

            Empresa LuckyStrike = new Empresa();
            LuckyStrike.nombre = "Lucky Strike";
            dataContext.Empresa.InsertOnSubmit(LuckyStrike);

            Empresa Malboro = new Empresa();
            Malboro.nombre = "Malboro";
            dataContext.Empresa.InsertOnSubmit(Malboro);

            dataContext.SubmitChanges();

            Principal.ItemsSource = dataContext.Empresa;
        }

        public void InsertaEmpleado()
        {
            dataContext.ExecuteCommand("DELETE FROM Empleado");


            Empresa LuckyStrike = dataContext.Empresa.First(em => em.nombre.Equals("Lucky Strike"));
            Empresa Malboro = dataContext.Empresa.First(em => em.nombre.Equals("Malboro"));

            List<Empleado> listaEmpleado = new List<Empleado>();

            listaEmpleado.Add(new Empleado {nombre="Juan", apellido="Tapia", empresaId= LuckyStrike.Id });
            listaEmpleado.Add(new Empleado { nombre = "Jose", apellido = "Fernandez", empresaId = LuckyStrike.Id });

            listaEmpleado.Add(new Empleado { nombre = "Ana", apellido = "Coria", empresaId = Malboro.Id });
            listaEmpleado.Add(new Empleado { nombre = "Maria", apellido = "Rigaudi", empresaId = Malboro.Id });

            dataContext.Empleado.InsertAllOnSubmit(listaEmpleado);
            
            dataContext.SubmitChanges();

            Principal.ItemsSource = dataContext.Empleado;

        }

        public void InsertaCargo()
        {
            dataContext.ExecuteCommand("DELETE FROM Cargo");


            dataContext.Cargo.InsertOnSubmit(new Cargo {nombreCargo="Director" });
            dataContext.Cargo.InsertOnSubmit(new Cargo { nombreCargo = "Administrativo" });

            dataContext.SubmitChanges();

            Principal.ItemsSource = dataContext.Cargo;
        }

        public void InsertaEmpleadoCargo()
        {
            dataContext.ExecuteCommand("DELETE FROM CargoEmpleado");

            Empleado Juan = dataContext.Empleado.First(em => em.nombre.Equals("Juan"));
            Empleado Ana = dataContext.Empleado.First(em => em.nombre.Equals("Ana"));

            Cargo cDirector = dataContext.Cargo.First(cg => cg.nombreCargo.Equals("Director"));
            Cargo cAdministrativo = dataContext.Cargo.First(cg => cg.nombreCargo.Equals("Administrativo"));

            CargoEmpleado cargoJuan = new CargoEmpleado();
            cargoJuan.Empleado = Juan;
            cargoJuan.cargoId = cDirector.Id;

            CargoEmpleado cargoAna = new CargoEmpleado();
            cargoAna.Empleado = Ana;
            cargoAna.cargoId = cAdministrativo.Id;

           
            dataContext.SubmitChanges();

            Principal.ItemsSource = dataContext.CargoEmpleado;

        }

        public void UpdateEmpleado()
        {
            Empleado maria = dataContext.Empleado.First(em => em.nombre.Equals("Maria"));
            maria.nombre = "Maria Antonia";

            dataContext.SubmitChanges();

        }

        public void EraseEmpleado()
        {
            Empleado juan = dataContext.Empleado.First(em => em.nombre.Equals("Juan"));

            dataContext.Empleado.DeleteOnSubmit(juan);

            dataContext.SubmitChanges();

        }

    }
}
