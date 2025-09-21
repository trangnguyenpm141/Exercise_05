using System;
using System.Collections.Generic;
using System.Linq;

internal class Exercise_05
{
    private static void Main(string[] args)
    {
        Ex01();
        Ex02();
    }

    /* ================= BAI 1 =================
                Xu ly mang ngau nhien
    */
    static void Ex01()
    {
        Console.WriteLine("\t====BÀI 1====");

        // Tao mang ngau nhien
        Random rnd = new Random();
        int n = 20;
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
            arr[i] = rnd.Next(1, 100);
        Console.WriteLine("Mang ban dau: " + string.Join(", ", arr));

        // 1. Tinh trung binh cac phan tu trong mang
        double avg = arr.Average();
        Console.WriteLine("1. Gia tri trung binh cua cac phan tu mang la: " + avg);

        // 2. Kiem tra mang co chua gia tri X khong
        Console.Write("Nhap gia tri x: ");
        int x = int.Parse(Console.ReadLine());
        bool tonTai = arr.Contains(x); 
        if (tonTai)
        {
            Console.WriteLine("2. Mang co chua gia tri " + x);
        }
        else
        {
            Console.WriteLine("2. Mang khong chua gia tri " + x);
        }

        // 3. Tim vi tri phan tu X
        int index = Array.IndexOf(arr, x);
        if (index != -1)
            Console.WriteLine($"3. Vi tri cua {x}: {index}");
        else
            Console.WriteLine($"3. Khong tim thay {x}");

        // 4. Xoa phan tu X khoi mang
        int[] arrRemoved = arr.Where(val => val != x).ToArray();
        Console.WriteLine($"4. Mang sau khi xoa {x}: " + string.Join(", ", arrRemoved));

        // 5. Tim min, max
        Console.WriteLine($"5. Gia tri nho nhat cua mang la: {arr.Min()}");
        Console.WriteLine($"5. Gia tri lon nhat cua mang la: {arr.Max()}");

        // 6. Đao nguoc mang
        int[] reversed = (int[])arr.Clone();
        Array.Reverse(reversed);
        Console.WriteLine("6. Mang dao nguoc: " + string.Join(", ", reversed));

        // 7. Tim gia tri trung lap
        var duplicates = arr.GroupBy(v => v).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
        Console.WriteLine("7. Cac gia tri trung lap: " + (duplicates.Count > 0 ? string.Join(", ", duplicates) : "Khong co trung lap"));

        // 8. Xoa phan tu trung lap
        int[] unique = arr.Distinct().ToArray();
        Console.WriteLine("8. Mang sau khi xoa trung lap: " + string.Join(", ", unique));
    }

    /* ================= BÀI 2 =================
       1. Bubble Sort
       2. Linear Search trong câu
    */
    static void Ex02()
    {
        Console.WriteLine("\n===== BÀI 2 =====");

        // 1. Bubble Sort
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        Console.WriteLine("Nhap 10 so nguyen:");
        int[] arr = new int[10];
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"So thu {i + 1}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        BubbleSort(arr);
        Console.WriteLine("Mang sau khi sap xep Bubble Sort: " + string.Join(", ", arr));

        // 2. Linear Search trong cau
        static bool LinearSearch(string[] words, string target)
        {
            foreach (var word in words)
            {
                if (word.Equals(target, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
        Console.Write("\nNhap mot cau: ");
        string sentence = Console.ReadLine();
        Console.Write("Nhap mot tu can tim: ");
        string word = Console.ReadLine();

        string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        bool found = LinearSearch(words, word);
        if (found)
        {
            Console.WriteLine($"Tu \"{word}\" xuat hien trong cau.");
        }
        else
        {
            Console.WriteLine($"Từ \"{word}\" khong xuat hien trong cau.");
        }
    }
}
