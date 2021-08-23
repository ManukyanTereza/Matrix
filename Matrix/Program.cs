using System;

namespace Homework3
{
    class Program
    {

        static int n = int.Parse(Console.ReadLine());
        static int m = int.Parse(Console.ReadLine());

        
        static void enter(int[,] a)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = Convert.ToInt32(Console.ReadLine());

                }
            }
        }
        static void Outputarray(int[,] a, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    Console.Write(a[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }

        static void add(int[,] a, int[,] b, int[,] c)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }
            Console.Write("\nAdd two matrices: \n");
            Outputarray(c, c.GetLength(0), c.GetLength(1));
        }
        static void Max(int[,] a)
        {
            int max = a[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i, j] > max) max = a[i, j];
                }
            }
            Console.WriteLine("Max=" + max);
        }
        static void Min(int[,] a)
        {
            int min = a[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i, j] < min) min = a[i, j];
                }
            }
            Console.WriteLine("Min=" + min);
        }
        static void ScalarMul(int[,] a, int lyambda)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] *= lyambda;
                }
            }
            Outputarray(a, n, m);
        }
        static void Transpose(int[,] a, int[,] d)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    d[j, i] = a[i, j];
                }
            }
            Outputarray(d, d.GetLength(0),d.GetLength(1));
        }
        static void mul(int[,] a, int[,] b, int[,] c)
        {
            int a_row = a.GetLength(0);
            int a_column = a.GetLength(1);
            int b_row = b.GetLength(0);
            int b_column = b.GetLength(1);
            if (a_column != b_row) Console.WriteLine("The multiplication is not possible");
            else
            {
               
                for (int i = 0; i < a_row; i++)
                {
                    for (int j = 0; j < b_column; j++)
                    {
                        c[i, j] = 0;
                        for (int k = 0; k < a_column; k++)
                        {
                            c[i, j] += a[i, k] * b[k, j];
                        }
                    }
                }
                Outputarray(c, c.GetLength(0), c.GetLength(1));
            }
        }
        static bool Orthogonal(int[,] a,int n,int m)
        {
            if (n != m) return false;
            int[,] l = new int[m, n];
            int[,] e = new int[n, n];

            Transpose(a, l);
            mul(a, l, e);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j && e[i, j] != 0) return false;
                    if (i == j && e[i, j] != 1) return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
            {


                int[,] a = new int[n, m];
                int[,] b = new int[n, m];
                int[,] c = new int[n, m];
                int[,] d = new int[m, n];
                int[,] product = new int[n, n];
                


                Console.WriteLine("Enter the first matrix");
                enter(a);
                Console.WriteLine("Enter the second matrix");
                enter(b);
                Console.WriteLine("This is the first matrix");
                Outputarray(a, n, m);
               Console.WriteLine("This is the second matrix");
                Outputarray(b, n, m);

                //Add two matrices
                 add(a, b, c);
            //Max value of an array
            Console.WriteLine("Max element of an array is:");
                 Max(a);
            //MIn Value of an array
            Console.WriteLine("Min element of an array is:");
                 Min(b);
            // Scalar
            Console.WriteLine("Scalar multiplication :");
            ScalarMul(a, -4);
                //Transpose matrix
                 Console.WriteLine("This is transpose matrix");
                 Transpose(a, d);
            //multiplication
            Console.WriteLine("Multiplication :");
            mul(a, d, product);
            //Orthogonal
            Console.WriteLine("Orthogonal :");
            if ( Orthogonal(b,n,m)) Console.WriteLine("The matrix is orthogonal");
             else Console.WriteLine("The matrix is not  orthogonal");
            }
        }
    }
    

