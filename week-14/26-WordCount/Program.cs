using System;
using System.Collections.Generic;
using System.IO;

namespace _26_WordCount
{
    class Program
    {

        /*
        Please write a function that takes two parameters:
        - the first parameter is a string that represents the name of a file
        - the function should read the file and count each of the words inside the file
        - the second parameter is a string that represents the name of a file
        - the function should write all the words and its count (separated with spaces) as new lines
          in the file in descending order based on the count
        - You should handle the exceptions
        */
        static void Main(string[] args)
        {
            WordCount("test", "testOut"); // in case of debug, search for .txt file in debug folder!
        }

        static void WordCount(string fileIn, string fileOut)
        {
            Dictionary<string, int> output = new Dictionary<string, int>();
            List<string> lines = Load(fileIn);
            foreach (var line in lines)
            {
                if (line != null)
                {
                    var words = line.Split(new char[] { ' ', (char)39 });
                    foreach (var word in words)
                    {
                        string wordMod = word.ToUpper().Trim(new char[] {'.',',','-','!','?',';', ' '});
                        if (output.ContainsKey(wordMod))
                        {
                            output[wordMod]++;
                        }
                        else output.Add(wordMod, 1);
                    }
                }
            }

            Save(Sort(output), fileOut);
        }
        static List<string> Load(string fileIn)
        {
            StreamReader readfile = new StreamReader($"{fileIn}.txt");
            List<string> output = new List<string>();
            string line;
            try
            {
                do
                {
                    line = readfile.ReadLine();
                    output.Add(line);
                } while (line != null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            readfile.Dispose();
            return output;
        }

        static void Save(Dictionary<string, int> input, string fileOut)
        {
            StreamWriter writefile = new StreamWriter($"{fileOut}.txt");
            foreach (var item in input)
            {
                writefile.WriteLine($"{item.Key} | {item.Value}");
            }

            writefile.Dispose();
        }

        static Dictionary<string, int> Sort(Dictionary<string, int> input)
        {
            Dictionary<string, int> output = new Dictionary<string, int>();
            for (int i = input.Count; i >= 0; i--)
            {
                int maxValue = 0;
                string maxKey = "";
                foreach (var item in input)
                {
                    if (item.Value > maxValue)
                    {
                        maxValue = item.Value;
                        maxKey = item.Key;
                    }
                }
                if (maxValue != 0) output.Add(maxKey, maxValue);
                input.Remove(maxKey);
            }
            return output;
        }
    }
}