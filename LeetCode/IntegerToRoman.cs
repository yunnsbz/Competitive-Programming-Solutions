namespace IntegerToRoman
{
    internal class IntegerToRoman
    {
        static Dictionary<int, string> RomanMap = new Dictionary<int, string>()
        {
            {1000, "M"},
            {900, "CM" },
            {500, "D"},
            {400, "CD" },
            {100, "C"},
            {90, "XC" },
            {50, "L"},
            {40, "XL" },
            {10, "X"},
            {9, "IX" },
            {5, "V"},
            {4, "IV" },
            {1, "I"},
        };


        /// <summary>
        /// recursive integer to roman calculation
        /// </summary>
        /// <param name="num">previous number used in calculation</param>
        /// <param name="currentDigit"> new digit to work with</param>
        /// <param name="romanOutput"> output of previous recursion</param>
        /// <returns>output of this recursion</returns>
        static string IntegerToRomanRec(int num, int currentDigit, string romanOutput)
        {
            // calculate current num to work with
            num %= (int)Math.Pow(10, currentDigit);
            
            foreach (var map in RomanMap)
            {
                // to finding the appropriate roman number with right dicig count inside the map
                if (map.Key / Math.Pow(10, currentDigit - 1) < 1) continue;

                if (num / map.Key >= 1)
                {
                    int count = num / map.Key;

                    num -= count * map.Key;

                    for (int i = 0; i < count; i++)
                        romanOutput += map.Value;
                }
            }
            currentDigit--;
            if (currentDigit == 0) return romanOutput;
            return IntegerToRomanRec(num, currentDigit, romanOutput);
        }

        /// <summary>
        /// main function to calculate Int to Roman
        /// </summary>
        /// <param name="num">number to convert</param>
        /// <returns>number converted to Roman</returns>
        static string IntToRoman(int num)
        {
            string romanOutput = "";

            int currentDigit = num / 1000 >= 1 ? 4 : (num / 100 >= 1 ? 3 : (num / 10 >= 1 ? 2 : 1));

            return IntegerToRomanRec(num, currentDigit, romanOutput);
        }


        static void Main(string[] args)
        {
            while (true)
            {
                string? input = Console.ReadLine();
                int num = 0;
                try
                {
                    num = int.Parse(input);
                    if (num < 1 || num > 3999)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 3999.");
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a valid number. (between 1 and 3999)");
                    continue;
                }
                Console.WriteLine(IntToRoman(num));
            }
        }
    }
}
