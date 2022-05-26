using System;
using System.Linq;

namespace SumOfCols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixColsAndRows = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = matrixColsAndRows[0];
            int cols = matrixColsAndRows[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sumCol = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sumCol+=matrix[row, col];
                    //Console.Write($" {matrix[row,col]}");
                }
                Console.WriteLine(sumCol);
            }
        }
    }
}
