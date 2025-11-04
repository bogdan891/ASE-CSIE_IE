using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_registration
{
    [Serializable]
    public class AccessPackage
    {
        private int id;
        private string name;
        private double price;

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        public double Price
        {
            get => this.price;
            set => this.price = value;
        }
        public AccessPackage(int id, string name, double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }

        public string AccessPackageName
        {
            get
            {
                var package = MainForm.accessPackages.FirstOrDefault(x => x.Id == id);
                return package != null ? package.Name : "NULL";
            }
        }
    }
}
