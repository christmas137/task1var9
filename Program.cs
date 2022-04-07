using System;

namespace task1var9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello world");
            double[,] array =
            {
                {1, 2, 3, 4, 5},
                {-2, -2, -3, -4, -6},
                {0, -1, 0, 0, 0},
                {1, 1, 73, 73, 72},
                {1, -2, -2, -4, -5},
            };
            int arraySize = array.GetUpperBound(0);
            //Console.WriteLine(array.GetUpperBound(0));
            //Console.WriteLine(array.GetUpperBound(1));
            printMatrix(array);
            Console.Write($"\nСтрок, образующих последовательность: {solution(array, arraySize)} \t");
        }

        static void printMatrix(double[,] array)
        {
            for (int i = 0; i <= array.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= array.GetUpperBound(1); j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

        static int solution(double[,] array, int arraySize)
        {
            int result = 0;
            
            for (int row = 0; row <= array.GetUpperBound(0); row++)
            {
                if (isMonotonicSequence(array, arraySize, row)) result++;
            }

            return result;
        }

        static bool isMonotonicSequence(double[,] array, int arraySize, int row)
        {
            //bool plus = ((array[row, 1] - array[row, 0]) >= 0);
            double curr ;
            double next;

            bool init = false;
            bool sign = false;

            double d;
            for (int el = 0; el < arraySize; el++)
            {
                curr = array[row, el];
                next = array[row, el + 1];
                d = next - curr;
                
                if (d == 0) continue;
                else
                {
                    if (init)
                    {
                        if( !(sign && (d > 0) || (!sign && (d < 0))) ) return false;
                    }
                    else
                    {
                        init = true;
                        sign = (d > 0);
                    }
                }
                
                
            }

            return true;
        }
    }
}