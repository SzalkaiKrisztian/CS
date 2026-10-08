using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOroklodes
{
    class Jarmu
    {
        public int Sebesseg { get; set; }

        public void Halad()
        {
            Console.WriteLine($"A Jármű {Sebesseg} km/orával Halad!");
        }
    }
}
