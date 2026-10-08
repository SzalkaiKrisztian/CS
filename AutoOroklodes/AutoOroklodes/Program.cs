namespace AutoOroklodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jarmu jarmu = new Jarmu();
            jarmu.Sebesseg = 50;
            jarmu.Halad();

            Console.WriteLine();
            Auto auto = new Auto();
            auto.Uzemanyag = 5;
            auto.Tankol();
            auto.Uzemanyag += 10;
            auto.Tankol();

            Console.WriteLine();
            Bicikli bicikli = new Bicikli();
            bicikli.Csenget();

            Console.WriteLine();
            Jarmu j = new Auto();
            j.Sebesseg = 20;
            (j as Auto).Tankol();
        }
    }
}
