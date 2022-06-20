using System;
using System.Linq;

namespace Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            int myCounter = 0;
            int opponentCounter = 0;
            for (int row = 0; row < n; row++) // reading jagged array
            {

                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .Cast<char>()
                    .ToArray();



                for (int col = 0; col < matrix[row].Length; col++)
                {

                }
            }
            string command = Console.ReadLine();

            while (command != "Gong")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                if (action == "Find" && IsInRange(matrix, row, col)) //my turn
                {
                    if (matrix[row][col] == 'T')
                    {
                        matrix[row][col] = '-';
                        myCounter++;
                    }
                }
                else if (action == "Opponent" && IsInRange(matrix, row, col))
                {
                    if (matrix[row][col] == 'T')
                    {
                        matrix[row][col] = '-';
                        opponentCounter++;

                        string direction = tokens[3];
                        if (direction == "up")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                row--;
                                if (!IsInRange(matrix, row, col))
                                {
                                    break;
                                }
                                if (matrix[row][col] == 'T')
                                {
                                    matrix[row][col] = '-';
                                    opponentCounter++;
                                }
                                else if (matrix[row][col] == '-')
                                {
                                    continue;
                                }

                            }
                        }
                        else if (direction == "down")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                row++;
                                if (!IsInRange(matrix, row, col))
                                {
                                    break;
                                }
                                if (matrix[row][col] == 'T')
                                {
                                    matrix[row][col] = '-';
                                    opponentCounter++;
                                }
                                else if (matrix[row][col] == '-')
                                {
                                    continue;
                                }

                            }
                        }
                        else if (direction == "left")
                        {
                            for (int i = 0; i < 3; i++)
                            {


                                col--;
                                if (!IsInRange(matrix, row, col))
                                {
                                    break;
                                }
                                if (matrix[row][col] == 'T')
                                {
                                    matrix[row][col] = '-';
                                    opponentCounter++;
                                }
                                else if (matrix[row][col] == '-')
                                {
                                    continue;
                                }

                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                col++;
                                if (!IsInRange(matrix, row, col))
                                {
                                    break;
                                }
                                if (matrix[row][col] == 'T')
                                {
                                    matrix[row][col] = '-';
                                    opponentCounter++;
                                }
                                else if (matrix[row][col] == '-')
                                {
                                    continue;
                                }


                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }
            PrintIntMatrix(matrix);
            Console.WriteLine($"Collected tokens: {myCounter}");
            Console.WriteLine($"Opponent's tokens: {opponentCounter}");


        }
        private static bool IsInRange(char[][] matrix, int row, int col) //  Checker for jagged array
        {

            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix[row].Length;
        }

        public static void PrintIntMatrix(char[][] matrix) // printng for jagged array
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }

        }

    }
}

