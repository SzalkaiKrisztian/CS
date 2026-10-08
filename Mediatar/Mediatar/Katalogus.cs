using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatar
{
    class Katalogus
    {
        public Katalogus(string srbe)
        {
            srBe = srbe;
            Tetelek = Feltolt();
        }
        public string srBe {  get; set; }
        public List<Tetel> Tetelek {  get; private set; }
        public List<Tetel> Feltolt()
        {
            List<Tetel> tetelek = new List<Tetel>();
            StreamReader fajl = new StreamReader(srBe);
            //fejlec
            fajl.ReadLine();
            //fajlbeolv:
            while (!fajl.EndOfStream)
            {
                //ha fura a sor
                string sor = fajl.ReadLine();
                if (string.IsNullOrWhiteSpace(sor))
                    continue;
                string[] sorReszei = sor.Split(',');
                if (string.IsNullOrWhiteSpace(sorReszei[2]))
                    continue;
                if (int.Parse(sorReszei[4])<=1450)
                    continue;

                //teteltol fugg:
                if (sorReszei[1] == "Könyv")
                {
                    Konyv konyv = new Konyv();
                    konyv.LeltariSzam = int.Parse(sorReszei[0]);
                    konyv.Cim = sorReszei[2];
                    konyv.KiadasEve = int.Parse(sorReszei[4]);
                    konyv.Szerzo = sorReszei[3];
                    konyv.oldalSzam = int.Parse(sorReszei[5]);
                    tetelek.Add(konyv);
                }
                else if(sorReszei[1] == "DVD")
                {
                    DVD dvd = new DVD();
                    dvd.LeltariSzam= int.Parse(sorReszei[0]);
                    dvd.Cim = sorReszei[2];
                    dvd.KiadasEve = int.Parse(sorReszei[4]);
                    dvd.Rendezo = sorReszei[3];
                    dvd.JatekIdo= int.Parse(sorReszei[5]);
                    tetelek.Add(dvd);
                }
                else//folyoirat
                {
                    FolyoIrat folyoIrat = new FolyoIrat();
                    folyoIrat.LeltariSzam= int.Parse(sorReszei[0]);
                    folyoIrat.Cim = sorReszei[2];
                    folyoIrat.KiadasEve= int.Parse(sorReszei[4]);
                    folyoIrat.Lapszam = sorReszei[5];
                    tetelek.Add(folyoIrat);
                }
            }
            fajl.Close();

            return tetelek;
        }

        public void ListaKiiratas()
        {
            for (int i = 0; i < Tetelek.Count; i++)
            {
                if (Tetelek[i] is Konyv)
                {
                    Console.WriteLine($"{Tetelek[i].LeltariSzam} {Tetelek[i].Cim} – {(Tetelek[i] as Konyv).Szerzo} ({(Tetelek[i] as Konyv).oldalSzam} oldal), {Tetelek[i].KiadasEve}");
                }
                else if (Tetelek[i] is FolyoIrat)
                {
                    Console.WriteLine($"{Tetelek[i].LeltariSzam} {Tetelek[i].Cim} {(Tetelek[i] as FolyoIrat).Lapszam}, {Tetelek[i].KiadasEve}");
                }
                else
                {
                    Console.WriteLine($"{Tetelek[i].LeltariSzam} {Tetelek[i].Cim} – {(Tetelek[i] as DVD).Rendezo} ({(Tetelek[i] as DVD).JatekIdo} perc), {Tetelek[i].KiadasEve}");
                }
            }
        }

        //2.sprint

    }
}
