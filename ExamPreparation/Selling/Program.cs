using System;
using System.Collections.Generic;
using System.Linq;

namespace Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int rowA = 0;
            int colA = 0;
            int MoneyCollected = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input0 = Console.ReadLine();
                List<char> input = new List<char>();
                foreach (char ch in input0)
                {
                    input.Add(ch);
                }
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'S')
                    {
                        rowA = row;
                        colA = col;
                    }

                }
            }
            while (MoneyCollected < 50)
            {
                string command = Console.ReadLine();

                if (command == "up" && IsInRange(matrix, rowA - 1, colA))
                {
                    if (char.IsDigit(matrix[rowA - 1, colA]))
                    {
                        string number = matrix[rowA - 1, colA].ToString();
                        MoneyCollected += int.Parse(number);
                        matrix[rowA, colA] = '-';
                        matrix[rowA - 1, colA] = 'S';
                        rowA--;
                    }
                    else if (matrix[rowA - 1, colA] == 'O')
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA - 1, colA] = '-';
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'O')
                                {
                                    matrix[row, col] = 'S';
                                    rowA = row;
                                    colA = col;
                                }
                            }
                        }
                    }
                    else if (matrix[rowA - 1, colA] == '-')
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA - 1, colA] = 'S';
                        rowA--;
                    }
                }
                else if (command == "down" && IsInRange(matrix, rowA + 1, colA))
                {
                    if (char.IsDigit(matrix[rowA + 1, colA]))
                    {

                        string number = matrix[rowA + 1, colA].ToString();
                        MoneyCollected += int.Parse(number);
                        matrix[rowA, colA] = '-';
                        matrix[rowA + 1, colA] = 'S';
                        rowA++;
                    }
                    else if (matrix[rowA + 1, colA] == 'O')
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA + 1, colA] = '-';
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'O')
                                {
                                    matrix[row, col] = 'S';
                                    rowA = row;
                                    colA = col;
                                }
                            }
                        }
                    }
                    else if (matrix[rowA + 1, colA] == '-')
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA + 1, colA] = 'S';
                        rowA++;
                    }
                }
                else if (command == "left" && IsInRange(matrix, rowA, colA - 1))
                {
                    if (char.IsDigit(matrix[rowA, colA - 1]))
                    {

                        string number = matrix[rowA, colA - 1].ToString();
                        MoneyCollected += int.Parse(number);
                        matrix[rowA, colA] = '-';
                        matrix[rowA, colA - 1] = 'S';
                        colA--;
                    }
                    else if (matrix[rowA, colA - 1] == 'O')
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA, colA - 1] = '-';
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'O')
                                {
                                    matrix[row, col] = 'S';
                                    rowA = row;
                                    colA = col;
                                }
                            }
                        }
                    }
                    else if (matrix[rowA, colA - 1] == '-')
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA, colA - 1] = 'S';
                        colA--;
                    }
                }
                else if (command == "right" && IsInRange(matrix, rowA, colA + 1))
                {
                    if (char.IsDigit(matrix[rowA, colA + 1]))
                    {
                        string number = matrix[rowA, colA + 1].ToString();
                        MoneyCollected += int.Parse(number);
                        matrix[rowA, colA] = '-';
                        matrix[rowA, colA + 1] = 'S';
                        colA++;
                    }
                    else if (matrix[rowA, colA + 1] == 'O')
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA, colA + 1] = '-';
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'O')
                                {
                                    matrix[row, col] = 'S';
                                    rowA = row;
                                    colA = col;
                                }
                            }
                        }
                    }
                    else if (matrix[rowA, colA + 1] == '-')
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA, colA + 1] = 'S';
                        colA++;
                    }
                }
                else
                {
                    matrix[rowA, colA] = '-';
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }


            }
            if (MoneyCollected >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {MoneyCollected}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
            static bool IsInRange(char[,] matrix, int row, int col)
            {

                return row >= 0 && row < matrix.GetLength(0) &&
                    col >= 0 && col < matrix.GetLength(1);
            }
        }
    }
}
