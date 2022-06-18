using System;
using System.Collections.Generic;

namespace Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int beeRow = 0;
            int beeCol = 0;
            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                List<char> input = new List<char>();
                foreach (char ch in currentRow)
                {
                    input.Add(ch);
                }
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }
            string command = Console.ReadLine();

            int flowerCounter = 0;
            while (command != "End")
            {
                if (command == "right" && IsInRange(matrix, beeRow, beeCol + 1))
                {
                    if (matrix[beeRow, beeCol + 1] == 'f')
                    {
                        flowerCounter++;
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow, beeCol + 1] = 'B';
                        beeCol++;
                    }
                    else if (matrix[beeRow, beeCol + 1] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow, beeCol + 1] = '.';

                        if (!IsInRange(matrix, beeRow, beeCol + 2))
                        {
                            Console.WriteLine("The bee got lost!");
                            break;
                        }
                        if (matrix[beeRow, beeCol + 2] == 'f')
                        {
                            flowerCounter++;
                            matrix[beeRow, beeCol + 2] = 'B';
                        }
                        matrix[beeRow, beeCol + 2] = 'B';
                        beeCol += 2;
                    }
                    else if (matrix[beeRow, beeCol + 1] == '.')
                    {
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow, beeCol + 1] = 'B';
                        beeCol++;
                    }
                }
                else if (command == "left" && IsInRange(matrix, beeRow, beeCol - 1))
                {
                    if (matrix[beeRow, beeCol - 1] == 'f')
                    {
                        flowerCounter++;
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow, beeCol - 1] = 'B';
                        beeCol--;
                    }
                    else if (matrix[beeRow, beeCol - 1] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow, beeCol - 1] = '.';

                        if (!IsInRange(matrix, beeRow, beeCol - 2))
                        {
                            Console.WriteLine("The bee got lost!");
                            break;
                        }
                        if (matrix[beeRow, beeCol - 2] == 'f')
                        {
                            flowerCounter++;
                            matrix[beeRow, beeCol - 2] = 'B';
                        }
                        matrix[beeRow, beeCol - 2] = 'B';
                        beeCol -= 2;
                    }
                    else if (matrix[beeRow, beeCol - 1] == '.')
                    {
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow, beeCol - 1] = 'B';
                        beeCol--;
                    }
                }
                else if (command == "up" && IsInRange(matrix, beeRow - 1, beeCol))
                {
                    if (matrix[beeRow - 1, beeCol] == 'f')
                    {
                        flowerCounter++;
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow - 1, beeCol] = 'B';
                        beeRow--;
                    }
                    else if (matrix[beeRow - 1, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow - 1, beeCol] = '.';

                        if (!IsInRange(matrix, beeRow - 2, beeCol))
                        {
                            Console.WriteLine("The bee got lost!");
                            break;
                        }
                        if (matrix[beeRow - 2, beeCol] == 'f')
                        {
                            flowerCounter++;
                            matrix[beeRow - 2, beeCol] = 'B';
                        }
                        matrix[beeRow - 2, beeCol] = 'B';
                        beeRow -= 2;
                    }
                    else if (matrix[beeRow - 1, beeCol] == '.')
                    {
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow - 1, beeCol] = 'B';
                        beeRow--;
                    }
                }
                else if (command == "down" && IsInRange(matrix, beeRow + 1, beeCol))
                {
                    if (matrix[beeRow + 1, beeCol] == 'f')
                    {
                        flowerCounter++;
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow + 1, beeCol] = 'B';
                        beeRow++;
                    }
                    else if (matrix[beeRow + 1, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow + 1, beeCol] = '.';

                        if (!IsInRange(matrix, beeRow + 2, beeCol))
                        {
                            Console.WriteLine("The bee got lost!");
                            break;
                        }
                        if (matrix[beeRow + 2, beeCol] == 'f')
                        {
                            flowerCounter++;
                            matrix[beeRow + 2, beeCol] = 'B';
                        }
                        matrix[beeRow + 2, beeCol] = 'B';
                        beeRow += 2;
                    }
                    else if (matrix[beeRow + 1, beeCol] == '.')
                    {
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow + 1, beeCol] = 'B';
                        beeRow++;
                    }
                }
                else
                {
                    matrix[beeRow, beeCol] = '.';
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                command = Console.ReadLine();
            }
            if (flowerCounter < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-flowerCounter} flowers more");

            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowerCounter} flowers!");
            }
            PrintIntMatrix(matrix);
        }

        private static bool IsInRange(char[,] matrix, int row, int col)
        {

            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
        public static void PrintIntMatrix(char[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

        }
        static bool IsLastIndex(char[,] matrix, int row, int col)
        {

            if (row == 0 && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            else if (row == matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            else if (col == 0 && row >= 0 && row < matrix.GetLength(0))
            {
                return true;
            }
            else if (col == matrix.GetLength(1) && row >= 0 && row < matrix.GetLength(0))
            {
                return true;
            }

            return false;
        }
    }
}
