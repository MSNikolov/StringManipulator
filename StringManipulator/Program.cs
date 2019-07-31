using System;
using System.Collections.Generic;

namespace StringManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "";

            var input = Console.ReadLine().Split();

            while(input[0] != "End")
            {
                switch(input[0])
                {
                    case "Add":
                        for (int i = 1; i < input.Length; i++)
                        {
                            text += input[i];
                        }
                        break;
                    case "Upgrade":
                        var retext = text.ToCharArray();
                        for (int i = 0; i < retext.Length; i++)
                        {
                            if (retext[i] == char.Parse(input[1]))
                            {
                                retext[i] = (char)(char.Parse(input[1]) + 1);
                            }
                        }
                        text = "";
                        foreach (var item in retext)
                        {
                            text += item;
                        }
                        break;
                    case "Print":
                        Console.WriteLine(text);
                        break;
                    case "Index":
                        var indeces = new List<int>();
                        for (int i = 0; i < text.Length; i++)
                        {
                            if (text[i] == char.Parse(input[1]))
                            {
                                indeces.Add(i);
                            }
                        }
                        if (indeces.Count == 0)
                        {
                            Console.WriteLine("None");
                        }
                        else
                        {
                            Console.WriteLine(string.Join(' ', indeces));
                        }
                        break;
                    case "Remove":
                        var result = text.Split(input[1]); // Е тука се получи много яко - трябва да триеш всички срещани случаи в стринга - опиши го в github!!
                        text = "";
                        foreach (var item in result)
                        {
                            text += item;
                        }
                        break;
                }

                input = Console.ReadLine().Split();
            }
        }
    }
}
