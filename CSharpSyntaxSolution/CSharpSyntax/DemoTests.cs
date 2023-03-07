using System.ComponentModel;

namespace CSharpSyntax
{
    public class DemoTests
    {
        [Fact] // Attribute (Decorator)
        public void Test1()
        {
            // Given
            int a = 20, b = 10;
            int answer;
            // When
            answer = a + b;
            // Then
            Assert.Equal(30, answer);
        }

        [Theory]
        [InlineData(10,20,30)]
        [InlineData(2,2,4)]
        [InlineData(10,2,12)]
        public void CanAddAnyTwoIntegers(int a, int b, int expected)
        {
            int answer = a + b;
            Assert.Equal(expected, answer);
        }

        [Fact]
        public void BasicOOPStuff()
        {
            string myName = "   Derek";
            string trimmedName = myName.TrimStart();

            Assert.Equal("Derek", trimmedName);
            Assert.Equal("   Derek", myName);

            Customer bob = new Customer();

            Assert.Equal(5000, bob.GetCurrentAvailableCredit());
            bob.IncreaseAvailableCredit(50, DateTimeOffset.Now);
            Assert.Equal(5050, bob.GetCurrentAvailableCredit());
        }
    }
}