using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 20, 25, 22, 24, 52, 67, 31, 96 };

            Console.WriteLine("Original Array: " + string.Join(", ", array));

            // Apply Quicksort in ascending order
            Quicksort(array, 0, array.Length - 1);

            Console.WriteLine("Sorted Array: " + string.Join(", ", array));

            // Check if the array is sorted correctly
            bool isSorted = IsArraySorted(array);
            Console.WriteLine("Is Array Sorted Correctly? " + isSorted);

            // Create arrays of different sizes with random integers
            int[] array20 = GenerateRandomArray(20);
            int[] array30 = GenerateRandomArray(30);
            int[] array50 = GenerateRandomArray(50);

            // Perform Quicksort and measure time for each array size
            MeasureTimeAndSort(array20, "Array of 20 elements");
            MeasureTimeAndSort(array30, "Array of 30 elements");
            MeasureTimeAndSort(array50, "Array of 50 elements");
        }

        static void Quicksort(int[] array, int low, int high)
        {
            // Quicksort algorithm implementation
            if (low < high)
            {
                int partitionIndex = Partition(array, low, high);
                Quicksort(array, low, partitionIndex - 1);
                Quicksort(array, partitionIndex + 1, high);
            }
        }

        static int Partition(int[] array, int low, int high)
        {
            // Partition method implementation
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }

            Swap(ref array[i + 1], ref array[high]);
            return i + 1;
        }

        static void Swap(ref int a, ref int b)
        {
            // Swap method to swap two elements
            int temp = a;
            a = b;
            b = temp;
        }

        static bool IsArraySorted(int[] arr)
        {
            // Check if the array is sorted correctly
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        static void MeasureTimeAndSort(int[] array, string arrayDescription)
        {
            // Clone the array to keep the original for validation
            int[] originalArray = (int[])array.Clone();

            // Measure the time it takes to perform Quicksort
            Stopwatch stopwatch = Stopwatch.StartNew();
            Quicksort(array, 0, array.Length - 1);
            stopwatch.Stop();

            // Validate if the array is sorted correctly
            ValidateSorting(originalArray, array);

            // Print results
            Console.WriteLine($"{arrayDescription}:");
            Console.WriteLine($"Time taken to sort: {stopwatch.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine();
        }

        static int[] GenerateRandomArray(int size)
        {
            // Generate an array of random integers
            int[] array = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 100); // Generate random integers between 1 and 100
            }

            return array;
        }

        static void ValidateSorting(int[] originalArray, int[] sortedArray)
        {
            // Validate if the array is sorted correctly
            Array.Sort(originalArray);
            for (int i = 0; i < originalArray.Length; i++)
            {
                if (originalArray[i] != sortedArray[i])
                {
                    throw new InvalidOperationException("Array not sorted correctly.");
                }
            }
        }
    }
}