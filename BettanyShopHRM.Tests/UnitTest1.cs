using BettanyShopHRM.HR;

namespace BettanyShopHRM.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void PerformWork_Adds_NumberOfHours()
        {
            //Arrange
            Employee employee = new Employee("Thomas", "Alvarenga", "thominhas@alva.com", new DateTime(2022, 7, 12), 50);

            int numberOfHours = 3;
            //Act
            employee.PerformWork(numberOfHours);

            //Assert
            Assert.Equal(numberOfHours, employee.NumberOfHoursWorked);
        }

        [Fact]
        public void PerformWork_Adds_DefaultNumberOfHours_IfNoValueSpecified()
        {
            //Arrange
            Employee employee = new Employee("Thomas", "Alvarenga", "thominhas@alva.com", new DateTime(2022, 7, 12), 50);

            //Act
            employee.PerformWork();

            //Assert
            Assert.Equal(1, employee.NumberOfHoursWorked);
        }
    }
}