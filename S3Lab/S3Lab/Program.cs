using System;

namespace S3Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti n:");
            int n = int.Parse(Console.ReadLine());
            string[] v = new string[n];
            Star.View(n, v);
            GC.Collect();
        }
        class Star
        {
          public static string[] Stea(int n, string[] v)
            {
                for (int i = 0; i <= n; i++)
                    for (int j = i; j < n; j++)
                        v[j] += "*";
                return v;
            }
            public static void View(int n, string[] v)
            {
                foreach (string item in Stea(n, v))
                    Console.WriteLine(item);
            }
            ~Star()
            {
                Console.WriteLine("Class Star was destroyed"); 
            }
        }

    }
}
