using System;

namespace BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 7, 12, -50, 60 };
            BubbleSort(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[i])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                } 
            }
        }
    }
}
