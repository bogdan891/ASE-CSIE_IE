using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminar_3_paw
{
    public class Individual
    {
        public string Name {  get; set; }
        public bool RegisteredDepositEvent;
        public Account Account { get; }

        public Individual(string name, bool registeredDepositEvent) 
        {
            Name = name;
            Account = new Account();
            if (registeredDepositEvent)
            {
                Account.OnDeposit += OnDepositEventHandler;
            }
        }
        private void OnDepositEventHandler(double amount, double balance, double difference)
        {
            Console.WriteLine($"User {Name} with an amount of {amount} has a balance of " +
                $"{balance} and a difference of {difference} up to 1000.");
        }
    }
}
