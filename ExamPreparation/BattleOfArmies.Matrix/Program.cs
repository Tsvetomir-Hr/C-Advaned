using System;

namespace BattleOfArmies.Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            int armyRow = 0;
            int armyCol = 0;

            bool mordorIsFound = false;
            for (int row = 0; row < n; row++) // reading jagged array
            {

                matrix[row] = Console.ReadLine()?.ToCharArray();

                for (int col = 0; col < matrix[row].Length; col++)
                {

                    if (matrix[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }
            
            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = input[0];
                int rowSpawn = int.Parse(input[1]);
                int colSpawn = int.Parse(input[2]);
                matrix[rowSpawn][colSpawn] = 'O';
                armyArmor--;
                if (direction == "up" && IsInRange(matrix, armyRow - 1, armyCol))
                {
                    if (matrix[armyRow - 1][armyCol] == '-')
                    {
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow - 1][armyCol] = 'A';
                        armyRow--;
                    }
                    else if (matrix[armyRow - 1][armyCol] == 'O')
                    {
                        armyArmor -= 2;
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow - 1][armyCol] = 'A';
                        armyRow--;
                    }
                    else if (matrix[armyRow - 1][armyCol] == 'M')
                    {
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow - 1][armyCol] = '-';
                        mordorIsFound = true;
                        break;

                    }
                }
                else if (direction == "down" && IsInRange(matrix, armyRow + 1, armyCol))
                {
                    if (matrix[armyRow + 1][armyCol] == '-')
                    {
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow + 1][armyCol] = 'A';
                        armyRow++;
                    }
                    else if (matrix[armyRow + 1][armyCol] == 'O')
                    {
                        armyArmor -= 2;
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow + 1][armyCol] = 'A';
                        armyRow++;
                    }
                    else if (matrix[armyRow + 1][armyCol] == 'M')
                    {
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow + 1][armyCol] = '-';
                        mordorIsFound = true;
                        break;

                    }
                }
                else if (direction == "left" && IsInRange(matrix, armyRow, armyCol-1))
                {
                    if (matrix[armyRow][armyCol - 1] == '-')
                    {
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow][armyCol - 1] = 'A';
                        armyCol--;
                    }
                    else if (matrix[armyRow][armyCol - 1] == 'O')
                    {
                        armyArmor -= 2;
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow][armyCol - 1] = 'A';
                        armyCol--;
                    }
                    else if (matrix[armyRow][armyCol - 1] == 'M')
                    {
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow][armyCol - 1] = '-';
                        mordorIsFound = true;
                        break;

                    }
                }
                else if (direction == "right" && IsInRange(matrix, armyRow, armyCol + 1))
                {
                    if (matrix[armyRow][armyCol + 1] == '-')
                    {
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow][armyCol + 1] = 'A';
                        armyCol++;
                    }
                    else if (matrix[armyRow][armyCol + 1] == 'O')
                    {
                        armyArmor -= 2;
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow][armyCol + 1] = 'A';
                        armyCol++;
                    }
                    else if (matrix[armyRow][armyCol + 1] == 'M')
                    {
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow][armyCol + 1] = '-';
                        mordorIsFound = true;
                        break;

                    }
                }

                if (armyArmor <= 0)
                {
                    matrix[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }
            }
            if (mordorIsFound)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
            }
            PrintIntMatrix(matrix);
        }
        private static bool IsInRange(char[][] matrix, int row, int col) 
        {

            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix[row].Length;
        }
        public static void PrintIntMatrix(char[][] matrix) 
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }

        }
    }
}
