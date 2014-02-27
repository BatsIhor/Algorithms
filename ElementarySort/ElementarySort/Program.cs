using System;
using System.Security;
using System.Xml;

namespace ElementarySort
{
    public class Example
    {
        private static IComparable[] aux;

        public static void insertionSort(IComparable[] a)
        {
            // Sort a[] into increasing order.
            int N = a.Length;
            for (int i = 1; i < N; i++)
            { // Insert a[i] among a[i-1], a[i-2], a[i-3]... ..
                for (int j = i; j > 0 && less(a[j], a[j - 1]); j--)
                {
                    exch(a, j, j - 1);
                    show(a);
                }
            }
        }

        public static void shellSort(IComparable[] a)
        {
            // Sort a[] into increasing order.
            int N = a.Length;
            int h = 1;
            while (h < N / 3) h = 3 * h + 1; // 1, 4, 13, 40, 121, 364, 1093, ...
            while (h >= 1)
            { // h-sort the array.
                for (int i = h; i < N; i++)
                { // Insert a[i] among a[i-h], a[i-2*h], a[i-3*h]... .
                    for (int j = i; j >= h && less(a[j], a[j - h]); j -= h)
                    {
                        exch(a, j, j - h);
                        show(a);
                    }
                }
                h = h / 3;
            }
        }

        public static void selectSort(IComparable[] a)
        {
            // Sort a[] into increasing order.
            int N = a.Length; // array length
            for (int i = 0; i < N; i++)
            {
                // Exchange a[i] with smallest entry in a[i+1...N).
                int min = i; // index of minimal entr.
                for (int j = i + 1; j < N; j++)
                    if (less(a[j], a[min]))
                    {
                        min = j;
                    }
                exch(a, i, min);
                show(a);
            }
        }

        #region MergeSort

        public static void mergeSort(IComparable[] a)
        {
            sort(a);
        }

        public static void sort(IComparable[] a)
        {
            aux = new IComparable[a.Length];
            sort(a, aux, 0, a.Length - 1);

            //int N = a.Length;
            //aux = new IComparable[N];

            //for (int sz = 1; sz < N; sz = sz + sz)
            //    for (int lo = 0; lo < N - sz; lo += sz + sz)
            //    {
            //        merge(a, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, N - 1));
            //    }
        }

        public static void sort(IComparable[] a, IComparable[] aux, int lo, int hi)
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo)/2;
            sort(a, aux, lo, mid);
            sort(a, aux, mid + 1, hi);
            merge(a, aux, lo, mid, hi);
        }

        private static void merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi)
        {
            for (int k = 0; k < hi; k++)
            {
                aux[k] = a[k];
            }

            int i = lo;
            int j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i >= mid)
                {
                    a[k] = aux[j++];
                }
                else if (j >= hi)
                {
                    a[k] = aux[i++];
                }
                else if (less(aux[j], aux[i]))
                {
                    a[k] = aux[j++];
                }
                else
                {
                    a[k] = aux[i++];
                }
                show(a);
                show(aux);
            }
        }

        #endregion
        
        private static bool less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        private static void exch(IComparable[] a, int i, int j)
        {
            IComparable t = a[i]; a[i] = a[j]; a[j] = t;
        }

        private static void show(IComparable[] a)
        { // Print the array, on a single line.
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        public static bool isSorted(IComparable[] a)
        { // Test whether the array entries are in order.
            for (int i = 1; i < a.Length; i++)
                if (less(a[i], a[i - 1])) return false;
            return true;
        }

        public static void Main(String[] args)
        { // Read strings from standard input, sort them, and print.

            IComparable[] a = new IComparable[] { 22, 79, 67, 55, 99, 23, 41, 21, 71, 82, 87, 25 };

            mergeSort(a);
            //String[] a = new[]
            //{
            //    "NENA", "MIMS", "CARS", "JAYZ", "WEEN", "DOOM", "STYX", "SEAL", "BUSH", "CHER", "RUSH", "FUEL", "AQUA",
            //    "CAKE", "DEVO", "TACO"
            //};

            //insertionSort(a);

            //a = new[]
            //{
            //    "NENA", "MIMS", "CARS", "JAYZ", "WEEN", "DOOM", "STYX", "SEAL", "BUSH", "CHER", "RUSH", "FUEL", "AQUA",
            //    "CAKE", "DEVO", "TACO"
            //};

            //Console.Clear();
            //shellSort(a);

            //a = new[]
            //{
            //    "NENA", "MIMS", "CARS", "JAYZ", "WEEN", "DOOM", "STYX", "SEAL", "BUSH", "CHER", "RUSH", "FUEL", "AQUA",
            //    "CAKE", "DEVO", "TACO"
            //};

            //Console.Clear();
            //selectSort(a);

            show(a);
            Console.ReadLine();

        }
    }
}
