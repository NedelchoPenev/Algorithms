using System;
using System.Linq;
using System.Text;

public static class QuickSort<T> where T: IComparable<T>
{
    public static void Sort(T[] arr)
    {
        Sort(arr, 0, arr.Length - 1);
    }

    private static void Sort(T[] arr, int lo, int hi)
    {
        if (lo >= hi)
        {
            return;
        }

        int pivot = Partition(arr, lo, hi);
        Sort(arr, lo, pivot - 1);
        Sort(arr, pivot + 1, hi);
    }

    private static int Partition(T[] arr, int lo, int hi)
    {
        if (lo >= hi)
        {
            return lo;
        }

        int i = lo;
        int j = hi + 1;

        while (true)
        {
            while (IsLess(arr[++i], arr[lo]))
            {
                if (i == hi)
                {
                    break;
                }
            }

            while (IsLess(arr[lo], arr[--j]))
            {
                if (j == lo)
                {
                    break;
                }
            }

            if (i >= j)
            {
                break;
            }

            Swap(arr, i, j);
        }

        Swap(arr, lo, j);
        return j;
    }

    private static void Swap(T[] arr, int index, int storeIndex)
    {
        if (index == storeIndex)
        {
            return;
        }

        T temp = arr[index];
        arr[index] = arr[storeIndex];
        arr[storeIndex] = temp;
    }

    private static bool IsLess(T elem1, T elem2)
    {
        return elem1.CompareTo(elem2) < 0;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        QuickSort<int>.Sort(arr);

        StringBuilder builder = new StringBuilder();
        foreach (var num in arr)
        {
            builder.Append(num + " ");
        }

        Console.WriteLine(builder);
    }
}