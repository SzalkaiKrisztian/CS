using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strand
{
    abstract class Cikk
    {
        private string vK;
        public string VonalKod { get; set; } //{get{ return this.vK; }set{if(vK.Length == 31)this.vK = value;}}
        public bool Kolcson { get; set; }
    }
}
