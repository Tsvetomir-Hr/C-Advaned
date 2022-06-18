using System;
using System.Linq;

namespace Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = input[0];
            int m = input[1];

            int[,] matrix = new int[n, m];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }
            string command = Console.ReadLine();
            while (command != "Bloom Bloom Plow")
            {
                string[] rowCol = command.Split();
                int matrixRow = int.Parse(rowCol[0]);
                int matrixCol = int.Parse(rowCol[1]);

                if (IsInRange(matrix, matrixRow, matrixCol))
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        matrix[i, matrixCol]++;


                    }
                    for (int i = 0; i < matrix.GetLength(1); i++)
                    {
                        if (i != matrixCol)
                        {
                            matrix[matrixRow, i]++;
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }


                command = Console.ReadLine();

            }

            PrintIntMatrix(matrix);

            static bool IsInRange(int[,] matrix, int row, int col)
            {

                return row >= 0 && row < matrix.GetLength(0) &&
                    col >= 0 && col < matrix.GetLength(1);
            }
            static void PrintIntMatrix(int[,] matrix)
            {

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }

            }
        }
        
    }
}
