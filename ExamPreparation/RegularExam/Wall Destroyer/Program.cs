using System;
using System.Linq;

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // reading for square matrix

            char[,] matrix = new char[n, n];

            int vankoRow = 0;
            int vankoCol = 0;
            int holesConter = 1;
            int steelRodCounter = 0;
            bool isElectrocuted = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }
            string command = Console.ReadLine();

            while (command != "End")
            {

                if (command == "up" && IsInRange(matrix, vankoRow - 1, vankoCol))
                {
                    if (matrix[vankoRow - 1, vankoCol] == '-')
                    {
                        holesConter++;
                        matrix[vankoRow, vankoCol] = '*';
                        matrix[vankoRow - 1, vankoCol] = 'V';
                        vankoRow--;
                    }
                    else if (matrix[vankoRow - 1, vankoCol] == 'R')
                    {
                        steelRodCounter++;
                        Console.WriteLine("Vanko hit a rod!");
                        command = Console.ReadLine();
                        continue;
                    }
                    else if (matrix[vankoRow - 1, vankoCol] == 'C')
                    {
                        matrix[vankoRow, vankoCol] = '*';
                        matrix[vankoRow - 1, vankoCol] = 'E';
                        holesConter++;
                        isElectrocuted = true;
                        break;
                    }
                    else if (matrix[vankoRow - 1, vankoCol] == '*')
                    {
                        matrix[vankoRow, vankoCol] = '*';
                        matrix[vankoRow - 1, vankoCol] = 'V';
                        vankoRow--;
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                }
                else if (command == "down" && IsInRange(matrix, vankoRow + 1, vankoCol))
                {
                    if (matrix[vankoRow + 1, vankoCol] == '-')
                    {
                        holesConter++;
                        matrix[vankoRow, vankoCol] = '*';
                        matrix[vankoRow + 1, vankoCol] = 'V';
                        vankoRow++;
                    }
                    else if (matrix[vankoRow + 1, vankoCol] == 'R')
                    {
                        steelRodCounter++;
                        Console.WriteLine("Vanko hit a rod!");

                    }
                    else if (matrix[vankoRow + 1, vankoCol] == 'C')
                    {
                        matrix[vankoRow, vankoCol] = '*';
                        matrix[vankoRow + 1, vankoCol] = 'E';
                        holesConter++;
                        isElectrocuted = true;
                        break;
                    }
                    else if (matrix[vankoRow + 1, vankoCol] == '*')
                    {
                        matrix[vankoRow, vankoCol] = '*';
                        matrix[vankoRow + 1, vankoCol] = 'V';
                        vankoRow++;
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                }
                else if (command == "left" && IsInRange(matrix, vankoRow, vankoCol - 1))
                {
                    if (matrix[vankoRow, vankoCol - 1] == '-')
                    {
                        holesConter++;
                        matrix[vankoRow, vankoCol] = '*';
                        matrix[vankoRow, vankoCol - 1] = 'V';
                        vankoCol--;
                    }
                    else if (matrix[vankoRow, vankoCol - 1] == 'R')
                    {
                        steelRodCounter++;
                        Console.WriteLine("Vanko hit a rod!");

                    }
                    else if (matrix[vankoRow, vankoCol - 1] == 'C')
                    {
                        matrix[vankoRow, vankoCol] = '*';
                        matrix[vankoRow, vankoCol - 1] = 'E';
                        holesConter++;
                        isElectrocuted = true;
                        break;
                    }
                    else if (matrix[vankoRow, vankoCol - 1] == '*')
                    {
                        matrix[vankoRow, vankoCol] = '*';
                        matrix[vankoRow, vankoCol - 1] = 'V';
                        vankoCol--;
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                }
                else if (command == "right" && IsInRange(matrix, vankoRow, vankoCol + 1))
                {
                    if (matrix[vankoRow, vankoCol + 1] == '-')
                    {
                        holesConter++;
                        matrix[vankoRow, vankoCol] = '*';
                        matrix[vankoRow, vankoCol + 1] = 'V';
                        vankoCol++;
                    }
                    else if (matrix[vankoRow, vankoCol + 1] == 'R')
                    {
                        steelRodCounter++;
                        Console.WriteLine("Vanko hit a rod!");

                    }
                    else if (matrix[vankoRow, vankoCol + 1] == 'C')
                    {
                        matrix[vankoRow, vankoCol] = '*';
                        matrix[vankoRow, vankoCol + 1] = 'E';
                        holesConter++;
                        isElectrocuted = true;
                        break;
                    }
                    else if (matrix[vankoRow, vankoCol + 1] == '*')
                    {
                        matrix[vankoRow, vankoCol] = '*';
                        matrix[vankoRow, vankoCol + 1] = 'V';
                        vankoCol++;
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                }
                command = Console.ReadLine();
            }

            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesConter} hole(s).");
            }
            else
            {

                Console.WriteLine($"Vanko managed to make {holesConter} hole(s) and he hit only {steelRodCounter} rod(s).");
            }
            PrintIntMatrix(matrix);
        }
        private static bool IsInRange(char[,] matrix, int row, int col) //checker in square matrix
        {

            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
        public static void PrintIntMatrix(char[,] matrix) //printing for  square matrix
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
    }

}
