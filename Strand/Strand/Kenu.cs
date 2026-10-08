using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strand
{
    internal class Kenu : Cikk
    {
        public int Tomeg {  get; set; }
        public enum KenuFajta { Verseny, Tura }
        public KenuFajta Fajta { get; set; }
    }
}
