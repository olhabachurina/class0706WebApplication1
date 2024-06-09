namespace class0706WebApplication1
{
    public static class NumberToWordsHelper
    {
        private static readonly string[] Ones = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private static readonly string[] Teens = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static readonly string[] Tens = { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static readonly string[] Thousands = { "", "thousand", "million", "billion" };

        public static string ConvertToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + ConvertToWords(Math.Abs(number));

            string words = "";

            int thousandIndex = 0;

            while (number > 0)
            {
                int chunk = number % 1000;
                if (chunk > 0)
                {
                    string chunkInWords = ConvertChunkToWords(chunk);
                    words = chunkInWords + (Thousands[thousandIndex] != "" ? " " + Thousands[thousandIndex] : "") + (words != "" ? " " + words : "");
                }

                thousandIndex++;
                number /= 1000;
            }

            return words.Trim();
        }

        private static string ConvertChunkToWords(int number)
        {
            string words = "";

            if (number >= 100)
            {
                words += Ones[number / 100] + " hundred ";
                number %= 100;
            }

            if (number >= 20)
            {
                words += Tens[number / 10 - 1] + " ";
                number %= 10;
            }

            if (number >= 11 && number <= 19)
            {
                words += Teens[number - 11] + " ";
            }
            else if (number == 10)
            {
                words += Tens[0] + " ";
            }
            else if (number > 0 && number < 10)
            {
                words += Ones[number] + " ";
            }

            return words.Trim();
        }
    }
}    