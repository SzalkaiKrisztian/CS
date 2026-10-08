using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopRefactoring
{
    internal class BankTransferPayment : IPaymentMethod
    {
        public string Name => throw new NotImplementedException();

        public bool Pay(decimal amount)
        {
            Console.WriteLine("true");
            throw new NotImplementedException();
        }
    }
}
