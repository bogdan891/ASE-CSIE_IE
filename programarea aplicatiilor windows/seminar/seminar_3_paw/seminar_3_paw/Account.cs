using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminar_3_paw
{
    public class Account
    {
        //                           Ex. delegat si instanta acestuia.
        //
        public delegate void Operation(double amount);
        private Operation _operation;

        //                                      Actiuni
        // (!)
        // Nu funcntioneaza cu delegatii care nu au tipul VOID.
        // Este de tip generic (in cazul nostru) si non-generic.
        // Poate primi pana la 16 parametri ex: <double, string, etc.>.
        // Ideal ar fi maxim 7 parametri.

        //public Action<double> OperationWithAction;

        private double _balance;

        public delegate void DepositDelegate(double amount, double balance, double difference);
        public event DepositDelegate OnDeposit;

        public Account()
        {
            _balance = 0;
        }

        public void Deposit(double amount)
        {
            _balance += amount;
            //Folosim functia "Invoke" pentru apel.
            OnDeposit?.Invoke(amount, _balance, 10000 - _balance);
        }

        private void Withdraw(double amount)
        {
            _balance -= amount;
        }

        public void Process(double amount)
        {
            if (amount % 2 == 0)
            {
                _operation= Deposit;
            }
            else
            {
                _operation = Withdraw;
            }

            _operation(amount);
        }

        public override string ToString()
        {
            return $"This account has a balance of {_balance}.";
        }
    }
}
