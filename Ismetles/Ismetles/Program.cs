namespace Ismetles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Doboz d1 = new Doboz();
            d1.Tartalom = 10;
            Doboz d2 = d1;
            d2.Tartalom = 99;
            Console.WriteLine(d1.Tartalom);

            int szam1 = 10;
            int szam2 = szam1;
            szam2 = 99;
            Console.WriteLine(szam1);
        }
            
    }
    class Doboz
    {
        public int Tartalom { get; set; }
    }
}
