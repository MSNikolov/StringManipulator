using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmojiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var numbers = Console.ReadLine().Split(':').Select(int.Parse).ToArray();

            var emojiRegex = @"(?<= )[:][a-z][a-z][a-z][a-z]+[:](?=[,.!? ])";

            var decodedEmoji = "";

            for (int i = 0; i < numbers.Length; i++)
            {
                decodedEmoji += (char)numbers[i];
            }

            decodedEmoji = ':' + decodedEmoji + ':';

            var emojis = new List<string>();

            foreach (var item in Regex.Matches(text, emojiRegex))
            {
                emojis.Add(item.ToString());
            }

            var sum = 0;

            foreach (var item in emojis)
            {
                foreach (char letter in item)
                {
                    if (letter != ':')
                    {
                        sum += (int)letter;
                    }
                }
            }

            if (emojis.Contains(decodedEmoji))
            {
                sum *= 2;
            }

            if (emojis.Count != 0)

            Console.WriteLine($"Emojis found: {string.Join(", ", emojis)}");

            Console.WriteLine($"Total Emoji Power: {sum}");
        }
    }
}
