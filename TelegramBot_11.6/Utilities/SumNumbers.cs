using TelegramBot_11._6.Services;

namespace TelegramBot_11._6.Utilities
{
    public static class SumNumbers
    {
        public static string Sum(string text )
        {
            string[] numbers = text.Split(' ');

            int sum = 0;

            foreach (string number in numbers)
            {
                sum += int.Parse(number);
            }
            return sum.ToString();
        }


    }
}
