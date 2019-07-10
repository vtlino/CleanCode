using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanCode
{
    class Program
    {
        private const int LIMIT_INFERIOR = 1;
        private const int LIMIT_SUPERIOR = 3;
        private const int INDEX_TO_REMOVE = 1;

        static void Main(string[] args)
        {
            string fullWord = "Vinícius Terra Lino";

            var wordsSeparated = SeparateWordsBySpace(fullWord);
            var hasError = VerifyError(wordsSeparated);

            if (hasError)
            {
                Console.WriteLine("Contém Erro!");
                return;
            }

            var wordTreated = DoLogicalTreatment(wordsSeparated);

            Console.WriteLine(wordTreated);
            Console.Read();
        }

        private static List<string> SeparateWordsBySpace(string name)
        {
            return name.Split(" ").ToList();
        }

        private static bool VerifyError(List<string> wordsSeparated)
        {
            return wordsSeparated.Count < LIMIT_INFERIOR || wordsSeparated.Count > LIMIT_SUPERIOR;
        }

        private static string DoLogicalTreatment(List<string> wordsSeparated)
        {
            var wordsAreEven = VerifyIfIsEven(wordsSeparated.Count);
            var wordFormated = "";
            var characterCalculated = "";

            foreach (var word in wordsSeparated)
            {
                var index = 0;

                foreach (var character in word)
                {
                    characterCalculated = wordsAreEven ? CalculateCharForEvenWords(character, index) : CalculateCharForOddWords(character, index);
                    wordFormated += characterCalculated;

                    index++;
                }
                wordFormated += " ";
            }

            if (VerifyIfIsEven(wordFormated.Length))
                return wordFormated.Substring(INDEX_TO_REMOVE);
            else
                return wordFormated.Substring(wordFormated.Length - INDEX_TO_REMOVE);
        }

        private static bool VerifyIfIsEven(int number)
        {
            return number % 2 == 0;
        }

        private static string CalculateCharForEvenWords(char character, int index)
        {
            if (!VerifyIfIsEven(index))
                return character.ToString();

            return "";
        }

        private static string CalculateCharForOddWords(char character, int index)
        {
            if (VerifyIfIsEven(index))
                return character.ToString();

            return "";
        }
    }
}
