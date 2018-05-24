using System;
using System.Linq;

public class Sorting<T> where T : IComparable
{
    public static void InsertionSort(T[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int prev = i - 1;
            int curr = i;

            while (true)
            {
                if (prev < 0 || IsLess(arr[prev], arr[curr]))
                {
                    break;
                }

                Swap(arr, prev, curr);
                prev--;
                curr--;
            }
        }
    }

    private static void Swap(T[] arr, int prev, int curr)
    {
        T temp = arr[curr];
        arr[curr] = arr[prev];
        arr[prev] = temp;
    }

    private static bool IsLess(T elem1, T elem2)
    {
        return elem1.CompareTo(elem2) < 0;
    }
}

public class Program
{
    private static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Sorting<int>.InsertionSort(arr);

        Console.WriteLine(string.Join(" ", arr));
    }
}

