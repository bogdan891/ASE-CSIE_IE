using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace seminar_3_paw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Account account = new Account();

            //account.Process(50);
            //account.Process(21);

            //Console.WriteLine(account.ToString());
            //Console.ReadKey();

            Individual ion = new Individual("Ion", true);
            ion.Account.Process(50);
            ion.Account.Process(21);
            Console.WriteLine(ion.Account.ToString());
            Console.ReadKey();
        }
    }
}
