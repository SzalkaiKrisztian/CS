namespace Strand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kolcsonzesek kolcsonObj = new Kolcsonzesek();
            foreach(Cikk c in kolcsonObj.Cikkek)
            {
                if(c is Kenu)
                {
                    Console.WriteLine($" Kenu {c.VonalKod}, {c.Kolcson}, {(c as Kenu).Tomeg}, {(c as Kenu).Fajta}");
                }
                else{
                    Console.WriteLine($" Kenu {c.VonalKod}, {c.Kolcson}, {(c as Vizibicikli).Szemelyek}");
                }
            }
        }
    }
}
