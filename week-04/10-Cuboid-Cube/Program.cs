using System;

namespace _10_Cuboid_Cube
{
    class Program
    {
        static void Main(string[] args)
        {
            double s;
            double v;
            double a;

            Console.WriteLine("WELCOME TO THE CUBELATOR\n");
            Console.WriteLine("Types of input:\n" +
                               " a = input lenght of the cube edge\n" +
                               " s = input surface area of the cube\n" +
                               " v = input volume of the area\n");
            Console.WriteLine("(Press <ESC> or <ENTER> to exit the program)\n");
            
            while (true)
            {
                Console.Write("\nPlease select type of input: ");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.A) // EDGE
                {
                    Console.Write("\nPlease insert lenght of the cube edge (in centimeters): ");
                    a = Convert.ToDouble(Console.ReadLine());
                    s = 6 * a * a;
                    v = a * a * a;
                    Output(a, s, v);
                }
                else if (key == ConsoleKey.S) // SURFACE
                {
                    Console.Write("\nPlease insert surface area of the cube (in square centimeters): ");
                    s = Convert.ToDouble(Console.ReadLine());
                    a = Math.Sqrt(s / 6);
                    v = s * a / 6;
                    Output(a, s, v);
                }
                else if (key == ConsoleKey.V) // VOLUME
                {
                    Console.Write("\nPlease insert volume of the cube (in cubic centimeters): ");
                    v = Convert.ToDouble(Console.ReadLine());
                    a = Math.Pow(v, 1.0 / 3.0);
                    s = 6 * a * a;
                    Output(a, s, v);
                }
                else if (key == ConsoleKey.Escape || key == ConsoleKey.Enter) // EXIT
                {
                    break;
                }
                else // UNKNOWN
                {
                    Console.WriteLine("\nCalculation not recognized!");
                }
            }
        }

        static void Output(double a, double s, double v)
        {
            Console.WriteLine("\nParameters of your cube are:\n");
            Console.WriteLine("Lenght of the cube edge: {0:0.000} cm", a);
            Console.WriteLine("Surface area of the cube: {0:0.000} cm2", s);
            Console.WriteLine("Volume of the cube: {0:0.000} cm3\n", v);
        }

    }
}
