namespace Mediatar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Katalogus katalogusObj = new Katalogus("MediaTabla.csv");
            katalogusObj.ListaKiiratas();

            
        }
    }
}
