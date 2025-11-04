using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace subiect_examen.Models
{
    [Serializable]
    public class Vagon
    {
        private int id;
        private int capacitate;

        //Getters & Setters
        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public int Capacitate
        {
            get => this.capacitate;
            set => this.capacitate = value;
        }

        //Constructors
        public Vagon()
        {
            this.id = 0;
            this.capacitate = 0;
        }
        public Vagon(int id, int capacitate)
        {
            this.id = id;
            this.capacitate = capacitate;
        }

        public override string ToString() => $"Vagon {Id} ({Capacitate} locuri)";
    }
}
