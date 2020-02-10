using System;

namespace _18_Abacus
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey key;
            Abacus counter;
            Console.Write("Would you like to set default number for your Abacus? (Y/N): ");
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.Y)
            {
                counter = new Abacus(GetInput());
            }
            else
            {
                counter = new Abacus();
            }
            Console.WriteLine("\nFollowing operations are currently available for use:\n\n" +
                              " <ENTER> - add 1\n" + 
                              " A - add specific number\n" +
                              " P - print Abacus status\n" +
                              " R - reset Abacus to default value\n");
            Console.WriteLine("Press <ESC> to exit the program\n");

            while (true)
            {
                Console.Write("Please select the operation you would like to perform: ");
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape) break;
                switch (key)
                {
                    case ConsoleKey.A:
                        counter.Add(GetInput());
                        break;
                    case ConsoleKey.P:
                        Console.WriteLine($"\nCurrent status of your Abacus: {counter.Get()}");
                        break;
                    case ConsoleKey.R:
                        counter.Reset();
                        Console.WriteLine($"\nAbacus has been resetted to initial value {counter.Count}!");
                        break;
                    case ConsoleKey.Enter:
                        counter.Add();
                        Console.WriteLine("\n1 has been added");
                        break;
                    default:
                        Console.WriteLine("\nUnknown function!");
                        break;

                }
            }

        }
        static int GetInput()
        {
            int count = 0;
            bool err;
            do
            {
                err = false;
                Console.Write("\nPlease specify your number: ");
                try
                {
                    count = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    err = true;
                }
            } while (err == true);

            return count;
        }
    }
    class Abacus
    {
        private int _initial;
        private int _count = 0;

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Only positive number can be set up - default value 0 has been added");
                    return;
                } 
                else _count = value;
            }
        }
        public Abacus (int count)
        {
            Count = count;
            _initial = count;
        }
        public Abacus()
        {
            Count = 0;
            _initial = Count;
        }

        public void Add(int add)
        {
            Count += add;
        }

        public void Add()
        {
            Count++;
        }

        public void Reset()
        {
            _count = _initial;
        }

        public string Get()
        {
            return Count.ToString();
        }
    }
}
