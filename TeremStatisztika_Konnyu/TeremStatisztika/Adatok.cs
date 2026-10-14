using System.Globalization;

namespace TeremStatisztika;

// Az adatok beolvasása. Ezt a fájlt nem kell módosítanod.
public static class Adatok
{
    // Beolvassa a foglalasok.csv fájlt (a futtatható program mappájából).
    public static List<Foglalas> Betolt()
    {
        string ut = Path.Combine(AppContext.BaseDirectory, "foglalasok.csv");
        List<Foglalas> lista = new List<Foglalas>();

        foreach (string sor in File.ReadAllLines(ut).Skip(1))
        {
            string[] reszek = sor.Split(';');
            if (reszek.Length == 4
                && TryDatum(reszek[1], out DateOnly datum)
                && TimeOnly.TryParseExact(reszek[2], "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out TimeOnly kezdet)
                && TimeOnly.TryParseExact(reszek[3], "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out TimeOnly veg))
            {
                lista.Add(new Foglalas(reszek[0], datum, kezdet, veg));
            }
        }

        return lista;
    }

    // Szövegből dátumot készít (ÉÉÉÉ-HH-NN). Hibás szövegnél false-t ad.
    public static bool TryDatum(string szoveg, out DateOnly datum)
    {
        return DateOnly.TryParseExact(szoveg, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out datum);
    }
}
