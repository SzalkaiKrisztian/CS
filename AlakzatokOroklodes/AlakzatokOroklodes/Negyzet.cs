using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlakzatokOroklodes
{
    class Negyzet : Alakzat
    {
        public double OLdal {  get; set; }

        public override double Terulet()
        {
            return OLdal*OLdal;
        }
    }
}
