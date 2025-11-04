using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosCumparaturi
{
    public class ContainerProduse
    {
        Produs[] produse;

        public ContainerProduse()
        {
            produse = new Produs[] { };
        }

        public Produs[] Produse { get => produse; set => produse = value; }

        public static ContainerProduse operator + (ContainerProduse cp, Produs p)
        {
            
            if(cp.Produse.Length == 0)
            {
                cp.Produse = new Produs[1];

                cp.Produse[0] = p;
            }
            else
            {
                Produs[] vectorCopie = new Produs[cp.Produse.Length];

                for(int i = 0; i < cp.Produse.Length; i++)
                    vectorCopie[i] = cp.Produse[i];

                cp.Produse = new Produs[vectorCopie.Length + 1];

                for (int i = 0; i < vectorCopie.Length; i++)
                    cp.Produse[i] = vectorCopie[i];

                cp.Produse[cp.produse.Length - 1] = p;

            }

            return cp;
        }
    }
}
