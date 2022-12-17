using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettanyShopHRM.HR
{
    internal class Researcher : Employee
    {
        private int numberOfPieTasteInvented = 0;
        public int NumberOfPieTasteInvented
        {
            get => numberOfPieTasteInvented;
            set => numberOfPieTasteInvented = value;
        }

        public void ResearchNewPieTaste(int researchHours)
        {
            NumberOfHoursWorked += researchHours;

            if (new Random().Next(100) > 50)
            {
                NumberOfPieTasteInvented++;

                Console.WriteLine($"Researcher {FirstName} {LastName} has invented a new pie taste! Total numbers os pies invented: {NumberOfPieTasteInvented}");
            }
            else
            {
                Console.WriteLine($"Researcher {FirstName} {LastName} is working still on a new pie taste");
            }
        }
        public Researcher(string firstName, string lastName, string email, DateTime birthDay, double? hourlyRate) : base(firstName, lastName, email, birthDay, hourlyRate)
        {
        }
    }
}
