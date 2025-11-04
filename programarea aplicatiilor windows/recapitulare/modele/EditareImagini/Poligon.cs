using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditareImagini
{
    [Serializable]
    public class Poligon
    {
        private List<Punct> puncte;
        private string culoare;
        private int grosime_linie;
        private readonly int cod_figura;
        private string eticheta;

        public Poligon(List<Punct> puncte, string culoare, int grosime_linie, int cod_figura, string eticheta)
        {
            this.puncte = puncte;
            this.culoare = culoare;
            this.grosime_linie = grosime_linie;
            this.cod_figura = cod_figura;
            this.eticheta = eticheta;
        }

        public List<Punct> Puncte { get => puncte; set => puncte = value; }
        public string Culoare { get => culoare; set => culoare = value; }
        public int Grosime_linie { get => grosime_linie; set => grosime_linie = value; }

        public int Cod_figura => cod_figura;

        public string Eticheta { get => eticheta; set => eticheta = value; }

        public float getDistanta2Puncte(Punct a, Punct b)
        {
            return (float)Math.Sqrt((a.X - b.X)* (a.X - b.X) + (a.Y - b.Y)* (a.Y - b.Y));
        }

        public float perimetru()
        {
            float perimetru = 0;

            for (int i = 0; i < puncte.Count - 1; i++)
                perimetru += getDistanta2Puncte(puncte[i], puncte[i + 1]);

            perimetru += getDistanta2Puncte(puncte[0], puncte[puncte.Count - 1]);

            return perimetru;

        }

        public Punct this[int index]
        {
            get => puncte[index];
            set => puncte[index] = value;
        }

        
    }
}
