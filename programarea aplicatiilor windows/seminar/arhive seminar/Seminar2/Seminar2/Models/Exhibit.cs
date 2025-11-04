namespace Seminar2.Models
{
    public abstract class Exhibit
    {
        public int Number { get; set; }        
        public string Name { get; set; }
        public int Area { get; set; }

        public Exhibit(int number, string name, int area) {
            Number = number;
            Name = name;
            Area = area;
        }

        public abstract void Clean();
    }
}
