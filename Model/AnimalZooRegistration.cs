using Microsoft.EntityFrameworkCore;

namespace CloudWebApplication.Model
{
    public class AnimalZooRegistration
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Ration { get; set; }
        public string Caretaker { get; set; }

        public AnimalZooRegistration()
        {
            Kind = "";
            Name = "";
            DateOfBirth = "";
            Sex = "";
            Ration = "";
            Caretaker = "";
        }

        public override string ToString()
        {
            return $"Kind of animal - {Kind};" +
                   $" his name - {Name};" +
                   $" birthday - {DateOfBirth};" +
                   $" sex - {Sex};" +
                   $" ration - {Ration};" +
                   $" caretaker - {Caretaker};";
        }
    }
}
