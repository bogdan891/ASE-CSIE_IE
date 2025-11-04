using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace examen_paw_studenti
{
    public class Student
    {
        private int matricol;
        private string nume;
        private float media;

        public int Matricol
        {
            get => matricol;
        }
        public string Nume
        {
            get => nume;
            set => nume = value;
        }
        public float Media
        {
            get => media;
            set => media = value;
        }
        public Student() { }
        public Student(int matricol, string nume, float media)
        {
            this.matricol = matricol;
            this.nume = nume;
            this.media = media;
        }
        public override string ToString()
        {
            return $"{Matricol},{Nume},{Media}";
        }
    }
}
