using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    [Serializable]
    public class FileModel
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
