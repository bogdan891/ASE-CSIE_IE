using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferinteBibliografice
{
    public class Carte : Publicatie
    {
        private readonly string isbn;
        private string categorie;
        private List<Autor> autori = new List<Autor>();


        public string Isbn => isbn;

        public string Categorie { get => categorie; set => categorie = value; }
        public List<Autor> Autori { get => autori; set => autori = value; }

        public Carte(string isbn, string categorie, List<Autor> autori, string titlu, float pret) : base(titlu, pret)
        {
            this.isbn = isbn;
            this.categorie = categorie;
            this.autori = autori;
        }

        public Carte() 
        {
            
        }
        public Carte(string isbn, string categorie, string titlu, float pret) : base(titlu, pret)
        {
            this.isbn = isbn;
            this.categorie = categorie;
           
        }
        

        public static Carte operator+(Carte c, Autor a)
        {
            c.autori.Add(a);

            return c;
        }

        public override string genereazaReferinta()
        {
            string rezultat = null;

            
            foreach (Autor autor in autori)
                rezultat += autor.Nume + ", ";
            
            

            rezultat = "  -  " + this.titlu + ", " + this.isbn;

            return rezultat;
        }


        public override string ToString()
        {
            return "Cartea " + this.titlu + " cu codul ISBN: " + this.isbn + " are pretul " + this.pret + " face parte din categoria " + this.categorie + " si are un numar de " + this.autori.Count + " autori.";

        }

    }
}
