using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeremStatisztika
{
    internal class Foglalas
    {
        public string Terem {  get; set; }
        public DateOnly Datum {  get; set; }
        public TimeOnly Kezdet { get; set; }
        public TimeOnly Veg { get; set; }
    }
}
