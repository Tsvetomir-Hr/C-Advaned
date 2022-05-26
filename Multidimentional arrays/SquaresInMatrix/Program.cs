using System;
using System.Linq;

namespace P03.Exersise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowCol = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[rowCol[0], rowCol[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();


                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = chars[col];

                }
            }
            int squareCounter = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col + 1] == matrix[row, col] &&
                        matrix[row + 1, col] == matrix[row, col]
                        && matrix[row + 1, col + 1] == matrix[row, col])
                    {
                        squareCounter++;
                    }

                }
            }
            Console.WriteLine(squareCounter);
        }

    }
}
