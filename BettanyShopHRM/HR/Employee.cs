using System;
using System.ComponentModel;
using System.Text;
using BethanysPieShopHRM.Logic;
using Newtonsoft.Json;

namespace BettanyShopHRM.HR
{
	public class Employee : IEmployee
	{
		//fiels of the class that each object will inherit
		private string firstName;
		private string lastName;
        private string email;
		private Address adress;

        private int numberOfHoursWorked;
        private double wage;
        private double? hourlyRate; // <-- setting the field to accept double and null values

        private DateTime birthDay;

        private const int minimalHoursWorkedUnit = 1;

        private WorkTask workTask;

        private static double taxRate = 0.15;
        private static int minBonus = 100;
        private static int bonusTax = 0;

		public Address Address
		{
			get => adress;
			set => adress = value;
		}
		public void ShowAdress()
		{
			string[] address = new string[4] {Address.Street, Address.HouseNumber, Address.City, Address.ZipCode };
			Console.WriteLine($"The employee address is {String.Join(" ", address)}");
		}
		public string FirstName
		{
			get 
			{ 
				return firstName; 
			}
			set 
			{
				firstName = value;
			}
		}

		public string LastName
		{
			get { return lastName;}
			set
			{
				lastName = value;
			}
		}

		public string Email
		{
			get { return email;}
			set
			{
				email = value;
			}
		}

		public DateTime BirthDay
		{
			get { return birthDay; }
            set
            {
                birthDay = value;
            }
		}

		public double? HourlyRate
		{
			get { return hourlyRate;}
            set
            {
                if (value.HasValue && value < 0) 
				{
					hourlyRate = 0; 
				}
				else
				{
					hourlyRate = value;

                }
            }
		}

		public int NumberOfHoursWorked
		{
			get { return numberOfHoursWorked; }
			protected set => numberOfHoursWorked = value;
		}

		public double Wage
		{
			get { return wage; }
			private set => wage = value;
		}

		//methods of the class that each object will inherit
		public Employee(string firstName, string lastName, string email, DateTime birthDay, double? hourlyRate)// <-- also setting in the constructor
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			BirthDay = birthDay;
			HourlyRate = hourlyRate ?? 10; // <-- using the nullish coalescent operator. if the value from the constructor come as null the default value of 10 will be assigned.
		}
        public Employee(string firstName, string lastName, string email, DateTime birthDay, double? hourlyRate, string street, string houseNumber, string zipCode, string city)// <-- also setting in the constructor
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDay = birthDay;
            HourlyRate = hourlyRate ?? 10; // <-- using the nullish coalescent operator. if the value from the constructor come as null the default value of 10 will be assigned.

			Address = new Address(street, houseNumber, zipCode, city);
        }

        //method that uses an external type to work with json format
        public string ConvertToJSON()
		{
			string json = JsonConvert.SerializeObject(this);
			return json;
		}

		public void PerformWork()
		{
			PerformWork(minimalHoursWorkedUnit);
			//Console.WriteLine($"{firstName} {lastName} has worked {numberOfHoursWorked} hour(s)");
		}

		//creating a method overloading - a method with the same name, but different parameters
		public void PerformWork(int numberOfHours)
		{
			NumberOfHoursWorked += numberOfHours;
			Console.WriteLine($"{FirstName} {LastName} has worked for {numberOfHours} hour(s)");
		}

		public double ReceiveWage(bool resetHours = true)
		{
			double wageBeforeTax = 0.0;

			int bonus = CalculateBonusAndBonusTax(minBonus, ref bonusTax);
            wageBeforeTax = NumberOfHoursWorked * HourlyRate.Value + bonus; // <-- using the .Value method to check if the hourlyRate is hold a double or a null value.

			double taxAmount = wageBeforeTax * taxRate;
			Wage = wageBeforeTax - taxAmount;

			Console.WriteLine($"{FirstName} {LastName} has received a wage of {Wage} for {NumberOfHoursWorked} hour(s) of work");

			if (resetHours) NumberOfHoursWorked = 0;

			return Wage;
		}

		public int CalculateBonus(int bonus)
		{
			if (NumberOfHoursWorked > 10)
				bonus *= 2;

			Console.WriteLine($"The employee worked {NumberOfHoursWorked} got a bonus of {bonus}");
			return bonus;
		}

		public int CalculateBonusAndBonusTax(int bonus, ref int bonusTax)
		{
			if (NumberOfHoursWorked > 10)
				bonus *= 2;

			if (bonus >= 200)
			{
				bonusTax = bonus / 10;
				bonus -= bonusTax;
			}

			Console.WriteLine($"The employee got a bonus of {bonus} and the tax on the bonus is {bonusTax}");
			return bonus;
		}

		public double CalculateWage()
		{
			WageCalculations wageCalculations = new WageCalculations();
			double calculatedValue = wageCalculations.ComplexWageCalculation(wage, taxRate, 3, 42);
			return calculatedValue;
		}

		public void DisplayEmployeeDetails()
		{
			Console.WriteLine($"\nFirst Name: \t{FirstName}\nLast Name: \t{LastName}\nEmail: \t{Email}\nBirthday: \t{BirthDay.ToShortDateString()}\nTax Rate: \t{taxRate}");
		}

		public virtual void GiveBonus()
		{
			Console.WriteLine($"Employee {FirstName} {LastName} received a generic bonus of 100!");
		}

        public void GiveCompliment()
        {
            Console.WriteLine($"You have done a great job, {FirstName}");
        }
    }
}

