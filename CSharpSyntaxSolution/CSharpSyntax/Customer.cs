namespace CSharpSyntax
{
    public class Customer
    {
        private decimal _availableCredit = 5000;
        /// <summary>
        /// Gets the current credit limit for the Customer
        /// </summary>
        /// <returns>Actual current credit limit</returns>
        public decimal GetCurrentAvailableCredit()
        {
            return _availableCredit;
        }

        public void IncreaseAvailableCredit(decimal amount, DateTimeOffset effective)
        {
            _availableCredit += amount;
        }
    }
}
