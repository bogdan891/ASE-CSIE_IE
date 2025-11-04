using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferinteBibliografice
{
    public abstract class Publicatie
    {
        public string titlu;
        public float pret;

        public Publicatie(string titlu, float pret)
        {
            this.titlu = titlu;
            this.pret = pret;
        }

        public Publicatie()
        {

        }
        

        public string Titlu { get => titlu; set => titlu = value; }
        public float Pret { get => pret; set => pret = value; }

        

        public abstract string genereazaReferinta();
    }
}
