namespace Ismetles_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mozijegy mj;
            try
            {
                mj = new Mozijegy(-100);
                mj.Ar = -1000;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("a jegy ára nem lehet negatív (trycatchben)");
                mj = new Mozijegy(100);
            }
            Console.WriteLine(mj.Ar);
        }
    }

    class Mozijegy
    {
        private int _ar;
        public int Ar
        {
            get { return _ar; } 
            set { if (value >= 0) { _ar = value; } else { throw new ArgumentException("A jegy ára nem lehet negatív (classban)"); } }
        }
        public Mozijegy(int ar)
        {
            Ar = ar;
        }
    }
}
