using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldIntersection
{
    class Program
    {
        static double lambda, B, A, x1, x2, x, R, a = 1.5, b = 2, e = 0.02;
     
        static void Result()
        {
            x = (a + b) / 2;
           // R = Function(x);
            Console.WriteLine("Your x: ");
            Console.WriteLine(x);           
        }

        static double Function(double x)
        {
            return 1 / 3 * Math.Pow(x, 3) - 5 * x + x * Math.Log(x);
        }

        static bool Comparation()
        {
            if (b - a <= e)
            {
                Result();
                return true;
            }
            else return false;
        }

        static void Circle()
        {         
            if (A < B)
            {
                b = x2;
                bool res = Comparation();

                if (!res) {
                    x2 = x1;
                    B = A;
                    x1 = a + lambda * (b - a);
                    A = Function(x1);

                    Console.WriteLine("а and b: ");
                    Console.WriteLine(a + " " + b);
                    Circle(); //Рекурсія
                }
            }
            else
            {
                a = x1;
                bool res = Comparation();

                if (!res)
                {
                    x1 = x2;
                    A = B;
                    x2 = b - lambda * (b - a);
                    B = Function(x2);

                    Console.WriteLine("а and b: ");
                    Console.WriteLine(a + " " + b);
                    Circle(); 
                }
            }         
        }

        static void Main(string[] args)
        {
            lambda = (Math.Sqrt(5)- 1) / 2;

            Console.WriteLine("lambda: ");
            Console.WriteLine(lambda);

            x1 = a + lambda * (b - a);
            x2 = b - lambda * (b - a);
            A = Function(x1);
            B = Function(x2);

            Circle();
            Console.WriteLine("Enter any key to exit");
            Console.ReadKey();
        }
    }
}
