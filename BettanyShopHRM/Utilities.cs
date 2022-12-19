using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettanyShopHRM.HR;

namespace BettanyShopHRM
{
    public class Utilities
    {
        //using a fild as static we can use it directly from the class without the need to instantiate an object
        private static string directory = @"C:\bettany_pie_shop\";
        private static string fileName = @"employees.txt";

        internal static void RegisterEmployee(List<Employee> employees)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Creating an Employee");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Which type of employee do you want to create?");
            Console.ResetColor();
            Console.WriteLine("1. Employee\n2. Manager\n3. Store Manager\n4. Researcher\n5. Junior Researcher");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your selection: ");
            Console.ResetColor();

            string employeeType = Console.ReadLine();
            int intEmployeeType = Int32.Parse(employeeType);

            if (intEmployeeType < 0 || intEmployeeType > 5)
            {
                Console.WriteLine("Invalid employee type");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the first name: ");
            Console.ResetColor();
            string firstName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter last name: ");
            Console.ResetColor();
            string lastName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter email: ");
            Console.ResetColor();
            string email = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter date of birth: ");
            Console.ResetColor();
            DateTime birthDay = DateTime.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the hourly rate: ");
            Console.ResetColor();
            double hourlyRate = double.Parse(Console.ReadLine());

            Employee employee = null;

            switch(intEmployeeType)
            {
                case 1:
                    employee = new Employee(firstName, lastName, email, birthDay, hourlyRate);
                    break;
                case 2:
                    employee = new Manager(firstName, lastName, email, birthDay, hourlyRate);
                    break;
                case 3:
                    employee = new StoreManager(firstName, lastName, email, birthDay, hourlyRate);
                    break;
                case 4:
                    employee = new Researcher(firstName, lastName, email, birthDay, hourlyRate);
                    break;
                case 5:
                    employee = new JuniorResearcher(firstName, lastName, email, birthDay, hourlyRate);
                    break;
            }

            employees.Add(employee);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Employee created!");
            Console.ResetColor();
        }

        internal static void CheckForExistingEmployeeFile()
        {
            string path = $"{directory}{fileName}";
            bool existingFileFound = File.Exists(path);

            if (existingFileFound)
            {
                Console.WriteLine("An existing file with employee data is found!"); 
            }
            else
            {
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Directory is ready for save data.");
                Console.ResetColor();
            }
        }

        internal static void ViewAllEmployees(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                employee.DisplayEmployeeDetails();
                Console.ResetColor();
            }
        }

        internal static void LoadEmployees(List<Employee> employees)
        {
            string path = $"{directory}{fileName}";
            if (File.Exists(path))
            {
                employees.Clear();

                string[] employeesAsString = File.ReadAllLines(path);
                for (int i = 0; i < employeesAsString.Length; i++)
                {
                    string[] employeeSplit = employeesAsString[0].Split(";");
                    string firstName = employeeSplit[0].Substring(employeeSplit[0].IndexOf(":") + 1);
                    string lastName = employeeSplit[1].Substring(employeeSplit[1].IndexOf(":") + 1);
                    string email = employeeSplit[2].Substring(employeeSplit[2].IndexOf(":") + 1);
                    DateTime birthDay = DateTime.Parse(employeeSplit[3].Substring(employeeSplit[3].IndexOf(":") + 1));
                    double hourlyRate = double.Parse(employeeSplit[4].Substring(employeeSplit[4].IndexOf(":") + 1));
                    string employeeType = employeeSplit[5].Substring(employeeSplit[5].IndexOf(":") + 1);

                    Employee employee = null;

                    switch (employeeType)
                    {
                        case "1":
                            employee = new Employee(firstName, lastName, email, birthDay, hourlyRate);
                            break;
                        case "2":
                            employee = new Manager(firstName, lastName, email, birthDay, hourlyRate);
                            break;
                        case "3":
                            employee = new StoreManager(firstName, lastName, email, birthDay, hourlyRate);
                            break;
                        case "4":
                            employee = new Researcher(firstName, lastName, email, birthDay, hourlyRate);
                            break;
                        case "5":
                            employee = new JuniorResearcher(firstName, lastName, email, birthDay, hourlyRate);
                            break;
                    }

                    employees.Add(employee);

                    Console.ForegroundColor = ConsoleColor.Green;
                    //Console.WriteLine($"Loaded {employees.Count} employees!");
                    Console.ResetColor();
                }
            }

        }

        internal static void SaveEmployee(List<Employee> employees)
        {
            string path = $"{directory}{fileName}";
            StringBuilder sb = new StringBuilder();
            foreach (Employee employee in employees)
            {
                string type = GetEmployeeType(employee);
                sb.Append($"firstName:{employee.FirstName};");
                sb.Append($"lastName:{employee.LastName};");
                sb.Append($"email:{employee.Email};");
                sb.Append($"birthDay:{employee.BirthDay.ToShortDateString()};");
                sb.Append($"hourlyRate:{employee.HourlyRate};");
                sb.Append($"Employee type:{type};");

                sb.Append(Environment.NewLine);
            }
            File.WriteAllText(path, sb.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The employee data has beem saved!");
            Console.ResetColor();
        }

        private static string GetEmployeeType(Employee employee)
        {
            if (employee is Manager)
                return "2";
            else if (employee is StoreManager)
                return "3";
            else if (employee is Researcher)
                return "4";
            else if (employee is JuniorResearcher)
                return "5";
            else if (employee is Employee)
                return "1";
            return "0";
        }

        internal static void LoadEmployeeById(List<Employee> employees)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter the Employee ID you want to visualize: ");
                Console.ResetColor();

                int selectedId = int.Parse(Console.ReadLine());
                Employee selectedEmployee = employees[selectedId];
                selectedEmployee.DisplayEmployeeDetails();
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That's not the correct format to enter an ID \n");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ResetColor();
            }
            
        }

        //internal static string TypeOfEmployee(string employeeType)
        //{
        //    string formatedEmployeeType = employeeType.IndexOf(()
        //    return employeeType;
        //}
    }
}
