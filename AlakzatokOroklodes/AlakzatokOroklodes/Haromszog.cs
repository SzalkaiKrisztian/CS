using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlakzatokOroklodes
{
    class Haromszog : Alakzat
    {
        public double Alap {  get; set; }
        public double Magassag {  get; set; }

        public override double Terulet()
        {
            return (Alap*Magassag)/2;
        }
    }
}
