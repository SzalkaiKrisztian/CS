using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strand
{
    class Kolcsonzesek
    {
        public Kolcsonzesek()
        {
            List<Cikk> cikkek = new List<Cikk>(50);
            Random random = new Random();

            for (int i = 0; i < 50; i++)
            {
                int KvV = random.Next(0, 2);
                if (KvV % 2 == 0)
                {
                    Kenu kenu = new Kenu();
                    kenu.Tomeg = random.Next(10, 31);
                    if (i % 2 == 0)
                        kenu.Fajta = Kenu.KenuFajta.Verseny;
                    else
                        kenu.Fajta = Kenu.KenuFajta.Tura;
                    kenu.Kolcson = true;
                    string vK = "";
                    for (int j = 0; j < 31; j++)
                    {
                        vK += random.Next(0, 10).ToString();
                    }
                    kenu.VonalKod = vK;
                    cikkek.Add(kenu);
                }
                else
                {
                    Vizibicikli vizibicikli = new Vizibicikli();
                    vizibicikli.Szemelyek = random.Next(1, 6);
                    vizibicikli.Kolcson = true;
                    string vK = "";
                    for (int j = 0; j < 31; j++)
                    {
                        vK += random.Next(0, 10).ToString();
                    }
                    vizibicikli.VonalKod = vK;
                    cikkek.Add(vizibicikli);
                }
                Cikkek = cikkek;
            }
        }
        public List<Cikk> Cikkek { get; private set; }
        
    }
}
