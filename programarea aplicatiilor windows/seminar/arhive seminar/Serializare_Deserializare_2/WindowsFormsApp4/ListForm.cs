using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class ListForm : Form
    {
        public ListForm()
        {
            InitializeComponent();
            sectiiDataGridView.DataSource = FakeDatabase.Sectii;
            sectiiDataGridView.AutoGenerateColumns = true;
        }
    }
}
