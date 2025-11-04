using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace model_credit
{
    public class Credit
    {
        private string client;
        private double valoareCredit;
        private double dobanda;
        private DateTime dataAcordarii;
        private int perioadaCreditare;

        public Credit(string client, double valoareCredit, double dobanda, DateTime dataAcordarii, int perioadaCreditare)
        {
            this.client = client;
            this.valoareCredit = valoareCredit;
            this.dobanda = dobanda;
            this.dataAcordarii = dataAcordarii;
            this.perioadaCreditare = perioadaCreditare;
        }
        public Credit()
        {
            this.client = "NULL";
            this.valoareCredit = 0;
            this.dobanda = 0;
            this.dataAcordarii = DateTime.Now;
            this.perioadaCreditare = 0;
        }
        public string Client
        {
            get => this.client;
            set => this.client = value;
        }
        public double ValoareCredit
        {
            get => this.valoareCredit;
            set => this.valoareCredit = value;
        }
        public double Dobanda
        {
            get => this.dobanda;
            set => this.dobanda = value;
        }
        public DateTime DataAcordarii
        {
            get => this.dataAcordarii;
            set => this.dataAcordarii = value;
        }
        public int PerioadaCreditare
        {
            get => this.perioadaCreditare;
            set => this.perioadaCreditare = value;
        }
        public override string ToString()
        {
            return $"Client: {Client} - {ValoareCredit} cu {Dobanda}% dobanda incepand cu {DataAcordarii.ToString()} pentru {PerioadaCreditare} ani.";
        }
    }
}
