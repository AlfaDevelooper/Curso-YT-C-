using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraAplicacion
{
    class Gorila : Mamiferos,IMamiferosTerrestres
    {
        public Gorila() { } 

        public void trepar() { }
        public int NumeroPatas() { return 2; }
    }
}
