using System;
using System.Collections.Generic;
using System.IO;

namespace _16_TextEncoder
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<string> txtFile = new List<string>();
            List<char> charList = new List<char>();
            charList = LoadFile("template", 0);
            txtFile = LoadFile("template");

            foreach (char character in charList)
            {
                Console.Write(character);
            }
            Console.WriteLine();
            foreach (string line in txtFile)
            {
                Console.WriteLine(line);
            }
        }
        
        static List<string> LoadFile(string filename)
        {
            StreamReader readfile = new StreamReader($@"{filename}.txt");
            List<string> output = new List<string>();
            string line;
            try
            {
                do
                {
                    line = readfile.ReadLine();
                    output.Add(line);
                } while (line != null) ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return output;
        }
        static List<char> LoadFile(string filename, int decode)
        {
            StreamReader readfile = new StreamReader($@"{filename}.txt");
            List<char> output = new List<char>();
            char c;
            try
            {
                do
                {
                    c = (char)(readfile.Read() - decode);
                    output.Add(c);
                    if (readfile.Peek() == -1) break;
                } while (c != -decode - 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return output;
        }
    }
}
