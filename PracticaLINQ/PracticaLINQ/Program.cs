using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] valoresNumericos = new int[] {1,2,3,4,5,6,7,8,9};


            

            IEnumerable<int> listaNumerosPares  = from numero in valoresNumericos where  numero % 2 == 0 select numero;

            foreach(int i in listaNumerosPares)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
