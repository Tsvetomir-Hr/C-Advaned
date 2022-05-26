using System;
using System.Linq;

namespace JaggedArrayModificator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = ReadJaggedArray(rows);
            string command = Console.ReadLine();

            while (command != "END")
            {
                var token = command.Split();
                string action = token[0];
                int row = int.Parse(token[1]);
                int col = int.Parse(token[2]);
                int value = int.Parse(token[3]);

                if (row < 0 || col < 0 || row >= jagged.Length || col >= jagged[row].Length)
                {
                    Console.WriteLine($"Invalid coordinates");
                }
                else if (action == "Add")
                {
                    jagged[row][col] += value;
                }
                else if (action == "Subtract")
                {
                    jagged[row][col] -= value;
                }
                command = Console.ReadLine();
            }
            PrintJagged(jagged);
        }

        static int[][] ReadJaggedArray(int rows)
        {
            int[][] jagged = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jagged[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();

            }
            return jagged;
        }
        static void PrintJagged(int[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine($"{string.Join(" ", jagged[row])}");
            }
        }
    }
}
