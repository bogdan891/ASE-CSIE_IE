
using System;

namespace Subiect1
{
    [Serializable]//important pt a putea serializa
    public class Angajat
    {
    public int Cod { get; set; }//proprietatea e un atribut care are getter si setter
    public string Nume { get; set; }
    public double Salariu { get; set; }
    public int? CodManager { get; set; }// int null abil adica pot pune si null
        public override string ToString()
        {
            return $"{Cod}, {Nume}, {Salariu}";
        }
    }
}
