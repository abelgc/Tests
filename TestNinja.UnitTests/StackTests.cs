using FluentAssertions;
using TestNinja.Fundamentals;


namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {

        [Test]
        public void PushWhenInputIsNullShouldThrowArgumentNullException()
        {
            // Arrange
            var stack = new Fundamentals.Stack<string?>();
            // Act
            // Assert
            //Assert.That(() => stack.Push(null), Throws.ArgumentNullException);

            stack
                .Invoking(stk => stk.Push(null))
                .Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null.*");
        }

        [Test]
        public void PushWhenInputIsNotNullShouldIncreaseCount()
        {
            // Arrange
            var stack = new Fundamentals.Stack<string>();
            // Act
            stack.Push("Item1");
            stack.Push("Item1");
            // Assert
            stack.Count.Should().Be(2);
        }

        [Test]
        public void PeekWhenStackIsNotEmptyShouldReturnLastItemAndNotChangeCount()
        {
            // Arrange
            var stack = new Fundamentals.Stack<string>();
            // Act
            stack.Push("Item1");
            stack.Push("Item2");
            stack.Peek();
            // Assert
            stack.Count.Should().Be(2);
        }

        [Test]
        public void PopWhenStackIsNotEmptyShouldReturnLastItemAndChangeCount()
        {
            // Arrange
            var stack = new Fundamentals.Stack<string>();
            // Act
            stack.Push("Item1");
            stack.Push("Item2");
            stack.Pop();
            // Assert
            stack.Count.Should().Be(1);
        }
    }
}
