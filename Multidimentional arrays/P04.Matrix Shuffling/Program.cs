using System;
using System.Linq;

namespace P04.Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowCol = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            string[,] matrix = new string[rowCol[0], rowCol[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] strings = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);



                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = strings[col];

                }
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "END")
                {
                    break;
                }


                if (command[0] == "swap" && command.Length == 5)
                {
                    int cellCordinate1 = int.Parse(command[1]);
                    int cellCordinate2 = int.Parse(command[2]);
                    int cellCordinate3 = int.Parse(command[3]);
                    int cellCordinate4 = int.Parse(command[4]);


                    if (cellCordinate1 >= 0 && cellCordinate1 <= matrix.GetLength(0) &&
                        cellCordinate2 >= 0 && cellCordinate2 <= matrix.GetLength(1) &&
                            cellCordinate3 >= 0 && cellCordinate3 <= matrix.GetLength(0) &&
                            cellCordinate4 >= 0 && cellCordinate4 <= matrix.GetLength(1))
                    {
                        string firstCell = matrix[cellCordinate1, cellCordinate2];
                        string secondCell = matrix[cellCordinate3, cellCordinate4];

                        matrix[cellCordinate1, cellCordinate2] = secondCell;
                        matrix[cellCordinate3, cellCordinate4] = firstCell;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input!");
                        continue;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                for (int row = 0; row < matrix.GetLength(0); row++)
                {

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }
                    Console.WriteLine();
                }

            }


        }
    }
}
