using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceGyakorlas
{
    class Bicikli : IJarmu
    {
        public void Indit()
        {
            Console.WriteLine("A bicikli gurulni kezd");
        }

        public void Megall()
        {
            Console.WriteLine("A bicikli megállt");
        }
    }
}
