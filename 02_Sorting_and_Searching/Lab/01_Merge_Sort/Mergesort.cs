using System;
using System.Linq;
using System.Text;

public class Mergesort<T>
    where T : IComparable
{
    private static T[] aux;

    public static void Sort(T[] arr)
    {
        aux = new T[arr.Length];
        Sort(arr, 0, arr.Length - 1);
    }

    private static void Merge(T[] arr, int low, int mid, int hi)
    {
        if (IsLess(arr[mid], arr[mid + 1]))
        {
            return;
        }

        for (int index = low; index <= hi; index++)
        {
            aux[index] = arr[index];
        }

        int i = low;
        int j = mid + 1;
        for (int k = low; k <= hi; k++)
        {
            if (i > mid)
            {
                arr[k] = aux[j++];
            }
            else if (j > hi)
            {
                arr[k] = aux[i++];
            }
            else if (IsLess(aux[i], aux[j]))
            {
                arr[k] = aux[i++];
            }
            else
            {
                arr[k] = aux[j++];
            }
        }
    }

    private static void Sort(T[] arr, int low, int hi)
    {
        if (low >= hi)
        {
            return;
        }

        int mid = low + (hi - low) / 2;
        Sort(arr, low, mid);
        Sort(arr, mid + 1, hi);
        Merge(arr, low, mid, hi);
    }

    private static bool IsLess(T elem1, T elem2)
    {
        return elem1.CompareTo(elem2) < 0;
    }

    public static bool IsSorted(T[] arr, int lo, int hi)
    {
        for (int i = lo + 1; i < hi; i++)
        {
            if (IsLess(arr[i], arr[i - 1]))
            {
                return false;
            }
        }

        return true;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Mergesort<int>.Sort(arr);

        StringBuilder builder = new StringBuilder();
        foreach (var num in arr)
        {
            builder.Append(num + " ");
        }

        Console.WriteLine(builder);
    }
}