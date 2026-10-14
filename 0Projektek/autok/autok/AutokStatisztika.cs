using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autok
{
    internal class AutokStatisztika
    {
        public AutokStatisztika(string fajlBe,string fajlKi)
        {
            FajlBe = fajlBe;
            FajlKi = fajlKi;
            Autok = Beolvas();
        }
        public string FajlBe {  get; set; } 
        public string FajlKi { get; set; }
        public List<Auto> Autok {  get; private set; }

        //1.feladat
        public List<Auto> Beolvas()
        {
            List<Auto> autok = new List<Auto>(2000);
            StreamReader srBe = new StreamReader(FajlBe);
            while(!srBe.EndOfStream)
            {
                string sor = srBe.ReadLine();
                if (string.IsNullOrEmpty(sor))
                    continue;
                string[] reszek = sor.Split('\t');
                Auto auto = new Auto();
                auto.Rendszam = reszek[0];
                auto.Ora = int.Parse(reszek[1]);
                auto.Perc = int.Parse(reszek[2]);
                auto.Kmh= int.Parse(reszek[3]);
                autok.Add(auto);
            }
            srBe.Close();
            return autok;
        }

        //2.feladat
        public void UtolsoJel()
        {
            var auto = Autok.MaxBy(k => k.Ido);
            Console.WriteLine($"2. feladat:\nAz utolsó jeladás időpontja {auto.Ido}, a jármű rendszáma {auto.Kmh} ");
        }

        //3.feladat
        public void AutoJelei()
        {
            var autoJelei = Autok.Where(k => k.Rendszam == Autok[0].Rendszam);
            Console.WriteLine("3. feladat:");
            Console.WriteLine($"Az első jármű: {Autok[0].Rendszam}");
            Console.Write($"Jeladásainak időpontjai: ");
            foreach (var auto in autoJelei)
            {
                Console.Write($"{auto.Ora}:{auto.Perc} ");
            }
        }

        //4.feladat
        public int AdottIdoJeleinekSzama()
        {
            int ora;
            do
            {
                Console.Write("\nKérem, adja meg az órát: ");
                _ = int.TryParse(Console.ReadLine(), out ora);
                if (ora <6 || ora>22)
                    Console.WriteLine("6 orától 22:45 ig mernek");
            } while (ora<6 || ora>22);
            int perc;
            do
            {
                Console.Write("\nKérem, adja meg a percet: ");
                _ = int.TryParse(Console.ReadLine(), out perc);
                if (perc < 0 || perc > 59)
                    Console.WriteLine("percet 0-59 ig mernek");
            } while (perc < 0 || perc > 59);
            return Autok.Count(i=>i.Ido==new TimeOnly(ora,perc));
        }

        //5.feladat
        public void LegGyorsabb()
        {
            var leggyorsabb = Autok.MaxBy(i=>i.Kmh);
            var gyorsLista= Autok.Where(g => g.Kmh == leggyorsabb.Kmh).ToList();
            Console.WriteLine($"A legnagyobb sebesség km/h: {leggyorsabb.Kmh}");
            if (gyorsLista.Count > 0)
            {
                Console.Write("A járművek:");
                foreach (var g in gyorsLista) { Console.Write($" {g.Rendszam}");}
            }
        }

        //6.feladat
        public void KeresettAutoAdatai()
        {
            Console.WriteLine("Kérem, adja meg a rendszámot: ");
            string keresettauto = Console.ReadLine();

            var autoAdatai = Autok.Where(k => k.Rendszam == keresettauto);

        }

        //7.feladat
        public void Kiiras()
        {
            StreamWriter swKi = new StreamWriter(FajlKi);
            List<(string, TimeOnly, TimeOnly)> AutokEUJ = new List<(string, TimeOnly, TimeOnly)>(200);
            foreach(var a in Autok)
            {
                var ker = Autok.Where(k=>k.Rendszam == a.Rendszam).ToList();
                AutokEUJ.Add((a.Rendszam, ker.First().Ido, ker.Last().Ido));
            }
            foreach (var a in AutokEUJ)
            {
                swKi.WriteLine($"{a.Item1} {a.Item2} {a.Item3}");
            }
        }
    }
}
