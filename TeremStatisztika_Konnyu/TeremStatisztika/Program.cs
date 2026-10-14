using System.Globalization;

namespace TeremStatisztika;

// A parancsok feldolgozása. Ezt a fájlt nem kell módosítanod.
class Program
{
    static void Main()
    {
        Lekerdezesek lekerdezesek = new Lekerdezesek(Adatok.Betolt());

        string sor;
        while ((sor = Console.ReadLine()) != null)
        {
            string[] reszek = sor.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (reszek.Length == 0)
            {
                continue;
            }

            if (reszek[0] == "DARAB" && reszek.Length == 2)
            {
                Console.WriteLine(lekerdezesek.Darab(reszek[1]));
            }
            else if (reszek[0] == "VAN" && reszek.Length == 3 && Adatok.TryDatum(reszek[2], out DateOnly vanDatum))
            {
                Console.WriteLine(lekerdezesek.Van(reszek[1], vanDatum) ? "IGEN" : "NEM");
            }
            else if (reszek[0] == "NAPI" && reszek.Length == 2 && Adatok.TryDatum(reszek[1], out DateOnly napiDatum))
            {
                List<Foglalas> lista = lekerdezesek.Napi(napiDatum);
                if (lista.Count == 0)
                {
                    Console.WriteLine("NINCS");
                }
                foreach (Foglalas f in lista)
                {
                    Console.WriteLine(f.Terem + " " + f.Idosav());
                }
            }
            else if (reszek[0] == "PERCEK" && reszek.Length == 2)
            {
                Console.WriteLine(lekerdezesek.Percek(reszek[1]));
            }
            else if (reszek[0] == "ATLAG" && reszek.Length == 2)
            {
                double? atlag = lekerdezesek.Atlag(reszek[1]);
                Console.WriteLine(atlag == null ? "NINCS" : atlag.Value.ToString("F1", CultureInfo.InvariantCulture));
            }
            else if (reszek[0] == "LEGHOSSZABB" && reszek.Length == 2)
            {
                Foglalas f = lekerdezesek.Leghosszabb(reszek[1]);
                Console.WriteLine(f == null ? "NINCS" : f.Datum.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + " " + f.Idosav());
            }
            // Bónusz feladat: a TEREMEK parancs ide kerülhet.
            else
            {
                Console.WriteLine("HIBA formatum");
            }
        }
    }
}
