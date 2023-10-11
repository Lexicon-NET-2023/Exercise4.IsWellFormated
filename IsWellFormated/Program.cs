using System;
using System.Collections.Generic;
using System.Linq;

namespace IsWellFormated
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Please enter a string to check!");
                var input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input)) 
                Console.WriteLine($"Wellformated: {IsWellFormated(input)}");

            } while (true);
        }

        //Solution 1
        private static bool IsWellFormated(string input)
        {
            Dictionary<char, char> dict = GetDict();

            var keyStack = new Stack<char>();

            foreach (var c in input)
            {
                if (keyStack.Count == 0 && dict.ContainsValue(c)) return false;
                if (dict.ContainsValue(c) && dict[keyStack.Pop()] != c) return false;
                if (dict.ContainsKey(c)) keyStack.Push(c);
            }

            return keyStack.Count == 0;
        }
        
        //Solution 2
        private static bool IsWellFormatedSimplefied(string input)
        {
            Dictionary<char, char> dict = GetDict();

            var keyStack = new Stack<char>();

            foreach (var currentChar in input)
            {
                if(dict.ContainsValue(currentChar))
                {
                     if(keyStack.Count == 0) 
                        return false; 
                     else
                     {
                        var lastKey = keyStack.Pop();
                        var lastValue = dict[lastKey];  
                        if(lastValue != currentChar)
                            return false;
                     }
                }
                if(dict.ContainsKey(currentChar)) 
                    keyStack.Push(currentChar);
            }

            return keyStack.Count == 0;
        }

        private static Dictionary<char, char> GetDict()
        {
            return new Dictionary<char, char>
            {
                { '{', '}' },
                { '(', ')' },
                { '[', ']' },
                { '<', '>' }
            };
        }
    }
}
