namespace Teglalap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Teglalap teglalap = new Teglalap(3.14,6.7);
            Teglalap teglalap1 = new Teglalap(6.9);
            
            //üres
            Console.WriteLine(teglalap.Terulet());
            Console.WriteLine(teglalap.Kerulet());

            //ker
            Console.WriteLine(teglalap.Kerulet(5.446));
            Console.WriteLine(Teglalap.Kerulet(3.4,6.6));

            Console.WriteLine(teglalap1.Magassag);
        }
    }
}
