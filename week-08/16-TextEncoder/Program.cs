using System;
using System.Collections.Generic;
using System.IO;

namespace _16_TextEncoder
{
    class Program
    {
        enum EncodeType { StringMirror, StringOrder, StringCombine, CharMulti, CharShift, CharCombine, None }
        static void Main(string[] args)
        {
            Console.WriteLine(File.ReadAllText("template.txt") + "\n"); // default text
            List<string> txtFile = new List<string>();
            List<char> charList = new List<char>();
            charList = Encode(LoadChars("template"), false, EncodeType.CharCombine);
            txtFile = Encode(LoadStrings("template"), EncodeType.StringCombine);
            
            foreach (char character in charList)
            {
                Console.Write(character);
            }
            Console.WriteLine();
            foreach (string line in txtFile)
            {
                Console.WriteLine(line);
            }

            SaveFile(charList, "chartest");
            SaveFile(txtFile, "linetest");
        }
        
        static List<string> LoadStrings(string filename)
        {
            StreamReader readfile = new StreamReader($@".\..\..\..\{filename}.txt");
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
            readfile.Dispose();
            return output;
        }
        static List<char> LoadChars(string filename)
        {
            StreamReader readfile = new StreamReader($@".\..\..\..\{filename}.txt");
            List<char> output = new List<char>();
            char c;
            try
            {
                do
                {
                    c = (char)(readfile.Read());
                    output.Add(c);
                } while (readfile.Peek() != -1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            readfile.Dispose();
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
        static List<char> Encode(List<char> input, bool encode, EncodeType type)
        {
            switch (type)
            {
                case EncodeType.CharMulti:
                    return CharMulti(input, 2, encode);
                case EncodeType.CharShift:
                    return CharShift(input, 1, encode);
                case EncodeType.CharCombine:
                    return CharMulti(CharShift(input, 1, encode), 2, encode);
                default:
                    return input;
            }
        }
        static void SaveFile(List<string> input, string filename)
        {
            StreamWriter writefile = new StreamWriter($@".\..\..\..\{filename}.txt");
            foreach (string line in input)
            {
                writefile.WriteLine(line);
            }
            writefile.Dispose();
        }
        static void SaveFile(List<char> input, string filename)
        {
            StreamWriter writefile = new StreamWriter($@".\..\..\..\{filename}.txt");
            foreach (char character in input)
            {
                writefile.Write(character);
            }
            writefile.Dispose();
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
        static List<char> CharMulti(List<char> input, int multiplier, bool encode)
        {
            if (multiplier < 2) return input;
            List<char> output;
            if (encode == true)
            {
                output = new List<char>((input.Count) * multiplier);
                foreach (char character in input)
                {
                    for (int i = 0; i < multiplier; i++)
                    {
                        output.Add(character);
                    }
                }
            }
            else
            {
                output = new List<char>((input.Count) / multiplier);
                for (int i = 0; i < input.Count; i += multiplier)
                {
                    output.Add(input[i]);
                }
            }
            return output;
        }
        static List<char> CharShift(List<char> input, int modifier, bool encode)
        {
            if (modifier > 9999 || modifier < 0) return input;
            List<char> output = new List<char>(input.Count);
            if (encode == true)
            {
                foreach (char character in input)
                {
                    char newChar = (char)(character + modifier);
                    output.Add(newChar);
                }
            }
            else
            {
                foreach (char character in input)
                {
                    char newChar = (char)(character - modifier);
                    output.Add(newChar);
                }
            }
            return output;
        }
    }
}
