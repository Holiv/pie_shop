using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettanyShopHRM.HR
{
    internal class Manager : Employee
    {
        public Manager(string firstName, string lastName, string email, DateTime birthDay, double? hourlyRate) : base(firstName, lastName, email, birthDay, hourlyRate)
        {

        }
        public Manager(string firstName, string lastName, string email, DateTime birthDay, double? hourlyRate, string street, string houseNumber, string zipCode, string city) : base (firstName, lastName, email, birthDay, hourlyRate, street, houseNumber, zipCode, city)// <-- also setting in the constructor
        {

        }

        public override void GiveBonus()
        {
            if (NumberOfHoursWorked > 5)
            {
                Console.WriteLine($"Employee {FirstName} {LastName} received a management bonus of 500!");
            }
            else
            {
                Console.WriteLine($"Employee {FirstName} {LastName} receive a management bonus of 250!");
            }
            
        }

        public void AttendManagementMeeting()
        {
            NumberOfHoursWorked += 10;
            Console.WriteLine($"Manager {FirstName} {LastName} is now attenging a long meeting that could have been an email!");
        }
    }
}
