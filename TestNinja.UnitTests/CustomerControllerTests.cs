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
            result.Should().BeAssignableTo<ActionResult>();

        }

        [Test]
        public void GetCustomerWhenIdNotZeroReturnNotFound()
        {

        }
    }
}
