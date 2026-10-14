namespace TeremStatisztika;

// Ebben a fájlban dolgozol. Minden metódust LINQ-val írj meg, ciklus (for, foreach) nélkül.
public class Lekerdezesek
{
    private readonly List<Foglalas> foglalasok;

    public Lekerdezesek(List<Foglalas> foglalasok)
    {
        this.foglalasok = foglalasok;
    }

    // 1. feladat: Hány foglalása van az adott teremnek?
    // Tipp: Count(feltétel)
    public int Darab(string terem)
    {
        return foglalasok.Count(c=>c.Terem==terem);
    }

    // 2. feladat: Van-e az adott teremnek foglalása az adott napon?
    // Tipp: Any(feltétel)
    public bool Van(string terem, DateOnly datum)
    {
        return foglalasok.Any(k=>k.Terem==terem && k.Datum==datum);
    }

    // 3. feladat: Az adott nap összes foglalása kezdési időpont szerint rendezve.
    // Azonos kezdésnél a teremnév döntsön.
    // Tipp: Where, OrderBy, ThenBy, ToList
    public List<Foglalas> Napi(DateOnly datum)
    {
        return foglalasok.Where(n=>n.Datum==datum).OrderBy(b=>b.Datum).ThenBy(h=>h.Terem).ToList();
    }

    // 4. feladat: Az adott terem foglalásainak összes hossza percben.
    // Tipp: Sum, és a Hossz.TotalMinutes (nem a Minutes!). A kapott szám double, alakítsd int-té.
    public int Percek(string terem)
    {
        return (int)(foglalasok.Sum(s=>(s.Veg - s.Kezdet).TotalMinutes));
    }

    // 5. feladat: Az adott terem foglalásainak átlagos hossza percben.
    // Ha a teremnek nincs foglalása, null legyen az eredmény. (Az Average üres listára kivételt dobna,
    // ezt előbb ellenőrizd.)
    public double? Atlag(string terem)
    {
        return foglalasok.Where(k=>k.Terem==terem).Average(t=>(t.Veg-t.Kezdet).TotalMinutes);
    }

    // 6. feladat: Az adott terem leghosszabb foglalása. Azonos hossznál a korábbi dátumú,
    // azon belül a korábban kezdődő nyer. Ha nincs foglalás, null legyen az eredmény.
    // Tipp: OrderByDescending, ThenBy, FirstOrDefault
    public Foglalas Leghosszabb(string terem)
    {
        return foglalasok.Where(w=>w.Terem==terem).OrderBy(o=>o.Datum).ThenBy(t=>t.Kezdet).FirstOrDefault();
    }
}
