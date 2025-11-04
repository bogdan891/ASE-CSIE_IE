using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_paw_poligon.Models
{
    [Serializable]
    public class Poligon
    {
        private Color culoare;
        private int grosime_linie;
        private readonly int cod_figura;
        private string eticheta;
        private List<Punct> puncte;
        public Color Culoare
        {
            get => culoare;
            set => culoare = value;
        }
        public int GrosimeLinie
        {
            get => grosime_linie;
            set => grosime_linie = value;
        }
        public int CodFigura
        {
            get => cod_figura;
        }
        public string Eticheta
        {
            get => eticheta;
            set => eticheta = value;
        }
        public List<Punct> Puncte
        {
            get => puncte;
            set => puncte = value;
        }
        public Poligon() { }
        public Poligon(Color culoare, int grosimeLinie, int codFigura, string eticheta, List<Punct> puncte)
        {
            this.culoare = culoare;
            this.grosime_linie = grosimeLinie;
            this.cod_figura = codFigura;
            this.eticheta = eticheta;
            if (puncte != null)
            {
                this.puncte = new List<Punct>(puncte);
            }
            else
            {
                this.puncte = new List<Punct>();
            }
        }
        public override string ToString()
        {
            return $"{culoare.Name},{grosime_linie},{cod_figura},{eticheta},{string.Join(" | ", puncte.Select(p => p.ToString()))}";
        }
        public Punct this[int index]
        {
            get => puncte[index];
            set => puncte[index] = value;
        }

        public float CalculPerimetru()
        {
            float p = 0;
            for (int i = 0; i < puncte.Count - 1; i++)
            {
                p += (float)Punct.Distanta(puncte[i], puncte[i + 1]);
            }
            if (puncte.Count > 2)
            {
                p += (float)Punct.Distanta(puncte[puncte.Count - 1], puncte[0]);
            }
            return p;
        }
    }
}
