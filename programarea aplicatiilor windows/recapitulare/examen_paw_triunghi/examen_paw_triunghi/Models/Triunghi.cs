using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_paw_triunghi
{
    [Serializable]
    public class Triunghi : FiguraGeometrica, IMasurabil, ICloneable
    {
        public Color Culoare { get; set; }
        public float GrosimeLinie { get; set; }
        public int CodFigura { get; }
        public string Eticheta { get; set; }

        public int NrPuncte => 3;

        //Constructor cu toti parametrii
        public Triunghi(List<Punct> puncte, Color culoare, float grosime, int cod, string eticheta)
        {
            if (puncte == null || puncte.Count != 3)
                throw new ArgumentException("Un triunghi trebuie să aibă exact 3 puncte.");

            Puncte = new List<Punct>
            {
                new Punct(puncte[0].X, puncte[0].Y),
                new Punct(puncte[1].X, puncte[1].Y),
                new Punct(puncte[2].X, puncte[2].Y)
            };

            Culoare = culoare;
            GrosimeLinie = grosime;
            CodFigura = cod;
            Eticheta = eticheta;
        }

        // Constructor alternativ cu 3 puncte
        public Triunghi(Punct p1, Punct p2, Punct p3, Color culoare, float grosime, int cod, string eticheta)
            : this(new List<Punct> { p1, p2, p3 }, culoare, grosime, cod, eticheta)
        {
        }

        //Operator de indexare
        public Punct this[int index]
        {
            get
            {
                if (index < 0 || index >= 3)
                    throw new IndexOutOfRangeException("Indexul trebuie să fie 0, 1 sau 2.");
                return Puncte[index];
            }
            set
            {
                if (index < 0 || index >= 3)
                    throw new IndexOutOfRangeException("Indexul trebuie să fie 0, 1 sau 2.");
                Puncte[index] = value;
            }
        }

        //Suprascriere metoda
        public double CalculPerimetru()
        {
            double Distanta(Punct a, Punct b) =>
                Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));

            return Distanta(Puncte[0], Puncte[1]) +
                   Distanta(Puncte[1], Puncte[2]) +
                   Distanta(Puncte[2], Puncte[0]);
        }

        public double Perimetru => CalculPerimetru();

        //Suprascriere metoda Clone
        public object Clone() 
        {
            return new Triunghi(
            new Punct(Puncte[0].X, Puncte[0].Y),
            new Punct(Puncte[1].X, Puncte[1].Y),
            new Punct(Puncte[2].X, Puncte[2].Y),
            this.Culoare,
            this.GrosimeLinie,
            this.CodFigura,
            this.Eticheta);
        }

        public override string ToString() =>
            $"{Eticheta} (Cod: {CodFigura}, Perimetru: {Perimetru:F2})";
    }
}
