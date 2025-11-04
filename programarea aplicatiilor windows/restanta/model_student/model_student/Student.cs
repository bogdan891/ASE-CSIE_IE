using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_student
{
    [Serializable]
    public class Student : ICloneable
    {
        private string nume;
        private int nrMatricol;
        private float medie;
        //Setters & getters
        public string Nume
        {
            get => this.nume;
            set => this.nume = value;
        }
        public int NrMatricol
        {
            get => this.nrMatricol;
            set => this.nrMatricol = value;    
        }
        public float Medie
        {
            get => this.medie;
            set => this.medie = value;
        }
        //Constructori
        public Student()
        {
            this.nume = "";
            this.nrMatricol = 0;
            this.medie = 0;
        }
        public Student(string nume, int nrMatricol, float medie)
        {
            this.nume = nume;
            this.nrMatricol = nrMatricol;
            this.medie = medie;
        }
        //Supraincarcari operatori si metode
        public static bool operator ==(Student s1, Student s2)
        {
            if (ReferenceEquals(s1, s2)) return true;
            if (s1 is null || s2 is null) return false;
            return s1.nrMatricol == s2.nrMatricol && s1.medie == s2.medie;
        }
        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }
        public override bool Equals(object obj)
        {
            return obj is Student student && this == student;
        }
        public override int GetHashCode()
        {
            return nrMatricol.GetHashCode() ^ medie.GetHashCode();
        }
        public static bool operator <(Student s1, Student s2)
        {
            return s1.medie < s2.medie;
        }
        public static bool operator >(Student s1, Student s2)
        {
            return s1.medie > s2.medie;
        }
        public static bool operator <=(Student s1, Student s2)
        {
            return s1.medie <= s2.medie;
        }
        public static bool operator >=(Student s1, Student s2)
        {
            return s1.medie >= s2.medie;
        }
        public static Student operator +(Student s1, Student s2)
        {
            return new Student("", s1.nrMatricol, (s1.medie + s2.medie) / 2);
        }
        public static Student operator +(Student s, float nota)
        {
            return new Student(s.Nume, s.nrMatricol, (s.medie + nota) / 2);
        }
        public static Student operator ++(Student s)
        {
            return new Student(s.Nume, s.nrMatricol, s.medie + 1);
        }
        public static Student operator --(Student s)
        {
            return new Student(s.Nume, s.nrMatricol, s.medie - 1);
        }
        public static explicit operator float(Student s)
        {
            return s.medie;
        }
        public override string ToString()
        {
            return $"Student [NrMatricol={nrMatricol}, Medie={medie}]";
        }
        public object Clone()
        {
            return new Student(this.Nume, this.nrMatricol, this.medie);
        }
    }
}
