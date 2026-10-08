namespace Ismetles_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Konyv konyv1 = new Konyv("Szirmarillions","Tolkein",1000);
            konyv1.Bemutat();
            Konyv konyv2 = new Konyv("Biblia","Isten",9000);
            konyv2.Bemutat();

        }
    }
    class Konyv
    {
        private string _cim;
        private string _szerzo;
        private int _oldalszam;

        public Konyv(string cim, string szerzo, int oldalszam)
        {
            _cim = cim;
            _szerzo = szerzo;
            _oldalszam = oldalszam;
        }

        public string Cim
        {
            get { return _cim; }
            set { _cim = value; }
        }
        public string Szerzo
        {
            get { return _szerzo; }
            set { _szerzo = value; }
        }
        public int Oldalszam
        {
            get { return _oldalszam; }
            set { _oldalszam = value; }
        }

        public void Bemutat()
        {
            Console.WriteLine($"A könyv címe: {Cim}, Szerezője: {Szerzo}, a könyv {Oldalszam} oldalas");
        }
    }
}
