using System;

namespace _11_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ExtremeCalc v32.8b!");
            double mem = 0.0;
            Console.WriteLine("\nFollowing operations are available for use:\n\n" +
                              " A - addition\n" +
                              " S - substraction\n" +
                              " M - multiplication\n" +
                              " D - division\n" +
                              " E - exponentiation\n" +
                              " R - root\n" +
                              " F - factorial\n" +
                              " V - average\n" +
                              " C - comparison");
            Console.WriteLine("\n// press <ENTER> to print out memory status //\n" +
                              "// press <ESC> to exit the program //\n");

            while (true)
            {
                Console.Write("Please select the operation you would like to perform: ");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                {
                    break;
                }
                switch (key)
                {
                    case ConsoleKey.A:
                        mem = Addition(mem);
                        break;
                    case ConsoleKey.S:
                        mem = Substraction(mem);
                        break;
                    case ConsoleKey.M:
                        mem = Multiplication(mem);
                        break;
                    case ConsoleKey.D:
                        mem = Division(mem);
                        break;
                    case ConsoleKey.E:
                        mem = Exponentiation(mem);
                        break;
                    case ConsoleKey.R:
                        mem = Root(mem);
                        break;
                    case ConsoleKey.F:
                        mem = Factorial(mem);
                        break;
                    case ConsoleKey.V:
                        mem = Average(mem);
                        break;
                    case ConsoleKey.C:
                        Comparison(mem);
                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine("\nCurrently saved number: " + mem);
                        break;
                    default:
                        Console.WriteLine("\nUnknown function!");
                        break;
                }
            }
        }

        static double Addition(double mem)
        {
            Console.WriteLine("\n\nADDITION SELECTED");
            Console.Write("How many numbers should be added? ");
            int numbers = Convert.ToInt32(Console.ReadLine());
            double sum = 0;
            double[] numberList = DataInput(numbers, mem);
            for (int j = 0; j < numberList.Length; j++)
            {
                sum += numberList[j];
            }
            Console.WriteLine("\n>> Sum of all numbers equals to {0:0.000}!\n", sum);
            Status(numberList, sum, "+");
            return sum;
        }

        static double Substraction(double mem)
        {
            Console.WriteLine("\n\nSUBSTRACTION SELECTED");
            Console.Write("How many numbers should be deducted? ");
            int numbers = Convert.ToInt32(Console.ReadLine());
            double sum;
            double[] numberList = DataInput(numbers, mem);
            sum = numberList[0];
            for (int j = 1; j < numberList.Length; j++)
            {
                sum -= numberList[j];
            }
            Console.WriteLine("\n>> Substraction of all numbers equals to {0:0.000}!\n", sum);
            Status(numberList, sum, "-");
            return sum;
        }

        static double Multiplication(double mem)
        {
            Console.WriteLine("\n\nMULTIPLICATION SELECTED");
            Console.Write("How many numbers should be multiplied? ");
            int numbers = Convert.ToInt32(Console.ReadLine());
            do
            {
                if (numbers > 5)
                {
                    Console.Write("\n!! This operation might crash the program. Do you wish to continue? (y/n) ");
                    var key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Y) break;
                    else
                    {
                        Console.Write("\nHow many numbers should be multiplied? ");
                        numbers = Convert.ToInt32(Console.ReadLine());
                    }

                }
            } while (numbers > 5);
            double sum;
            double[] numberList = DataInput(numbers, mem);
            sum = numberList[0];
            for (int j = 1; j < numberList.Length; j++)
            {
                sum *= numberList[j];
            }
            Console.WriteLine("\n>> Multiplication of all numbers equals to {0:0.000}!\n", sum);
            Status(numberList, sum, "*");
            return sum;
        }

        static double Division(double mem)
        {
            Console.WriteLine("\n\nDIVISION SELECTED");
            Console.Write("How many numbers should be divided? ");
            int numbers = Convert.ToInt32(Console.ReadLine());
            double sum;
            double[] numberList = DataInput(numbers, mem);
            sum = numberList[0];
            for (int j = 1; j < numberList.Length; j++)
            {
                if (numberList[j] == 0)
                {
                    Console.WriteLine("\n!! Division by 0 is not possible.\n" +
                                      ">> Operation has been cancelled!\n");
                    return mem;
                }
                sum /= numberList[j];
            }
            Console.WriteLine("\n>> Division of all numbers equals to {0:0.000}!\n", sum);
            Status(numberList, sum, "/");
            return sum;
        }

        static double Exponentiation(double mem)
        {
            Console.WriteLine("\nEXPONENTIATION SELECTED");
            Console.WriteLine("!! In case of using large numbers, this operation might crash the program.");
            Console.WriteLine("\n// to add number from memory, write MEM instead of number //\n");
            double[] numberList = { 0, 1 };
            Console.Write("Please specify the base: ");
            string read = Console.ReadLine();
            if (read == "mem" || read == "")
            {
                numberList[0] = mem;
                Console.WriteLine("// {0} added //", mem);
            }
            else
            {
                numberList[0] = Convert.ToDouble(read);
            }
            Console.Write("\nPlease specify the exponent: ");
            read = Console.ReadLine();
            if (read == "mem" || read == "")
            {
                numberList[1] = mem;
                Console.WriteLine("// {0} added //", mem);
            }
            else
            {
                numberList[1] = Convert.ToDouble(read);
            }
            double sum = Math.Pow(numberList[0], numberList[1]);
            Console.WriteLine("\n>> Result of the exponentiation is {0:0.000}!\n", sum);
            Status(numberList, sum, "^");
            return sum;
        }

        static double Root(double mem)
        {
            Console.WriteLine("\nROOT SELECTED");
            double[] numberList = { 0, 1 };
            Console.Write("Please specify the radicand: ");
            string read = Console.ReadLine();
            if (read == "mem" || read == "")
            {
                numberList[0] = mem;
                Console.WriteLine("// {0} added //", mem);
            }
            else
            {
                numberList[0] = Convert.ToDouble(read);
            }
            Console.Write("\nPlease specify the degree: ");
            read = Console.ReadLine();
            if (read == "mem" || read == "")
            {
                numberList[1] = mem;
                Console.WriteLine("// {0} added //", mem);
            }
            else
            {
                numberList[1] = Convert.ToDouble(read);
            }
            double sum = Math.Pow(numberList[0], 1/numberList[1]);
            Console.WriteLine("\n>> Result of the root is {0:0.000}!\n", sum);
            Status(numberList, sum, "^ 1 /");
            return sum;
        }

        static void Comparison(double mem)
        {
            Console.WriteLine("\nCOMPARISON SELECTED");
            double[] numberList = { 0, 1 };
            Console.Write("Please specify first number: ");
            string read = Console.ReadLine();
            if (read == "mem" || read == "")
            {
                numberList[0] = mem;
                Console.WriteLine("// {0} added //", mem);
            }
            else
            {
                numberList[0] = Convert.ToDouble(read);
            }
            Console.Write("\nPlease specify second number: ");
            read = Console.ReadLine();
            if (read == "mem" || read == "")
            {
                numberList[1] = mem;
                Console.WriteLine("// {0} added //", mem);
            }
            else
            {
                numberList[1] = Convert.ToDouble(read);
            }
            
            if (numberList[0] > numberList[1])
            {
                Console.WriteLine("\n>> First number is bigger than second number!\n");
                Console.WriteLine("// {0:0.000} > {1:0.000} //\n\n", numberList[0], numberList[1]);
            }
            else if (numberList[0] > numberList[1])
            {
                Console.WriteLine("\n>> First number is smaller than second number!\n");
                Console.WriteLine("// {0:0.000} < {1:0.000} //\n\n", numberList[0], numberList[1]);
            }
            else
            {
                Console.WriteLine("\n>> First number and second number are the same!\n");
                Console.WriteLine("// {0:0.000} = {1:0.000} //\n\n", numberList[0], numberList[1]);
            }
        }

        static double Average(double mem)
        {
            Console.WriteLine("\nAVERAGE SELECTED");
            Console.Write("How many numbers should be added? ");
            int numbers = Convert.ToInt32(Console.ReadLine());
            double sum = 0;
            double[] numberList = DataInput(numbers, mem);
            for (int j = 0; j < numberList.Length; j++)
            {
                sum += numberList[j];
            }
            sum /= numberList.Length;

            Console.WriteLine("\n>> Sum of all numbers equals to {0:0.000}!\n", sum);
            Console.Write("// performed operation was AVG(" + numberList[0]);
            for (int i = 1; i < numberList.Length; i++)
            {
                Console.Write(", {0}",numberList[i]);
            }
            Console.WriteLine(") = {0:0.000} //", sum);
            Console.WriteLine("// ({0:0.000}) has been saved to memory //\n\n", sum);
            return sum;
        }

        static double Factorial(double mem)
        {
            Console.WriteLine("\n\nFACTORIAL SELECTED");
            double num;
            do
            {
                Console.Write("Please specify number: ");
                string read = Console.ReadLine();
                if (read == "mem" || read == "")
                {
                    num = mem;
                    Console.WriteLine("// {0} added //", mem);
                }
                else
                {
                    num = Convert.ToDouble(read);
                }
                if (num > 20)
                {
                    Console.Write("\n!! This operation might crash the program. Do you wish to continue? (y/n) ");
                    var key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Y) break;
                    else
                    {
                        Console.Write("\nPlease specify number: ");
                        num = Convert.ToInt32(Console.ReadLine());
                    }

                }
            } while (num > 20);
            double sum = num;
            for (int j = 1; j < num; j++)
            {
                sum *= (num - j);
            }
            Console.WriteLine("\n>> Factorial of {1} equals to {0:0.000}!\n", sum, num);
            Console.Write("// performed operation was {1}! = {0:0.000} //\n", sum, num);
            Console.WriteLine("// ({0:0.000}) has been saved to memory //\n\n", sum);
            return sum;
        }

        static double[] DataInput(int numbers, double mem)
        {
            Console.WriteLine("\n// to add number from memory, write MEM instead of number //\n");
            double[] numberList = new double[numbers];
            for (int i = 0; i < numbers; i++)
            {
                Console.Write("Please specify number {0}: ", i + 1);
                string read = Console.ReadLine();
                if (read == "mem" || read == "")
                {
                    numberList[i] = mem;
                    Console.WriteLine("// {0} added //", mem);
                }
                else
                {
                    numberList[i] = Convert.ToDouble(read);
                }
            }
            return numberList;
        }

        static void Status(double[] numberList , double sum, string oper)
        {
            Console.Write("// performed operation was " + numberList[0]);
            for (int i = 1; i < numberList.Length; i++)
            {
                Console.Write(" {0} {1}", oper, numberList[i]);
            }
            Console.WriteLine(" = {0:0.000} //", sum);
            Console.WriteLine("// ({0:0.000}) has been saved to memory //\n\n", sum);
        }
    }
}
