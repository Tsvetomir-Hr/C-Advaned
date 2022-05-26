using System;
using System.Linq;

namespace Matrix.Exersise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputNumbers[col];
                }
            }
            int leftRightSum = 0;
            int rightToLeft = 0;
            //left to right
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                leftRightSum += matrix[i, i];
                rightToLeft += matrix[i, matrix.GetLength(1) - 1 - i];
            }
            //right to left
            Console.WriteLine(Math.Abs(leftRightSum-rightToLeft));
        }
    }
}
