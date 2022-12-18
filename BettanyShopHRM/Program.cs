using System.Text;
using BettanyShopHRM;
using BettanyShopHRM.HR;

List<Employee> employees = new List<Employee>();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("***********************************");
Console.WriteLine("* Bettany's Pie Shop Employee App *");
Console.WriteLine("***********************************");
Console.ForegroundColor = ConsoleColor.White;

int userSelection;

Console.ForegroundColor = ConsoleColor.Blue;

Utilities.CheckForExistingEmployeeFile();

do
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Loaded {employees.Count} employe(s)\n\n");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("********************");
    Console.WriteLine("* Select an Action *");
    Console.WriteLine("********************");
    Console.ResetColor();

    Console.WriteLine("1: Register employee");
    Console.WriteLine("2: View all employees");
    Console.WriteLine("3: Save data");
    Console.WriteLine("4: Load data");
    Console.WriteLine("9: Quit application");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Your selection: ");
    Console.ResetColor();

    userSelection = Int32.Parse(Console.ReadLine());

    switch (userSelection)
    {
        case 1:
            Utilities.RegisterEmployee(employees);
            break;
        case 2:
            Utilities.ViewAllEmployees(employees);
            break;
        case 3:
            Utilities.SaveEmployee(employees);
            break;
        case 4:
            Utilities.LoadEmployees(employees);
            break;
        case 9: break;
    }
} while (userSelection != 9);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("************************************");
Console.WriteLine("* Thanks for using the application *");
Console.WriteLine("************************************");
Console.ResetColor();



// ---- ↓↓↓↓↓↓↓↓↓↓↓↓ ALL CODE BELOW WAS USED DURING THE COURSE TO INTRODUCE THE LANGUAGE FEATURES UNTIL FINALLY CREATING THE REAL APPLICATION

/*Console.WriteLine("Creating an employee");
Console.WriteLine("----------\n");*/

// ---------- ↓↓↓↓ INSTANTIATING OBJECTS USING ITS RESPECTIVE TYPES ↓↓↓↓
    /*StoreManager marcos = new StoreManager("Marcos", "Smith", "marc@snowball.be", new DateTime(1992, 1, 24), 25);
    Developer july = new Developer("July", "Belly", "belly@jj.com", new DateTime(1981, 2, 5), 40);*/
// ---------- ↑↑↑↑ INSTANTIATING OBJECTS USING ITS RESPECTIVE TYPES ↑↑↑↑


// ---------- ↓↓↓↓ INSTANTIATING OBJECTS USING BASE TYPE REFFERENCE ↓↓↓↓
   /* Employee bethany = new StoreManager("Bethany", "Smith", "bethany@snowball.be", new DateTime(1992, 1, 24), 25);
    Employee george = new Developer("George", "Lucas", "george@lucas.com", new DateTime(1981, 2, 5), 40);
    Employee mary = new Researcher("Mary", "Brave", "mb@studio.com", new DateTime(1992, 1, 24), 30);
    Employee bobJunior = new JuniorResearcher("Bob", "Junior", "bobjunior@bob.com", new DateTime(2000, 3, 20), null);
    Employee kevin = new StoreManager("Kevin", "Bacon", "kavinbacon@gg.com", new DateTime(1987, 2, 25), 80);*/
// ---------- ↑↑↑↑ INSTANTIATING OBJECTS USING BASE TYPE REFFERENCE ↑↑↑↑


// ---------- ↓↓↓↓ INSTANTIATING OBJECTS USING INTERFACE REFFERENCE ↓↓↓↓
    /*IEmployee bruno = new Researcher("Bruno", "Gay", "bg@falabosta.com", new DateTime(1992, 1, 24), 30);
    IEmployee fabiano = new JuniorResearcher("Fabiano", "Marmita", "paumandado@doido.com", new DateTime(2000, 3, 20), null);
    IEmployee cadu = new StoreManager("Carlos", "Eduardo", "paidobeni@nfl.com", new DateTime(1987, 2, 25), 80);*/
// ---------- ↑↑↑↑ INSTANTIATING OBJECTS USING INTERFACE REFFERENCE ↑↑↑↑


// ---------- ↓↓↓↓ CREATING USERS TO WORK WITH INHERITANCE ↓↓↓↓
    /*Manager helton = new Manager("Helton", "Oliveira", "helton@p30.dev", new DateTime(1992, 1, 24), 100);
    helton.AttendManagementMeeting();

    Developer thomas = new Developer("Thomas", "Oliveira", "thominhas@p30.dev", new DateTime(2022, 7, 12), 200);
    thomas.CurrentProjet = "Create a Portfolio";
    Console.WriteLine(thomas.CurrentProjet);

    Researcher laiz = new Researcher("Laiz", "Alvarenga", "laiztaste@pie.com", new DateTime(1994, 6, 7), 150);
    Console.WriteLine(laiz.NumberOfPieTasteInvented);
    laiz.ResearchNewPieTaste(44);*/
// ---------- ↑↑↑↑ CREATING USERS TO WORK WITH INHERITANCE ↑↑↑↑


// ---------- ↓↓↓↓ CREATING A USER TO APPLY POLIMORPHISM IN ONE OF THE METHODS (USING BASE TYPE REFFERENCE) ↓↓↓↓
    /*Employee jake = new Manager("Jake", "Blake", "jk@jk.com", new DateTime(1985, 5, 26), 35, "Rua Itaperuna", "150", "28030350", "Campos");
    jake.ShowAdress();
    jake.GiveBonus();*/
// ---------- ↑↑↑↑ CREATING A USER TO APPLY POLIMORPHISM IN ONE OF THE METHODS (USING BASE TYPE REFFERENCE) ↑↑↑↑


// ---------- ↓↓↓↓ CREATING A LIST OF EMPLOYEES AND LOOPING OVER IT TO SEE THE POLYMORPHISM EFFECT ↓↓↓↓
    /*List<Employee> employessList = new List<Employee>(6) { bethany, george, mary, bobJunior, kevin, jake};

    foreach (Employee employee in employessList )
    {
        employee.DisplayEmployeeDetails();
        employee.GiveBonus();
    }*/
// ---------- ↑↑↑↑ CREATING A LIST OF EMPLOYEES AND LOOPING OVER IT TO SEE THE POLYMORPHISM EFFECT ↑↑↑↑


/*for   (int i = 0; i < employees.Length; i++)
{
    employees[i].DisplayEmployeeDetais();
}

foreach (Employee e in employees)
{
    e.DisplayEmployeeDetais();
    var numberOfHoursWorked = new Random().Next(25);
    e.PerformWork(numberOfHoursWorked);
    e.ReceiveWage();
}*/


// ---------- ↓↓↓↓ START CREATING AN ARRAY OF EMPLOYEES IDS AND APPLYING METHODS ↓↓↓↓

/*Console.WriteLine("How many employees IDs do you want to register?");
int length = int.Parse(Console.ReadLine());

int[] employeesId = new int[length];

for (int i = 0; i < length; i++)
{
    Console.WriteLine("Enter the employee ID: ");
    int id = int.Parse(Console.ReadLine());
    employeesId[i] = id;
}

for (int i = 0; i < employeesId.Length; i++)
{
    Console.WriteLine($"ID {i + 1}: {employeesId[i]}");
}

Array.Sort(employeesId);

for (int i = 0; i < employeesId.Length; i++)
{
    Console.WriteLine($"ID {i + 1}: {employeesId[i]}");
}

int[] employeeId2 = new int[length];
employeesId.CopyTo(employeeId2, 0);

Array.Reverse(employeesId);

Console.WriteLine("Employee 1 - IDs:");
for (int i = 0; i < employeesId.Length; i++)
{
    Console.WriteLine($"ID {i + 1}: {employeesId[i]}");
}
Console.WriteLine("Employee 2 - IDs:");
for (int i = 0; i < employeesId.Length; i++)
{
    Console.WriteLine($"ID {i + 1}: {employeeId2[i]}");
}*/
// ---------- ↑↑↑↑ END CREATING AN ARRAY OF EMPLOYEES IDS AND APPLYING METHODS ↑↑↑↑


// ---------- ↓↓↓↓ START CREATING A LIST (COLLECTION) OF EMPLOYEES IDS ↓↓↓↓
/*List<int> employeeIdsList = new List<int>();
Console.WriteLine("Enter how many id you want to generate: ");
int idsCount = int.Parse(Console.ReadLine());

for (int i = 0; i < idsCount; i++)
{
    Console.WriteLine("Enter the id: ");
    employeeIdsList.Add(int.Parse(Console.ReadLine()));
}
Console.WriteLine("The current ids: ");
for (int i = 0; i < employeeIdsList.Count; i++)
{
    Console.WriteLine($"{employees[i].FirstName} ID:\t{employeeIdsList[i]}");
}*/
// ---------- ↑↑↑↑ END CREATING A LIST (COLLECTION) OF EMPLOYEES IDS ↑↑↑↑


//bethany.DisplayEmployeeDetais();

//bethany.PerformWork(15);
//bethany.PerformWork(5);
//bethany.PerformWork(10);
//bethany.PerformWork(10);

//WorkTask task;
//task.description = "Bake delicious pies";
//task.hours = 3;
//task.PerformWorkTask();

//bethany.ReceiveWage();

//int minBonus = 100;
//int receivedBonus = bethany.CalculateBonus(minBonus);
//Console.WriteLine($"The minimum bonus is {minBonus} and {bethany.firstName} has received a bonus of {receivedBonus}");

//int minBonus = 100;
//int bonusTax = 0;
//int receivedBonus = bethany.CalculateBonusAndBonusTax(minBonus, ref bonusTax);
//Console.WriteLine($"The minimum bonus is {minBonus}, the bonus tax is {bonusTax} and {bethany.firstName} has received a bonus of {receivedBonus}");

//Employee george = new("Geroge", "Lucas", "lucasfilm@disney.com", new DateTime(1971, 2, 18), 57);

//george.DisplayEmployeeDetais();
//george.PerformWork(50);
//george.PerformWork(40);
//george.ReceiveWage();

//george.birthDay = new DateTime(1972, 4, 19);
//george.email = "george@lucasfilm.com";
//george.DisplayEmployeeDetais();

//StringBuilder builder = new StringBuilder();

//builder.Append("My name is: ");
//builder.Append("Helton");
//Console.WriteLine(builder);
//string myName = builder.ToString();
//Console.WriteLine(myName);

//string jsonBethany = bethany.ConvertToJSON();
//Console.WriteLine(jsonBethany);

//double bethWage = bethany.CalculateWage();
//Console.WriteLine(bethWage);
//Console.ReadLine();