
namespace StringCalculator;

public class StringCalculator
{
    private readonly ILogger _logger;
    private readonly IWebService _webService;

    public StringCalculator(ILogger logger, IWebService webService)
    {
        _logger = logger;
        _webService = webService;
    }

    public int Add(string numbers)
    {
        var total = numbers == "" ? 0 :
            numbers.Split(',', '\n')
            .Select(int.Parse)
            .Sum();

        try
        {
            _logger.Write(total.ToString());
        }
        catch (LoggingException)
        {
            // Write the code you wish you had
            _webService.LoggingFailed("Logging failed");
        }
        return total;
    }
}
public interface IWebService
{
    void LoggingFailed(string message);
}
