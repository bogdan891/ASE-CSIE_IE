using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seminar_4_paw
{
    public partial class Form1 : Form
    {
        private List<Student> _students;
        public Form1()
        {
            InitializeComponent();
            _students = new List<Student>();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var student = new Student();
            student.FirstName = firstNameTextBox.Text;
            student.LastName = lastNameTextBox.Text;
            //var ageText = ageTextBox.Text;
            
            if (!ushort.TryParse(ageTextBox.Text, out ushort age))
            {
                MessageBox.Show("Age is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            student.Age = age;

            _students.Add(student);
            firstNameTextBox.Text = string.Empty;
            lastNameTextBox.Text = string.Empty;
            ageTextBox.Text = string.Empty;
        }
    }
}
