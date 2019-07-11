using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanCode
{
    class Program
    {
        private const int LIMIT_LOWER = 1;
        private const int LIMIT_UPPER = 3;
        private const int INDEX_TO_REMOVE = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome:");
            string fullWord = Console.ReadLine();

            var wordsSeparated = SeparateWordsBySpace(fullWord);
            var hasError = IsError(wordsSeparated);

            if (hasError)
            {
                Console.WriteLine("Contém Erro!");
                return;
            }

            var wordTreated = DoLogicalTreatment(wordsSeparated);

            Console.WriteLine();
            Console.WriteLine("Nome formatado:");
            Console.WriteLine(wordTreated);
            Console.Read();
        }

        private static List<string> SeparateWordsBySpace(string name)
        {
            return name.Split(" ").ToList();
        }

        private static bool IsError(List<string> wordsSeparated)
        {
            return ((wordsSeparated.Count == 1 && string.IsNullOrWhiteSpace(wordsSeparated.First())) || wordsSeparated.Count < LIMIT_LOWER || wordsSeparated.Count > LIMIT_UPPER);
        }

        private static string DoLogicalTreatment(List<string> wordsSeparated)
        {
            var wordsAreEven = IsEven(wordsSeparated.Count);
            var wordFormated = "";
            var characterCalculated = "";

            foreach (var word in wordsSeparated)
            {
                var index = 0;

                foreach (var character in word)
                {
                    characterCalculated = wordsAreEven ? CalculateCharacterForEvenWords(character, index) : CalculateCharacterForOddWords(character, index);
                    wordFormated += characterCalculated;

                    index++;
                }
                wordFormated += " ";
            }
            wordFormated = RemoveLastCharacter(wordFormated);

            if (IsEven(wordFormated.Length))
                return wordFormated.Substring(INDEX_TO_REMOVE);
            else
                return RemoveLastCharacter(wordFormated);
        }

        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        private static string CalculateCharacterForEvenWords(char character, int index)
        {
            if (IsEven(index))
                return character.ToString();

            return "";
        }

        private static string CalculateCharacterForOddWords(char character, int index)
        {
            if (!IsEven(index))
                return character.ToString();

            return "";
        }

        private static string RemoveLastCharacter(string word)
        {
            return word.Remove(word.Length - INDEX_TO_REMOVE);
        }
    }
}
