using FluentAssertions;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomerWhenIdZeroReturnNotFound()
        {

            //Arrange
            //Act
            var controller = new CustomerController();
            var result = controller.GetCustomer(0);
            //Assert
            result.Should().NotBeNull().And.BeOfType<NotFound>();
            result.Should().BeOfType<NotFound>();
            // typeoOf requires the type NotFound
            // InstanceOf requires type NotFound or its derivatives
        }

        [Test]
        public void GetCustomerWhenIdNotZeroReturnNotFound()
        {
            //Arrange
            //Act
            var controller = new CustomerController();
            var result = controller.GetCustomer(1);
            //Assert
            result.Should().BeAssignableTo<ActionResult>();
            result.Should().BeAssignableTo<Ok>();
            // typeoOf requires the type NotFound
            // InstanceOf requires type NotFound or its derivatives
        }
    }
}
