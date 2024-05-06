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

            var toRepeat = new Dictionary<string, string>();

            ClassMain.GetFromFile(rusWords, "ruswords.txt");
            ClassMain.GetFromFile(engWords, "engwords.txt");

            if (engWords.Count != rusWords.Count)
            {
                Console.WriteLine("The lists do not have the same number of words.");
                return;
            }

            while (true)
            {
                Console.WriteLine("Enter a word to translate (type 'exit' to quit OR type 'test ' and number of words to check knowledge):");
                string input = Console.ReadLine().ToLower();
                if (input == "exit")
                {
                    break;
                }
                else if (input.StartsWith("test"))
                {
                    List<string> splited = new(input.Split(" "));
                    try
                    {
                        int numOfWords = Int32.Parse(splited[1]);
                        ClassMain.TestWordKnowledge(rusWords, engWords, toRepeat, numOfWords);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You did not write a number of words!");
                    }
                }
                else if (input == "repeat")
                {
                    RepeatWords(toRepeat);
                }
                else
                {
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

        private static void RepeatWords(Dictionary<string, string> toRepeat)
        {
            foreach (KeyValuePair<string, string> kvp in toRepeat)
            {
                Console.WriteLine("{0} : {1}", kvp.Key, kvp.Value);
                toRepeat.Remove(kvp.Key);
            }

        }

        private static void TestWordKnowledge(List<string> rus, List<string> eng, Dictionary<string,string> toRepeat, int numOfWords = 10)
        {
            int correctAnswers = 0;
            Random rand = new();
            for (int i = 0; i < numOfWords; i++)
            {
                int index = rand.Next(0, rus.Count() - 1);
                string rusWord = rus[index];
                string engWord = eng[index];

                Console.WriteLine(rusWord);
                string input = Console.ReadLine().ToLower().Trim();

                if (input == engWord)
                {
                    correctAnswers++;
                }
                else
                {
                    toRepeat.Add(rusWord, engWord);
                    Console.WriteLine($"The correct answer is {engWord}!");
                }
            }
            decimal score = ((decimal)correctAnswers / (decimal)numOfWords) * 100;
            Console.WriteLine($"Your result: {score}");
        }
    }
}