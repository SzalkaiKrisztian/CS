using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatar
{
    class Tag
    {
        public enum enumK { Diak, Felnott, Nyugdijas }
        //priv
        private string _nev;
        private int _tagsagiSzam;
        //private List<Tetel> _kolcson;
        //public
        public string Nev { get { return _nev; } set { if (!string.IsNullOrWhiteSpace(value)) { _nev = value; } } }
        public int TagsagiSzam { get { return _tagsagiSzam; } set { _tagsagiSzam = value + 2000; } }
        public enumK Kedvezmeny { get; set; }
        public List<Tetel> Kolcsonzott { get; set; }
    }
}
