using System;
using System.Linq;
using System.Text;

public class Mergesort
{
    private static int[] aux;

    public static int Sort(int[] arr)
    {
        aux = new int[arr.Length];
        return Sort(arr, 0, arr.Length - 1);
    }

    private static int Merge(int[] arr, int left, int mid, int right)
    {
        int invCount = 0;
        int i = left;
        int j = mid;
        int l = left;

        while ((i <= mid - 1) && (j <= right))
        {
            if (arr[i].CompareTo(arr[j]) != 1)
            {
                aux[l++] = arr[i++];
            }
            else
            {
                aux[l++] = arr[j++];

                invCount = invCount + (mid - i);
            }
        }

        while (i <= mid - 1)
        {
            aux[l++] = arr[i++];
        }

        while (j <= right)
        {
            aux[l++] = arr[j++];
        }

        for (i = left; i <= right; i++)
        {
            arr[i] = aux[i];
        }

        return invCount;
    }

    private static int Sort(int[] arr, int left, int right)
    {
        int invCount = 0;

        if (left < right)
        {
            int mid = (right + left) / 2;
            invCount = Sort(arr, left, mid);
            invCount += Sort(arr, mid + 1, right);

            invCount += Merge(arr, left, mid + 1, right);
        }

        return invCount;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int result = Mergesort.Sort(arr);

        Console.WriteLine(result);
    }
}