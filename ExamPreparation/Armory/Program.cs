using System;
using System.Collections.Generic;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int rowA = 0;
            int colA = 0;
            int swordCounter = 0;
            int[] mirror1 = new int[2];
            int[] mirror2 = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                List<char> output = new List<char>();
                foreach (char ch in input)
                {
                    output.Add(ch);
                }
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = output[col];
                    if (matrix[row, col] == 'A')
                    {
                        rowA = row;
                        colA = col;
                    }
                    if (char.IsDigit(matrix[row, col]))
                    {
                        swordCounter++;
                    }

                }

            }
            int moneySpent = 0;
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "up" && IsInRange(matrix, rowA - 1, colA))
                {
                    if (char.IsDigit(matrix[rowA - 1, colA]))
                    {
                        //buy sword
                        string number = matrix[rowA - 1, colA].ToString();
                        moneySpent += int.Parse(number);
                        matrix[rowA, colA] = '-';
                        matrix[rowA - 1, colA] = 'A';
                        rowA--;
                    }
                    else if (matrix[rowA - 1, colA] == 'M')
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA - 1, colA] = '-';
                        int rowTeleport = 0;
                        int colTeleport = 0;
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {

                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'M')
                                {
                                    rowTeleport = row;
                                    colTeleport = col;
                                }
                            }

                        }
                        matrix[rowTeleport, colTeleport] = 'A';
                        rowA = rowTeleport;
                        colA = colTeleport;

                    }
                    else
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA - 1, colA] = 'A';
                        rowA--;
                    }
                }
                else if (command == "down" && IsInRange(matrix, rowA + 1, colA))
                {
                    if (char.IsDigit(matrix[rowA + 1, colA]))
                    {
                        //buy sword
                        string number = matrix[rowA + 1, colA].ToString();
                        moneySpent += int.Parse(number);
                        matrix[rowA, colA] = '-';
                        matrix[rowA + 1, colA] = 'A';
                        rowA++;
                    }
                    else if (matrix[rowA + 1, colA] == 'M')
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA + 1, colA] = '-';
                        int rowTeleport = 0;
                        int colTeleport = 0;
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {

                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'M')
                                {
                                    rowTeleport = row;
                                    colTeleport = col;
                                }
                            }

                        }
                        matrix[rowTeleport, colTeleport] = 'A';
                        rowA = rowTeleport;
                        colA = colTeleport;

                    }
                    else
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA + 1, colA] = 'A';
                        rowA++;
                    }
                }
                else if (command == "left" && IsInRange(matrix, rowA, colA - 1))
                {
                    if (char.IsDigit(matrix[rowA, colA - 1]))
                    {
                        string number = matrix[rowA, colA - 1].ToString();
                        moneySpent += int.Parse(number);
                        matrix[rowA, colA] = '-';
                        matrix[rowA, colA - 1] = 'A';
                        colA--;
                    }
                    else if (matrix[rowA - 1, colA] == 'M')
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA, colA - 1] = '-';
                        int rowTeleport = 0;
                        int colTeleport = 0;
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {

                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'M')
                                {
                                    rowTeleport = row;
                                    colTeleport = col;
                                }
                            }

                        }
                        matrix[rowTeleport, colTeleport] = 'A';
                        rowA = rowTeleport;
                        colA = colTeleport;

                    }
                    else
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA, colA - 1] = 'A';
                        colA--;
                    }
                }
                else if (command == "right" && IsInRange(matrix, rowA, colA + 1))
                {
                    if (char.IsDigit(matrix[rowA, colA + 1]))
                    {
                        string number = matrix[rowA, colA + 1].ToString();
                        moneySpent += int.Parse(number);
                        matrix[rowA, colA] = '-';
                        matrix[rowA, colA + 1] = 'A';
                        colA++;
                    }
                    else if (matrix[rowA + 1, colA] == 'M')
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA, colA + 1] = '-';
                        int rowTeleport = 0;
                        int colTeleport = 0;
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {

                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'M')
                                {
                                    rowTeleport = row;
                                    colTeleport = col;
                                }
                            }

                        }
                        matrix[rowTeleport, colTeleport] = 'A';
                        rowA = rowTeleport;
                        colA = colTeleport;

                    }
                    else
                    {
                        matrix[rowA, colA] = '-';
                        matrix[rowA, colA + 1] = 'A';
                        colA++;
                    }
                }
                else
                {

                    //wrong index and left the field.
                    matrix[rowA, colA] = '-';
                    Console.WriteLine("I do not need more swords!");
                    break;
                }
                if (moneySpent >= 65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    break;
                }
            }
            Console.WriteLine($"The king paid {moneySpent} gold coins.");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
        static bool IsInRange(char[,] matrix, int row, int col)
        {

            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }


    }
}

