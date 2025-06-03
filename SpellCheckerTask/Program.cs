using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System;

namespace SpellCheckerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = createDictionary();
            //1. Take a user input of a word an check if it has been spelled correctly

            //2. Take a string of words as a user input and check they have all been spelled correctly

            //3.Create a spelling score based on the percentage of words spelled correctly

            //4.Create a new list of words that have been spelled incorrectly and save it in a new file

            //Challenge - Hard task

            //Try to work out which words the user is trying to spell by looking for similarities in
            //the spelling and ask the user did they mean that.

            //Add these suggested words to a spelling list that the user can save as a file to work on
            //their own spelling

            Console.WriteLine("enter a word");
            string userWord = Console.ReadLine();
            string[] dictionary = createDictionary();
            int incorrectNoWords = 0;
            

            try
            {
                dictionary = File.ReadAllLines("WordsFile.txt").ToArray();
            }
            catch
            {
                Console.WriteLine("couldnt load");
                return;
            }
         
            Console.WriteLine("enter word");
            string singleWord = Console.ReadLine();

            if (dictionary.Contains(singleWord))
            {
                Console.WriteLine("correct");
            }
            else
            {
                Console.WriteLine("incorrect");
            }


            Console.WriteLine("enter sentence");
            string sentence = Console.ReadLine();
            string[] splitSentence = sentence.Split(' ');
            string[] incorrectWords = new string[][];

            foreach (string word in splitSentence)
            {
                if (!dictionary.Contains(word))
                {
                    incorrectNoWords++;
                    incorrectWords.Add(word);
                }
            }

            


            if (sentence.Length > 0)
            {
                double score = (sentence.Length - incorrectNoWords) * 100.0 / sentence.Length;
                Console.WriteLine($"Spelling score: {score:F1}% correct");
            }

            if (incorrectNoWords > 0)
            {
                File.WriteAllLines("IncorrectWords.txt");
                File.WriteAllText("IncorrectWords.txt", incorrectWords);
                Console.WriteLine($"Saved {incorrectNoWords} incorrect words to file.");
            }
            else
            {
                Console.WriteLine("All words spelled correctly!");
            }

        }
    }


    static string[] createDictionary()
    {
        {
            using StreamReader words = new("WordsFile.txt");
            int count = 0;
            string[] dictionaryData = new string[178636];
            while (!words.EndOfStream)
            {

                dictionaryData[count] = words.ReadLine();
                count++;
            }
            words.Close();
            return dictionaryData;
        }
    }

        }
        static string[] createDictionary()
        {
            using StreamReader words = new("WordsFile.txt");
            int count = 0;
            string[] dictionaryData = new string[178636];
            while (!words.EndOfStream)
            {

                dictionaryData[count] = words.ReadLine();
                count++;
            }
            words.Close();
            return dictionaryData;
        }
    }
}
