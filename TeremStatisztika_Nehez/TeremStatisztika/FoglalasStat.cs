using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeremStatisztika
{
    class FoglalasStat
    {
        public FoglalasStat()
        {
            Foglalasok = Beolvas();
        }
        public List<Foglalas> Foglalasok { get; private set; }

        public List<Foglalas> Beolvas()
        {
            List<Foglalas> foglalasok = new List<Foglalas>(50);
            StreamReader srBe = new StreamReader(Path.Combine(AppContext.BaseDirectory, "foglalasok.csv"));
            srBe.ReadLine();
            while (!srBe.EndOfStream)
            {
                string sor = srBe.ReadLine();
                if (string.IsNullOrWhiteSpace(sor))
                    continue;
                string[] reszek = sor.Split(';');
                Foglalas foglalas = new Foglalas();
                foglalas.Terem = reszek[0];
                foglalas.Datum = DateOnly.Parse(reszek[1]);
                foglalas.Kezdet = TimeOnly.Parse(reszek[2]);
                foglalas.Veg = TimeOnly.Parse(reszek[3]);
                foglalasok.Add(foglalas);
            }
            srBe.Close();
            return foglalasok;
        }
        public void Darab(string terem)
        {
            Console.WriteLine($"a terem foglalásainak száma {Foglalasok.Count(c=>c.Terem==terem)}");
        }
        public void Van(string terem,DateOnly datum)
        {
            Foglalasok.Any(a=>a.Terem==terem && a.Datum = datum) ? Console.WriteLine("Igen") : Console.WriteLine("nem"); ;
        }
    }
}
