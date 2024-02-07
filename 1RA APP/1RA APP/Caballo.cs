using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraAplicacion
{
    class Caballo : Mamiferos,IMamiferosTerrestres
    {
        public Caballo  () { }

        public void Galopar() { }
        public int NumeroPatas() { return 4; }

    }
}
