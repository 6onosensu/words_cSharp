using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace words
{
    public class ClassMain
    {
        private const string PATH = @"C:\Users\opilane\source\repos\suhhanova\words\";
        private const string PATH2 = @"C:\work\words_cSharp\";
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<string> rusWords = new();
            List<string> engWords = new();

            ClassMain.GetFromFile(rusWords, "ruswords.txt");
            ClassMain.GetFromFile(engWords, "engwords.txt");

            if (engWords.Count != rusWords.Count)
            {
                Console.WriteLine("The lists do not have the same number of words.");
                return;
            }

            /*
             for (int i = 0; i < rusWords.Count; i++)
            {
                Console.WriteLine(rusWords[i]);
            }

            for (int i = 0; i < engWords.Count; i++)
            {
                Console.WriteLine(engWords[i]);
            }
            */

            while (true)
            {
                Console.WriteLine("Enter a word to translate (type 'exit' to quit):");
                string input = Console.ReadLine().ToLower();
                if (input == "exit") 
                { 
                    break;
                }

                int index1 = rusWords.IndexOf(input);

                Console.WriteLine(input);
                if (index1 != -1)
                {
                    Console.WriteLine("English: " + engWords[index1]);
                    continue;
                }
               
                int index2 = engWords.IndexOf(input);
                if (index2 != -1)
                {
                    Console.WriteLine("Russian: " + rusWords[index2]);
                    continue;
                }
               
                Console.WriteLine("Word not found: " + input);
            }
        }

        private static void GetFromFile(List<string> list, string fileName)
        {
            try
            {
                foreach (string row in File.ReadAllLines(PATH2 + fileName ))
                {
                    list.Add(row.ToLower());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error with the file!");
            }
        }
    }
}