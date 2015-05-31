using System;
using System.Globalization;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please input elements devided by space... Press Enter to finish");
            string input = String.Empty;
            var key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                input += key.KeyChar;
                key = Console.ReadKey();
            }
            Console.WriteLine(input);
            string[] array = input.Split(' ');
            
            ConsoleKeyInfo command;
            do
            {
                Console.WriteLine("Please select command... Press Escape to exit");
                Console.WriteLine("1 - SelectionSort");
                Console.WriteLine("2 - InsertionSort");
                Console.WriteLine("3 - QuickSort");
                Console.WriteLine("4 - ShakerSort");
                command = Console.ReadKey();
                Console.WriteLine();
                switch (command.Key)
                {
                    case ConsoleKey.Escape:
                        break;
                    default:
                        switch (command.KeyChar.ToString(CultureInfo.InvariantCulture))
                        {
                            case "1":
                                SelectionSort(array);
                                break;
                            case "2":
                                InsertionSort(array);
                                break;
                            case "3":
                                QuickSort(array, 0, array.Length - 1);
                                break;
                            case "4":
                                ShakerSort(array);
                                break;
                            default:
                                Console.WriteLine("Incorrect command. Please try again...");
                                break;
                        }
                        Console.WriteLine(String.Join(" ", array));
                        break;
                }
            } while (command.Key != ConsoleKey.Escape);
            Console.ReadLine();
        }

        public static void SelectionSort(string[] list)
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (String.Compare(list[j], list[min], StringComparison.Ordinal) < 0)
                    {
                        min = j;
                    }
                }
                string dummy = list[i];
                list[i] = list[min];
                list[min] = dummy;
            }
        }

        public static void InsertionSort(string[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                string cur = array[i];
                int j = i;
                while (j > 0 && String.Compare(cur, array[j - 1], StringComparison.Ordinal) < 0)
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = cur;
            }
        }

        static int Partition(string[] array, int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (String.CompareOrdinal(array[i], array[end]) <= 0)
                {
                    string temp = array[marker]; 
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            return marker - 1;
        }

        public static  void QuickSort(string[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(array, start, end);
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);
        }

        static void ShakerSort(string[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                int start = 0;
                int end = array.Length - 1;
                do
                {
                    if (String.CompareOrdinal(array[start], array[start + 1]) > 0)
                    {
                        string temp = array[start];
                        array[start] = array[start + 1];
                        array[start + 1] = temp;
                    }
                    start++;
                    if (String.CompareOrdinal(array[end - 1], array[end]) > 0)
                    {
                        string temp = array[end - 1];
                        array[end - 1] = array[end];
                        array[end] = temp;
                    }
                    end--;
                }
                while (start <= end);
            }
        }
    }
}