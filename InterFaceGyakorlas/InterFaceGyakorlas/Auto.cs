using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceGyakorlas
{
    class Auto : IJarmu
    {
        public void Indit()
        {
            Console.WriteLine("Az autó motorja beindult");
        }

        public void Megall()
        {
            Console.WriteLine("Az autó megállt");
        }
    }
}
