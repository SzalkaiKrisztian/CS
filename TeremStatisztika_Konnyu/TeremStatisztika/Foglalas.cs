using System.Globalization;

namespace TeremStatisztika;

public class Foglalas
{
    public string Terem { get; }
    public DateOnly Datum { get; }
    public TimeOnly Kezdet { get; }
    public TimeOnly Veg { get; }

    public TimeSpan Hossz => Veg - Kezdet;

    public Foglalas(string terem, DateOnly datum, TimeOnly kezdet, TimeOnly veg)
    {
        Terem = terem;
        Datum = datum;
        Kezdet = kezdet;
        Veg = veg;
    }

    // Az idősáv szövege, pl. "08:00-09:30".
    public string Idosav()
    {
        return Kezdet.ToString("HH:mm", CultureInfo.InvariantCulture) + "-" + Veg.ToString("HH:mm", CultureInfo.InvariantCulture);
    }
}
