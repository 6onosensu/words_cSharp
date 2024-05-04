using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace words
{
    public class ClassMain
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            string path = @"C:\Users\opilane\source\repos\suhhanova\words\";
            string path2 = @"C:\work\words_cSharp\";

            List<string> rusWords = new List<string>();
            List<string> engWords = new List<string>();

            try
            {
                foreach (string row in File.ReadAllLines(path2 + "ruswords.txt"))
                {
                    rusWords.Add(row.ToLower());
                }
                foreach (string row in File.ReadAllLines(path2 + "engwords.txt"))
                {
                    engWords.Add(row.ToLower());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error with the file!");
            }

            if (engWords.Count != rusWords.Count)
            {
                Console.WriteLine("The lists do not have the same number of words.");
                return;
            }

            for (int i = 0; i < rusWords.Count; i++)
            {
                Console.WriteLine(rusWords[i]);
            }

            for (int i = 0; i < engWords.Count; i++)
            {
                Console.WriteLine(engWords[i]);
            }

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
    }
}