using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace seminar_11_paw.Entities
{
    public class Stock
    {
        public Guid CompanyId {  get; set; }
        public DateTime Date { get; set; }
        public decimal Open {  get; set; }
        public decimal Close { get; set; }
        public decimal Low { get; set; }
        public decimal High { get; set; }
    }
}
