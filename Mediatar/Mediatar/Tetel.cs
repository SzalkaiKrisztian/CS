using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatar
{
    abstract class Tetel
    {
        private int _leltariSzam;
        private string _cim;
        private int _kiadasEve;

        public int LeltariSzam { get { return _leltariSzam; } set { _leltariSzam = value + 1000; } }
        public string Cim { get { return _cim; } set { if (!string.IsNullOrWhiteSpace(value)) { _cim = value; } } }
        public int KiadasEve { get { return _kiadasEve; } set { if (value >= 1450) { _kiadasEve = value; } } }
    }
}
