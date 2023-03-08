
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        if (String.IsNullOrEmpty(numbers)) return 0;
        var arrayNumbers = numbers.Split(',','\n');
        try
        {
            int.Parse(arrayNumbers[0]);
        } catch (FormatException)
        {
            var custom = arrayNumbers[0][2];
            arrayNumbers = numbers.Split(',','\n',custom);
            arrayNumbers = arrayNumbers[2..arrayNumbers.Length];
        }
        var sum = 0;
        for (int i = 0; i < arrayNumbers.Length; i++)
        {
            var currentNumber = int.Parse(arrayNumbers[i]);
            if (currentNumber < 0) throw new InvalidOperationException();
            sum += int.Parse(arrayNumbers[i]);
        }
        return sum;
    }
}
