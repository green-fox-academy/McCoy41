using System;
using System.Collections.Generic;
using System.IO;

namespace _16_TextEncoder
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader read = new StreamReader(@"C:\Users\kkoma\OneDrive\Plocha\GreenFox\Projects\McCoy41\week-08\16-TextEncoder\source.txt");
            
            List<string> text = new List<string>();
            List<string> sortedText = new List<string>();
            string line;
            do
            {
                line = read.ReadLine();
                text.Add(line);
            } while (line != null);

            for (int i = 0; i <text.Count; i++)
            {
                sortedText.Add(text[^(i + 1)]);
            }
            foreach (string listItem in sortedText)
            {
                Console.WriteLine(listItem);
            }
            read.Dispose();

            StreamWriter write = new StreamWriter(@"C:\Users\kkoma\OneDrive\Plocha\GreenFox\Projects\McCoy41\week-08\16-TextEncoder\template.txt");
            foreach (string listItem in sortedText)
            {
                write.WriteLine(listItem);
            }
            write.Dispose();
        }
    }
}
