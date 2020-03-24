using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static double e = 0.02, x;

        static List<double> F = new List<double>() { 1, 1 };
        static List<double> A = new List<double>() { 1.5 },
            B = new List<double>() { 2 },
            Z = new List<double>() { 0 }, //Зміщую індексування на 1 таким чином. Не шарю С#. Звертання до листа по індексу на запис вроді неможливе
            T = new List<double>() { 0 };
        //    Fz = new List<double>() { 0 },
        //    Ft = new List<double>() { 0 };

        static double Function(double x)
        {
            return 1 / 3 * Math.Pow(x, 3) - 5 * x + x * Math.Log(x);
        }

        static void Main(string[] args)
        {
            int m, j = 0;
            F.Add(F[j + 1] + F[j]); //Число 2
            
            while (true)
            {               
                if (F[j + 1] < 1 / e * (B[0] - A[0]) && 1 / e * (B[0]- A[0]) <= F[j + 2])
                {
                    m = j;
                    break;
                }
                else
                {
                    F.Add(F[j] + F[j + 1]);
                    j++;
                }
            }
          

            T.Add(A[0] + (F[m] / F[m + 2]) * (B[0] + A[0]));             
            Z.Add(A[0] + (F[m + 1] / F[m + 2]) * (B[0] + A[0]));                                   
         
        //  Ft.Add(Function(T[0])); 
        //  Fz.Add(Function(Z[0]));            

            if (Function(T[0]) <= Function(Z[0]))
            {
                   A.Add(A[0]);
                   B.Add(Z[0]);
            }
            else
            {
                    A.Add(T[0]);
                    B.Add(B[0]);
            }

            int k = 1;

            while (true)
            {            
                if (Function(T[k]) <= Function(Z[k]))
                {                   
                    T.Add(A[k] + (F[m - k] / F[m + 2]) * (B[0] + A[0]));
                //    Ft.Add(Function(T[k + 1]));
                    Z.Add(T[k]);
                 //   Fz.Add(Function(Z[k + 1]));
                }
                else
                {
                    T.Add(Z[k]);
                  //  Ft.Add(Function(T[k + 1]));
                    Z.Add(A[k] + (F[m - k + 1] / F[m + 2]) * (B[0] + A[0]));                                    
                  //  Fz.Add(Function(Z[k + 1]));
                }

                if (Function(T[k+1]) <= Function(Z[k+1]))
                {
                    A.Add(A[k]);                 
                    B.Add(Z[k + 1]);
                }
                else
                {
                    A.Add(T[k + 1]);
                    B.Add(B[k]);
                }

                Console.WriteLine("a: " + A[k] + " b: " + B[k]);

                if (k < m - 1)
                {
                    k++;              
                }
                else
                {
                    Console.WriteLine("a: " + A[m] + " b: " + B[m]);                  
                    x = (A[m] + B[m]) / 2;
                    Console.WriteLine("x is: " + x); //Дуже погана відповідь, геть не розумію цей алгоритм
                    break;
                }
            }
                     
            Console.WriteLine("Enter anything to exit");
            Console.ReadKey();
}
    }
}
