namespace autok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.feladat
            AutokStatisztika obj = new AutokStatisztika("jeladas.txt","ido.txt");

            //2.feladat
            obj.UtolsoJel();

            //3.feladat
            obj.AutoJelei();

            //4.feladat
            Console.WriteLine("4. feladat:");
            Console.WriteLine($"A jeladások száma: {obj.AdottIdoJeleinekSzama()}");

            //5.feladat
            Console.WriteLine("5. feladat:");
            obj.LegGyorsabb();

            //6.feladat
            Console.WriteLine("6.feladat");
            //obj.KeresettAutoAdatai();

            //7.feladat
            Console.WriteLine("7.feladat");
            obj.Kiiras();
        }
    }
}
