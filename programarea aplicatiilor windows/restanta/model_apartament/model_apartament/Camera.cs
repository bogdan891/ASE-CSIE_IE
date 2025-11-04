using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_apartament
{
    [Serializable]
    public class Camera
    {
        private double lungime;
        private double latime;
        private Orientare orientare;

        public Camera()
        {
            this.lungime = 0;
            this.latime = 0;
            this.orientare = Orientare.N;
        }
        public Camera(double lungime, double latime, Orientare orientare)
        {
            this.lungime = lungime;
            this.latime = latime;
            this.orientare = orientare;
        }
        public double Lungime
        {
            get => this.lungime;
            set
            {
                if (value > 0) this.lungime = value;
            }
        }
        public double Latime
        {
            get => this.latime;
            set
            {
                if (value > 0) this.latime = value;
            }
        }
        public Orientare Orientare
        {
            get => this.orientare;
            set => this.orientare = value;
        }
        public double Suprafata
        {
            get => Math.Round(this.lungime * this.latime, 2);
        }

        public string OrientareAfisata
        {
            get
            {
                if (this.orientare == Orientare.N) return "Nord";
                if (this.orientare == Orientare.S) return "Sud";
                if (this.orientare == Orientare.E) return "Est";
                return "Vest";
            }
        }

    }
}
