using TelegramBot_11._6.Services;

namespace TelegramBot_11._6.Utilities
{
    public static class SumNumbers
    {
        public static string Sum(string text )
        {
            int summ = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsNumber(text[i]))
                {
                    summ += Convert.ToInt32(text[i].ToString());
                }
            }
            return summ.ToString();
        }


    }
}
