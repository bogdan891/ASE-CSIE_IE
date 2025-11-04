using CarRentalApp.Database;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class CarListForm: Form
    {
        public CarListForm() {
            InitializeComponent();

            carsDataGridView.AutoGenerateColumns = false;
            carsDataGridView.DataSource = FakeDatabase.Cars;

            AddTextBoxColumn("Id", "ID", isVisible: false);
            AddTextBoxColumn("Make", "Marca", 200);
            AddTextBoxColumn("Model", "Model", 180);
            AddTextBoxColumn("Year", "An");
            AddTextBoxColumn("Seats", "Locuri");
            AddCheckBoxColumn("HasInsurance", "Are asigurare");
            AddTextBoxColumn("LicenseNumber", "Numar de inmatriculare");
        }

        private void AddTextBoxColumn(string propertyName, string headerText, int width = 100, bool isVisible = true) {
            var column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = propertyName;
            column.HeaderText = headerText;
            column.Width = width;
            column.Name = propertyName;
            column.Visible = isVisible;
            carsDataGridView.Columns.Add(column);
        }

        private void AddCheckBoxColumn(string propertyName, string headerText, int width = 100) {
            var column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = propertyName;
            column.HeaderText = headerText;
            column.Width = width;
            column.Name = propertyName;
            carsDataGridView.Columns.Add(column);            
        }

        private void addCarToolStripMenuItem_Click(object sender, System.EventArgs e) {
            var addCarForm = new AddCarForm();
            addCarForm.ShowDialog();
            carsDataGridView.DataSource = null;
            carsDataGridView.DataSource = FakeDatabase.Cars;
        }

        private void masiniToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void adaugaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }
    }
}
