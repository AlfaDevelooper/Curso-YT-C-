using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ControlEmpresaEmpleado buscaempleado = new ControlEmpresaEmpleado();

            buscaempleado.getOperador();
            Console.WriteLine();
            buscaempleado.getEmpleadosOrdenados();
            Console.WriteLine();

            Console.WriteLine("ingresa id de empleado a buscar");

            string entrada = Console.ReadLine();
            int entradaID = int.Parse(entrada);

            buscaempleado.getEmpleadosEmpresa(entradaID);


            Console.ReadLine();
        }
    }

    class ControlEmpresaEmpleado
    {
        public ControlEmpresaEmpleado() 
        {
            listaEmpresa = new List<Empresa>(); 
            listaEmpleado= new List<Empleado>();

            listaEmpresa.Add(new Empresa { Id = 1, Nombre="Guaymallen" });
            listaEmpresa.Add(new Empresa { Id = 2, Nombre = "Jorgito" });

            listaEmpleado.Add(new Empleado { Id = 1, Nombre = "Juan Manuel", Cargo = "Director", EmpresaId = 1, Salario = 150000 });
            listaEmpleado.Add(new Empleado { Id = 2, Nombre = "Carlos Mendoza", Cargo = "Supervisor", EmpresaId = 1, Salario = 300000 });
            listaEmpleado.Add(new Empleado { Id = 3, Nombre = "Ariel Perri", Cargo = "Operador", EmpresaId = 2, Salario = 160000 });
            listaEmpleado.Add(new Empleado { Id = 4, Nombre = "Carla Regner", Cargo = "Operador", EmpresaId = 2, Salario = 180000 });
        }

        public void getOperador()
        {
            IEnumerable<Empleado> operadores = from empleado in listaEmpleado where empleado.Cargo == "Operador" select empleado;

            foreach (Empleado operador in operadores)
            {
                operador.getDatosEmpleado();
            }
        }

        public void getEmpleadosOrdenados() 
        {
            IEnumerable<Empleado> empeladosOrdenados = from empleado in listaEmpleado orderby empleado.Nombre select empleado;
            
            foreach(Empleado empleadoOrdenado in empeladosOrdenados)
            {
                empleadoOrdenado.getDatosEmpleado();
            }

        }

        public void getEmpleadosEmpresa(int id)
        {
            IEnumerable<Empleado> empleados = from empleado in listaEmpleado join
                                              Empresa in listaEmpresa on empleado.EmpresaId equals Empresa.Id
                                              where Empresa.Id==id select empleado;

            foreach (Empleado empleadoEmpresa in empleados)
            {
                empleadoEmpresa.getDatosEmpleado();
            }

        }



        public List<Empresa> listaEmpresa;
        public List<Empleado> listaEmpleado;
    }

   

    class Empresa
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public void getDatosEmpresa() 
        {
            Console.WriteLine("Empresa {0} con {1} ", Nombre, Id);
        }


    }
    class Empleado
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Cargo { get; set; }

        public double Salario { get; set; }

        public int EmpresaId { get; set; }

        public void getDatosEmpleado()
        {
            Console.WriteLine("Empleado: {0} Cargo: {1} de la empresa: {2} gana {3} ", Nombre, Cargo,EmpresaId,Salario);
        }


    }

}
