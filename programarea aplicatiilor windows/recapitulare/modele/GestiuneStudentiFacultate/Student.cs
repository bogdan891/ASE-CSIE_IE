using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiuneStudentiFacultate
{
    public class Student
    {
        private int nrMatricol;
        private string nume;
        private float medie;

        public Student(int nrMatricol, string nume, float medie)
        {
            this.nrMatricol = nrMatricol;
            this.nume = nume;
            this.medie = medie;
        }

        public int NrMatricol { get => nrMatricol; set => nrMatricol = value; }
        public string Nume { get => nume; set => nume = value; }
        public float Medie { get => medie; set => medie = value; }
    }
}
