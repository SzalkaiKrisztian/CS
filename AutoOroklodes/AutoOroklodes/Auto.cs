using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOroklodes
{
    class Auto : Jarmu
    {
        public int Uzemanyag { get; set; }

        public void Tankol()
        {
            Console.WriteLine($"Az auto {Uzemanyag} liter uzemanyagot Tankolt!");
        }
    }
}
