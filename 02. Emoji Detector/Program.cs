using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace Problem_02
{
    class Program
    {
        static void Main()
        {

            List<string> emList = new List<string>();
            string inputText = Console.ReadLine();

            Regex numPattern = new Regex(@"[0-9]");
            MatchCollection numbers = numPattern.Matches(inputText);
            BigInteger maxSum = 1;

            for (int i = 0; i < numbers.Count; i++)
            {
                int number = int.Parse(numbers[i].Value);
                maxSum *= number;
            }

            Regex pattern = new Regex(@"(\:{2}|\*{2})([A-Z][a-z]{2,})(\1)");
            MatchCollection emojies = pattern.Matches(inputText);

            int emojiCount = 0;

            foreach (Match match in emojies)
            {

                string validEmoji = match.Value;
                BigInteger coolLevel = 0;
                emojiCount++;

                foreach (var symbol in validEmoji)
                {
                    if (symbol >= 'a' && symbol <= 'z' || symbol >= 'A' && symbol <= 'Z')
                    {
                        coolLevel += (int)symbol;
                    }
                }
                if (coolLevel >= maxSum)
                {
                    emList.Add(validEmoji);
                }

            }
            if (emojiCount != 0)
            {
                Console.WriteLine($"Cool threshold: {maxSum}");
                Console.WriteLine($"{emojiCount} emojis found in the text. The cool ones are:");
                foreach (string emoji in emList)
                {
                    Console.WriteLine(emoji);
                }
            }
        }
    }
}
