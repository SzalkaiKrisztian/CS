using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autok
{
    class Auto
    {
        public  string Rendszam {  get; set; }
        public int Ora { get; set; }
        public int Perc {  get; set; }
        public int Kmh {  get; set; }
        public TimeOnly Ido { get => new TimeOnly(Ora, Perc); }
    }
}
