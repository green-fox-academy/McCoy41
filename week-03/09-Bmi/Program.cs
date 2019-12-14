using System;

namespace _09_Bmi
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight;
            double height;
            double bmi;
            string level;

            Console.WriteLine("Welcome to BMI Calculator!");

            // ask for data
            Console.Write("Please input your height (in meters): ");
            height = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please input your weight (in kilograms): ");
            weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nInputted Values: " + height + "m, " + weight + "kg.");

            //calculate bmi
            bmi = weight / (height * height);
            level = FatnessLvl(bmi);
            Console.WriteLine("\nYour BMI Index is: {0:0.0}", bmi);
            Console.WriteLine("Fatness level: " + level);
            FatnessList();
        }

        static string FatnessLvl(double bmi) // returns fatness level based on BMI
        {
            string[] level = { "SKELLY", "SKINNY", "PRETTY NORMAL", "BIG", "HEALTHY", "HUSKY", "FLUFFY", "DAAAMN!!!" };

            /* easy solution
            if (bmi < 18) { return level[0]; }
            else if (bmi < 23) { return level[1]; }
            else if (bmi < 25) { return level[2]; }
            else if (bmi < 30) { return level[3]; }
            else if (bmi < 35) { return level[4]; }
            else if (bmi < 40) { return level[5]; }
            else if (bmi < 50) { return level[6]; }
            else { return level[7]; }
            */

            // fancy solution
            int[] maxbmi = { 18, 23, 25, 30, 35, 40, 50 };
            int i = 0;
            bool next = true;
            while (i < 7 && next == true)
            {
                if (bmi < maxbmi[i])
                {
                    next = false;
                    return level[i];
                }
                else
                {
                    i++;
                }
            }
            return level[7];
        }

        static void FatnessList() // list of all levels
        {
            string[] level = { "skelly", "skinny", "pretty normal", "big", "healthy", "husky", "fluffy", "DAMN!" };
            string[] range = { "<18,0", "18,0 - 22,9", "23,0 - 24,9", "25,0 - 29,9", "30,0 - 34,9", "35,0 - 39,9", "40,0 - 49,9", ">50,0" };

            Console.WriteLine("\nAvailable levels of fatness are:");
            for(int i=0; i < level.Length; i++)
            {
                Console.WriteLine(range[i] + ": " + level[i]);
            }

        }
    }
}
