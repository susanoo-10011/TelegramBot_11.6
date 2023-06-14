namespace TelegramBot_11._6.Utilities
{
    public static class SumNumbers
    {
        public static string Sum(string text)
        {
            string[] numbers = text.Split(' ');

            int sum = 0;

            foreach (string number in numbers)
            {
                int parsedNumber;
                if (int.TryParse(number, out parsedNumber))
                    sum += parsedNumber;
            }
            return sum.ToString();
        }
    }
}
