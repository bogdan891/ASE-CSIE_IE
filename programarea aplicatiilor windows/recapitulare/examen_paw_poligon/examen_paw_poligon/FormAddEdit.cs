using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using examen_paw_poligon.Models;

namespace examen_paw_poligon
{
    public partial class FormAddEdit : Form
    {
        // listă de puncte pentru poligon
        private readonly List<Punct> _puncte = new List<Punct>();

        private Color _culoare = Color.Black;
        private int _codFigura;

        public Poligon PoligonCreat { get; private set; }

        /* ---------------- Constructor pentru ADĂUGARE ---------------- */
        public FormAddEdit()
        {
            InitializeComponent();

            Text = "Adaugă poligon";
            _codFigura = new Random().Next(1000, 9999);
            pnlPreview.BackColor = _culoare;

            // Ne asigurăm că butoanele sunt legate de evenimente
            btnCuloare.Click += btnCuloare_Click;
            btnAdaugaPunct.Click += btnAdaugaPunct_Click;
            btnSalvare.Click += btnSalvare_Click;
            btnAnulare.Click += btnAnulare_Click;
        }

        /* ---------------- Constructor pentru EDITARE ---------------- */
        public FormAddEdit(Poligon existent) : this()
        {
            if (existent == null) return;

            Text = "Editează poligon";
            _culoare = existent.Culoare;
            pnlPreview.BackColor = _culoare;

            numLinie.Value = existent.GrosimeLinie;
            txtEticheta.Text = existent.Eticheta;
            _codFigura = existent.CodFigura;

            _puncte.Clear();
            _puncte.AddRange(existent.Puncte);
            foreach (var p in _puncte)
                listBox1.Items.Add(p.ToString());
        }

        /* ---------------- ALEGERE CULOARE ---------------- */
        private void btnCuloare_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _culoare = colorDialog1.Color;
                pnlPreview.BackColor = _culoare;
            }
        }

        /* ---------------- ADĂUGARE PUNCT ---------------- */
        private void btnAdaugaPunct_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (!float.TryParse(txtX.Text, out float x))
            {
                errorProvider1.SetError(txtX, "Valoare invalidă");
                return;
            }
            if (!float.TryParse(txtY.Text, out float y))
            {
                errorProvider1.SetError(txtY, "Valoare invalidă");
                return;
            }
            if (x < 0 || y < 0)
            {
                MessageBox.Show("Coordonatele trebuie să fie pozitive");
                return;
            }

            Punct p = new Punct(x, y);
            _puncte.Add(p);
            listBox1.Items.Add(p.ToString());

            txtX.Clear();
            txtY.Clear();
            txtX.Focus();
        }

        /* ---------------- SALVARE POLIGON ---------------- */
        private void btnSalvare_Click(object sender, EventArgs e)
        {
            if (_puncte.Count < 3)
            {
                MessageBox.Show("Poligonul are nevoie de minim 3 puncte");
                return;
            }

            PoligonCreat = new Poligon(
                _culoare,
                (int)numLinie.Value,
                _codFigura,
                txtEticheta.Text,
                new List<Punct>(_puncte));

            DialogResult = DialogResult.OK;
            Close();
        }

        /* ---------------- ANULARE ---------------- */
        private void btnAnulare_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
