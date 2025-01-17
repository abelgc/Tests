using FluentAssertions;
using NSubstitute;
using TestNinja.Mocking;

namespace MockTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private IEmployeeService _employeeServiceMock;
        private EmployeeController _employeeController;

        [SetUp]
        public void Setup()
        {
            _employeeServiceMock = Substitute.For<IEmployeeService>();
            _employeeController = new EmployeeController(_employeeServiceMock);
        }


        [Test]
        public void WhenDeleteEmployeeDeletesEmployeeFromDb()
        {
            //Arrange
            var id = 2;

            // Act
            var result = _employeeController.DeleteEmployee(id);

            // Assert
            //Verify that the DeleteEmployee method on the IEmployeeService was called once with the correct ID.
            _employeeServiceMock.Received(1).DeleteEmployee(id);
            result.Should().BeOfType<RedirectResult>();


        }
    }
}
