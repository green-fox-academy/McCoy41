using System;

namespace _07_VariableMutations
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            // make it bigger by 10
            a += 10;
            Console.WriteLine(a);

            int b = 100;
            // make it smaller by 7
            b -= 7;
            Console.WriteLine(b);

            int c = 44;
            // please double c's value
            c *= 2;
            Console.WriteLine(c);

            int d = 125;
            // please divide by 5 d's value
            d /= 5;
            Console.WriteLine(d);

            int e = 8;
            // please cube of e's value
            e *= e;
            Console.WriteLine(e);

            int f1 = 123;
            int f2 = 345;
            // tell if f1 is bigger than f2 (print as a boolean)
            Console.WriteLine(f1 > f2);

            int g1 = 350;
            int g2 = 200;
            // tell if the double of g2 is bigger than g1 (print as a boolean)
            Console.WriteLine(g2 * 2 > g1);

            long h = 1357988018575474;
            // tell if 11 is a divisor of h (print as a boolean)
            Console.WriteLine(h % 11 == 0);

            int i1 = 10;
            int i2 = 3;
            // tell if i1 is higher than i2 squared and smaller than i2 cubed (print as a boolean)
            Console.WriteLine(i1 > i2*i2 && i1 < i2*i2*i2);

            int j = 1521;
            // tell if j is divisible by 3 or 5 (print as a boolean)
            Console.WriteLine(j % 3 == 0 || j % 5 == 0);
        }
    }
}
