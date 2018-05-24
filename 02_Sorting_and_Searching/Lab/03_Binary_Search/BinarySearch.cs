using System;
using System.Linq;

using _03_Binary_Search;

namespace _03_Binary_Search
{
    public static class BinarySearch
    {
        public static int BinarySearchIterative(int[] arr, int key, int low, int high)
        {
            int index = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (key < arr[mid])
                {
                    high = mid - 1;
                }
                else if (key > arr[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return index;
        }

        public static int BinarySearchRecursive(int[] arr, int key, int low, int high)
        {
            if (low > high)
            {
                return -1;
            }

            int mid = low + (high - low) / 2;

            if (key == arr[mid])
            {
                return mid;
            }
            else
            {
                if (key < arr[mid])
                {
                    return BinarySearchRecursive(arr, key, low, mid - 1);
                }
                else
                {
                    return BinarySearchRecursive(arr, key, mid + 1, high);
                }
            }
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int x = int.Parse(Console.ReadLine());

        int index = BinarySearch.BinarySearchIterative(arr, x, 0, arr.Length - 1);
        Console.WriteLine(index);
    }
}