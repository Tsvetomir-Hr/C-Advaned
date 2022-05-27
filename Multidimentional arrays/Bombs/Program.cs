using System;
using System.Linq;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                int[] inputNumbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputNumbers[col];
                }
            }
            int[] indexes = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < indexes.Length; i += 2)
            {
                int row = indexes[i];
                int col = indexes[i + 1];

                if (matrix[row, col] <= 0)
                {
                    continue;
                }
                int value = matrix[row, col];
                if (IsinRange(matrix, row - 1, col) && matrix[row - 1, col] > 0)
                {
                    matrix[row - 1, col] -= value;
                }
                if (IsinRange(matrix, row + 1, col) && matrix[row + 1, col] > 0)
                {
                    matrix[row + 1, col] -= value;
                }
                if (IsinRange(matrix, row, col - 1) && matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= value;
                }
                if (IsinRange(matrix, row, col + 1) && matrix[row, col + 1] > 0)
                {
                    matrix[row, col + 1] -= value;
                }
                if (IsinRange(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] > 0)
                {
                    matrix[row - 1, col - 1] -= value;
                }
                if (IsinRange(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0)
                {
                    matrix[row - 1, col + 1] -= value;
                }
                if (IsinRange(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0)
                {
                    matrix[row + 1, col + 1] -= value;
                }
                if (IsinRange(matrix, row + 1, col - 1) && matrix[row + 1, col - 1] > 0)
                {
                    matrix[row + 1, col - 1] -= value;
                }
                matrix[row, col] = 0;

            }
            int alive = 0;
            int aliveSum = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {

                    if (matrix[rows, cols] > 0)
                    {
                        alive++;
                        aliveSum += matrix[rows, cols];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {alive}");
            Console.WriteLine($"Sum: {aliveSum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

        }

        private static bool IsinRange(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                 col >= 0 && col < matrix.GetLength(1);
        }
    }
}
