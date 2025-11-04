using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firme
{
    public class ContainerProduse
    {
        List<Produs> produse;

        public ContainerProduse(List<Produs> produse)
        {
            this.Produse = produse;
        }

        public List<Produs> Produse { get => produse; set => produse = value; }


        public override string ToString()
        {
            string str = null;

            foreach (Produs produs in this.produse)
                str += produs.ToString() + Environment.NewLine;

            return str;
        }
    }
}
