using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen_paw_triunghi
{
    public partial class FormTextDisplay : Form
    {
        public FormTextDisplay()
        {
            InitializeComponent();
            this.Load += FormTextDisplay_Load;
        }

        private void FormTextDisplay_Load(object sender, EventArgs e)
        {
            textAfisare.Clear();

            foreach (var t in FormPrincipal.ColectieTriunghiuri)
            {
                textAfisare.AppendText(t.ToString() + Environment.NewLine);
            }
        }
    }
}
