using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_registration
{
    [Serializable]
    public class Registration
    {
        private string companyName;
        private int nbOfPasses;
        private int accessPackageId;
        public string CompanyName
        {
            get => companyName; 
            set => companyName = value;
        }
        public int NbOfPasses
        {
            get => nbOfPasses;
            set => nbOfPasses = value;
        }
        public int AccessPackageId
        {
            get => accessPackageId;
            set => accessPackageId = value;
        }

        public Registration()
        {
            this.CompanyName = "";
            this.NbOfPasses = 0;
            this.AccessPackageId = 0;
        }
        public Registration(string companyName, int nbOfPasses, int accessPackageId)
        {
            CompanyName = companyName;
            NbOfPasses = nbOfPasses;
            AccessPackageId = accessPackageId;
        }

        public static explicit operator double(Registration r) 
        {
            var package = MainForm.accessPackages.FirstOrDefault(p => p.Id == r.AccessPackageId);
            return package != null ? package.Price : 0.0;
        }
    }
}
