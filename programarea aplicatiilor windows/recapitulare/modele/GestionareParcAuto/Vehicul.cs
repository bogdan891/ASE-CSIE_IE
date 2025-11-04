using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionareParcAuto
{
    public abstract class Vehicul
    {
        private int id;
        private string proprietar;
        private float pret;

        public int Id { get => id; set => id = value; }
        public string Proprietar { get => proprietar; set => proprietar = value; }
        public float Pret { get => pret; set => pret = value; }

        protected Vehicul(int id, string proprietar, float pret)
        {
            this.id = id;
            this.proprietar = proprietar;
            this.pret = pret;
        }
    }
}
