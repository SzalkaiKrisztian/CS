using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teglalap
{
    class Teglalap
    {
        public double Szelesseg {  get; set; }
        public double Magassag{ get; set; }

        public Teglalap(double szelesseg, double magassag)
        {
            Szelesseg = szelesseg;
            Magassag = magassag;
        }
        public Teglalap(double oldal)
        {
            Szelesseg = oldal;
            Magassag = oldal;
        }

        public double Kerulet() 
        { 
            return (Szelesseg+Magassag)*2;
        }
        public static double Kerulet(double a, double b)
        {
            return (a+b)* 2;
        }
        public double Kerulet(double oldal)
        {
            return oldal * 4;
        }
        public double Terulet()
        {
            return Szelesseg * Magassag;
        }
    }
}
