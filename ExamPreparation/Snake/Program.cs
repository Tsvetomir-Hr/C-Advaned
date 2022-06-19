using System;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(global::System.Console.ReadLine());

            char[,] matrix = new char[n, n];

            int snakeRow = 0;
            int snakeCol = 0;
            int eatenFood = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            
            while (eatenFood != 10)
            {
                string direction = Console.ReadLine();

                if (direction == "up" && IsInRange(matrix, snakeRow - 1, snakeCol))
                {
                    if (matrix[snakeRow - 1, snakeCol] == '-')
                    {
                        matrix[snakeRow - 1, snakeCol] = 'S';
                        matrix[snakeRow, snakeCol] = '.';
                        snakeRow--;
                    }
                    else if (matrix[snakeRow - 1, snakeCol] == '*')
                    {
                        matrix[snakeRow - 1, snakeCol] = 'S';
                        matrix[snakeRow, snakeCol] = '.';
                        snakeRow--;
                        eatenFood++;
                    }
                    else if (matrix[snakeRow - 1, snakeCol] == 'B')
                    {
                        matrix[snakeRow - 1, snakeCol] = '.';
                        matrix[snakeRow, snakeCol] = '.';

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'B')
                                {
                                    snakeRow = row;
                                    snakeCol = col;
                                }
                            }
                        }
                        matrix[snakeRow, snakeCol] = 'S';
                    }

                }
                else if (direction == "down" && IsInRange(matrix, snakeRow + 1, snakeCol))
                {
                    if (matrix[snakeRow + 1, snakeCol] == '-')
                    {
                        matrix[snakeRow + 1, snakeCol] = 'S';
                        matrix[snakeRow, snakeCol] = '.';
                        snakeRow++;
                    }
                    else if (matrix[snakeRow + 1, snakeCol] == '*')
                    {
                        matrix[snakeRow + 1, snakeCol] = 'S';
                        matrix[snakeRow, snakeCol] = '.';
                        snakeRow++;
                        eatenFood++;
                    }
                    else if (matrix[snakeRow + 1, snakeCol] == 'B')
                    {
                        matrix[snakeRow + 1, snakeCol] = '.';
                        matrix[snakeRow, snakeCol] = '.';

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'B')
                                {
                                    snakeRow = row;
                                    snakeCol = col;
                                }
                            }
                        }
                        matrix[snakeRow, snakeCol] = 'S';
                    }

                }
                else if (direction == "left" && IsInRange(matrix, snakeRow, snakeCol - 1))
                {
                    if (matrix[snakeRow, snakeCol - 1] == '-')
                    {
                        matrix[snakeRow, snakeCol - 1] = 'S';
                        matrix[snakeRow, snakeCol] = '.';
                        snakeCol--;
                    }
                    else if (matrix[snakeRow, snakeCol - 1] == '*')
                    {
                        matrix[snakeRow, snakeCol - 1] = 'S';
                        matrix[snakeRow, snakeCol] = '.';
                        snakeCol--;
                        eatenFood++;
                    }
                    else if (matrix[snakeRow, snakeCol - 1] == 'B')
                    {
                        matrix[snakeRow, snakeCol - 1] = '.';
                        matrix[snakeRow, snakeCol] = '.';

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'B')
                                {
                                    snakeRow = row;
                                    snakeCol = col;
                                }
                            }
                        }
                        matrix[snakeRow, snakeCol] = 'S';
                    }

                }
                else if (direction == "right" && IsInRange(matrix, snakeRow, snakeCol + 1))
                {
                    if (matrix[snakeRow, snakeCol + 1] == '-')
                    {
                        matrix[snakeRow, snakeCol + 1] = 'S';
                        matrix[snakeRow, snakeCol] = '.';
                        snakeCol++;
                    }
                    else if (matrix[snakeRow, snakeCol + 1] == '*')
                    {
                        matrix[snakeRow, snakeCol + 1] = 'S';
                        matrix[snakeRow, snakeCol] = '.';
                        snakeCol++;
                        eatenFood++;
                    }
                    else if (matrix[snakeRow, snakeCol + 1] == 'B')
                    {
                        matrix[snakeRow, snakeCol + 1] = '.';
                        matrix[snakeRow, snakeCol] = '.';

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'B')
                                {
                                    snakeRow = row;
                                    snakeCol = col;
                                }
                            }
                        }
                        matrix[snakeRow, snakeCol] = 'S';
                    }

                }
                else
                {
                    matrix[snakeRow, snakeCol] = '.';
                    Console.WriteLine("Game over!");
                    break;
                }

            }
            if (eatenFood == 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {eatenFood}");
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
    }
}
