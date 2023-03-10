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
        var calculator = new StringCalculator(mockedLogger.Object, new Mock<IWebService>().Object);
        
        calculator.Add(numbers);

        // Did the calculator call the write method on the logger with the value 6?
        mockedLogger.Verify(m => m.Write(expected), Times.Once);
    }

    [Theory]
    [InlineData("1", "Logging failed")]
    //[InlineData("2", "Logging failed")]
    public void WebServiceIsNotifiedIfLoggerFails(string numbers, string expMsg)
    {
        var stubbedLogger = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        stubbedLogger.Setup(logger => logger.Write("1")).Throws<LoggingException>();
        var calculator = new StringCalculator(stubbedLogger.Object, mockedWebService.Object);

        calculator.Add(numbers);

        mockedWebService.Verify(m => m.LoggingFailed(expMsg));
    }

    [Fact]
    public void TheWebServiceNotCalledNoException()
    {
        var stubbedLogger = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(stubbedLogger.Object, mockedWebService.Object);

        calculator.Add("1");

        mockedWebService.Verify(m => m.LoggingFailed(It.IsAny<string>()), Times.Never);
    }
}
