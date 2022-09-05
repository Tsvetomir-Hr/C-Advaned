using System;

namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 8, 9, 10 };

            int index = BinarySearch(numbers, 3);
            Console.WriteLine(index);
        }

        private static int BinarySearch(int[] numbers, int element)
        {
            int low = 0;
            int high = numbers.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2; //the way that we found the middle in an array.

                if (element > numbers[mid])
                {    //go right from mid
                     //low change and high stay the same!!
                    low = mid + 1;
                }
                else if (element < numbers[mid])
                {    // go left from mid
                     //high change and low stay the same !!
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }

            }
            return -1;
        }
    }
}
