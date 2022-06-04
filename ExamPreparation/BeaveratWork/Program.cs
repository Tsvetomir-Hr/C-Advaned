using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaveratWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            Stack<char> collectedBranches = new Stack<char>();
            int branchesCounter = 0;


            int rowB = 0;
            int colB = 0;
            int allBranchesCollected = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (char.IsLower(matrix[row, col]))
                    {
                        branchesCounter++;

                    }
                    if (matrix[row, col] == 'B')
                    {
                        rowB = row;
                        colB = col;
                    }
                }
            }
            string command = Console.ReadLine();
            int branches = branchesCounter;
            while (true)
            {
                if (command == "end")
                {
                    Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branches - allBranchesCollected} branches left.");
                    break;
                }
                if (command == "up" && IsInRange(matrix, rowB - 1, colB))
                {

                    if (char.IsLower(matrix[rowB - 1, colB]))
                    {
                        collectedBranches.Push(matrix[rowB - 1, colB]);
                        branchesCounter--;
                        allBranchesCollected++;
                        matrix[rowB - 1, colB] = 'B';
                        matrix[rowB, colB] = '-';
                        rowB--;

                    }
                    else if (matrix[rowB - 1, colB] == 'F')
                    {
                        if (IsLastIndex(matrix, rowB - 1, colB))
                        {
                            matrix[rowB, colB] = '-';
                            matrix[rowB - 1, colB] = '-';
                            matrix[matrix.GetLength(0) - 1, colB] = 'B';
                            rowB = matrix.GetLength(0) - 1;

                        }
                        else
                        {
                            matrix[0, colB] = 'B';
                            matrix[rowB - 1, colB] = '-';
                            rowB = 0;
                        }
                    }
                    else
                    {
                        matrix[rowB, colB] = '-';
                        matrix[rowB - 1, colB] = 'B';
                        rowB--;
                    }
                }
                else if (command == "down" && IsInRange(matrix, rowB + 1, colB))
                {

                    if (char.IsLower(matrix[rowB + 1, colB]))
                    {
                        collectedBranches.Push(matrix[rowB + 1, colB]);
                        branchesCounter--;
                        allBranchesCollected++;
                        matrix[rowB + 1, colB] = 'B';
                        matrix[rowB, colB] = '-';
                        rowB++;

                    }
                    else if (matrix[rowB + 1, colB] == 'F')
                    {
                        if (IsLastIndex(matrix, rowB + 1, colB))
                        {
                            matrix[0, colB] = 'B';
                            matrix[rowB + 1, colB] = '-';
                            matrix[rowB, colB] = '-';
                            rowB = 0;
                        }
                        else
                        {
                            matrix[matrix.GetLength(0) - 1, colB] = 'B';
                            matrix[rowB + 1, colB] = '-';
                            matrix[rowB, colB] = '-';
                            rowB = matrix.GetLength(0) - 1;

                        }
                    }
                    else
                    {
                        matrix[rowB, colB] = '-';
                        matrix[rowB + 1, colB] = 'B';
                        rowB++;
                    }

                }
                else if (command == "left" && IsInRange(matrix, rowB, colB - 1))
                {

                    if (char.IsLower(matrix[rowB, colB - 1]))
                    {
                        collectedBranches.Push(matrix[rowB, colB - 1]);
                        branchesCounter--;
                        allBranchesCollected++;
                        matrix[rowB, colB - 1] = 'B';
                        matrix[rowB, colB] = '-';
                        colB--;

                    }
                    else if (matrix[rowB, colB - 1] == 'F')
                    {
                        if (IsLastIndex(matrix, rowB, colB - 1))
                        {
                            matrix[rowB, matrix.GetLength(1) - 1] = 'B';
                            matrix[rowB, colB - 1] = '-';
                            matrix[rowB, colB] = '-';
                            colB = matrix.GetLength(1) - 1;
                        }
                        else
                        {
                            matrix[rowB, 0] = 'B';
                            matrix[rowB, colB - 1] = '-';
                            matrix[rowB, colB] = '-';
                            colB = 0;

                        }
                    }
                    else
                    {
                        matrix[rowB, colB] = '-';
                        matrix[rowB, colB - 1] = 'B';
                        colB--;

                    }
                }
                else if (command == "right" && IsInRange(matrix, rowB, colB + 1))
                {

                    if (char.IsLower(matrix[rowB, colB + 1]))
                    {
                        collectedBranches.Push(matrix[rowB, colB + 1]);
                        branchesCounter--;
                        allBranchesCollected++;
                        matrix[rowB, colB + 1] = 'B';
                        matrix[rowB, colB] = '-';
                        colB++;

                    }
                    else if (matrix[rowB, colB + 1] == 'F')
                    {
                        if (IsLastIndex(matrix, rowB, colB + 1))
                        {
                            matrix[rowB, 0] = 'B';
                            matrix[rowB, colB + 1] = '-';
                            matrix[rowB, colB] = '-';
                            colB = 0;
                        }
                        else
                        {
                            matrix[rowB, matrix.GetLength(1) - 1] = 'B';
                            matrix[rowB, colB + 1] = '-';
                            matrix[rowB, colB] = '-';
                            colB = matrix.GetLength(1) - 1;

                        }
                    }
                    else
                    {
                        matrix[rowB, colB] = '-';
                        matrix[rowB, colB + 1] = 'B';
                        colB++;
                    }
                }
                else
                {
                    if (collectedBranches.Count > 0)
                    {
                        collectedBranches.Pop();
                    }
                }


                if (branchesCounter == 0)
                {
                    Queue<char> reversed = new Queue<char>(collectedBranches.Reverse());
                    Console.WriteLine($"The Beaver successfully collect {reversed.Count} wood branches: {string.Join(", ", reversed)}.");
                    break;
                }

                command = Console.ReadLine();
            
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
        static bool IsInRange(char[,] matrix, int row, int col)
        {

            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
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
