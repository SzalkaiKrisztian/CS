namespace AlakzatokOroklodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Alakzat> alakzatok = new List<Alakzat>();

            Negyzet negyzet = new Negyzet();
            negyzet.OLdal = 5;
            alakzatok.Add(negyzet);

            Kor kor = new Kor();
            kor.Sugar = 5;
            alakzatok.Add(kor);

            Haromszog haromszog = new Haromszog();
            haromszog.Alap = 5;
            haromszog.Magassag = 2.5;
            alakzatok.Add(haromszog);
            
            //---kiiratas
            for (int i = 0; i < alakzatok.Count; i++)
            {
                Console.WriteLine($"Az alakzat Területe: {alakzatok[i].Terulet()} cm.");
            }
        }
    }
}
