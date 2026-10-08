namespace InterFaceGyakorlas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IJarmu> Jarmuvek = new List<IJarmu>()
            {
                new Auto(),
                new Bicikli()
            };

            //--kiiratas
            for (int i = 0; i < Jarmuvek.Count; i++)
            {
                Jarmuvek[i].Indit();
                Jarmuvek[i].Megall();
            }
        }
    }
}
