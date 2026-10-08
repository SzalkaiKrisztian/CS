using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlakzatokOroklodes
{
    class Kor : Alakzat
    {
        public double Sugar {  get; set; }


        public override double Terulet()
        {
            return Sugar*Sugar*Math.PI;
        }
    }
}
