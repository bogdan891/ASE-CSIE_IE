using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_apartament
{
    [Serializable]
    public class Apartament
    {
        private int nrCamere;
        private Camera[] camere;

        public Apartament()
        {
            nrCamere = 0;
            camere = null;
        }
        public Apartament(int nrCamere, Camera[] camere)
        {
            this.nrCamere = nrCamere;
            if (camere.Length != nrCamere)
                throw new ArgumentException("Numărul de camere nu corespunde cu array-ul primit.");
            if (camere != null )
            {
                this.camere = new Camera[nrCamere];
                for( int i = 0; i < nrCamere; i++ ) this.camere[i] = camere[i];
            }
        }
        public int NrCamere
        {
            get => this.nrCamere;
            set
            {
                if(value > 0) this.nrCamere = value;
            }
        }
        public Camera[] Camere
        {
            get
            {
                if (this.camere == null)
                    return null;
                Camera[] copy = new Camera[this.nrCamere];
                for (int i = 0; i < this.nrCamere; i++) copy[i] = this.camere[i];
                return copy;
            }
            set
            {
                if(value != null)
                {
                    this.camere = new Camera[value.Length];
                    for(int i = 0; i < value.Length; i++ ) this.camere[i] = value[i];
                }
                else
                {
                    this.camere = null;
                }
            }
        }
        public double CalculSuprafata()
        {
            double s = 0;
            if(this.nrCamere > 0 && this.camere != null)
            {
                for (int i = 0; i < this.nrCamere; i++)
                {
                    s += this.camere[i].Suprafata;
                }
            } 
            return s;
        }
    }
}
