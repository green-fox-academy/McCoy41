using System;
using System.Collections.Generic;
using System.IO;

namespace _16_TextEncoder
{
    class Program
    {
        enum EncodeType { StringMirror, StringOrder, StringCombine, CharMulti, CharShift, None }
        static void Main(string[] args)
        {
            List<string> txtFile = new List<string>();
            List<char> charList = new List<char>();
            charList = LoadFile("template", 0);
            txtFile = Encode(LoadFile("template"),EncodeType.StringCombine);

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
        static List<string> Encode(List<string> input, EncodeType type)
        {
            List<string> output = new List<string>(input.Count);
            switch (type)
            {
                case EncodeType.StringMirror:
                    return StringMirror(input);
                case EncodeType.StringOrder:
                    return StringOrder(input);
                case EncodeType.StringCombine:
                    return StringOrder(StringMirror(input));
                default:
                    return input;
            }
        }
        static List<char> Encode(List<char> input, EncodeType type)
        {
            switch (type)
            {
                case EncodeType.CharMulti:
                    return input;
                case EncodeType.CharShift:
                    return input;
                default:
                    return input;
            }
        }
        static List<string> StringMirror(List<string> input)
        {
            List<string> output = new List<string>(input.Count);
            foreach (string line in input)
            {
                string encodedLine = "";
                try
                {
                    for (int i = 1; i <= line.Length; i++)
                    {
                        encodedLine += line[^i];
                    }
                }
                catch (NullReferenceException)
                {
                    output.Add("");
                }
                output.Add(encodedLine);
            }
            return output;
        }
        static List<string> StringOrder(List<string> input)
        {
            List<string> output = new List<string>(input.Count);
            
            for(int i = input.Count - 1; i >= 0; i--)
            {
                output.Add(input[i]);
            }

            return output;
        }
    }
}
