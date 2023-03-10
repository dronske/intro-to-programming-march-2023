namespace StringCalculator;

public class StringCalculatorInteractionTests
{
    [Theory]
    [InlineData("1,2,3","6")]
    [InlineData("42","42")]
    [InlineData("","0")]
    public void ResultsAreLogged(string numbers, string expected)
    {
        var mockedLogger = new Mock<ILogger>();
        var calculator = new StringCalculator(mockedLogger.Object);
        
        calculator.Add(numbers);

        // Did the calculator call the write method on the logger with the value 6?
        mockedLogger.Verify(m => m.Write(expected), Times.Once);
    }
}
