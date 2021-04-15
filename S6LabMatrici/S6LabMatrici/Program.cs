using System;

namespace S6LabMatrici
{
    class Program
    {
        public static Random rnd = new Random(10);
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti numarul de linii (n) si numarul de coloane (m) ale matricei");
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[,] A = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    A[i, j] = rnd.Next(10);
            }
            for (int a = 0; a < n; a++)
            {
                for (int b = 0; b < m; b++)
                    Console.Write(A[a, b] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("Pentru a aduna cu alta matrice apasati tasta '1'");
            Console.WriteLine("Pentru a scadea cu alta matrice apasati tasta '2'");
            Console.WriteLine("Pentru a inmulti cu alta matrice apasati tasta '3'");
            Console.WriteLine("Pentru a ridica matricea introdusa la o anumita putere apasati tasta '4'");
            Console.WriteLine("Pentru a afisa inversa matricei introduse apasati tasta '5'");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                        int[,] res1 = suma(A);
                    if (res1 == null)
                    {
                        Console.WriteLine("Introduceti valori valide pentru m si n");
                    }
                    else {
                        Console.WriteLine("Suma este:");
                        for (int a = 0; a < n; a++)
                        {
                            for (int b = 0; b < m; b++)
                            {
                                Console.Write(res1[a, b] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
                    
                case 2:
                    int[,] res2 = diferenta(A);
                    if(res2 == null)
                        Console.WriteLine("Introduceti valori valide pentru m si n");
                    else {
                        Console.WriteLine("Diferenta este:");
                        for (int a = 0; a < n; a++)
                        {
                            for (int b = 0; b < m; b++)
                            {
                                Console.Write(res2[a, b] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
                case 3:
                        int[,] res3 = produsul(A);
                    if (res3 == null)
                        Console.WriteLine("Introduceti valori valide pentru m si n");
                    else {
                        Console.WriteLine("Produsul este:");
                        for (int a = 0; a < n; a++)
                        {
                            for (int b = 0; b < m; b++)
                            {
                                Console.Write(res3[a, b] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
                case 4:
                    int[,] res4 = power(A);
                    if (res4 == null)
                        Console.WriteLine("Introduceti valori valide pentru m si n");
                    else
                    {
                        Console.WriteLine("A ridicat la puterea indicata este:");
                        for (int a = 0; a < n; a++)
                        {
                            for (int b = 0; b < m; b++)
                            {
                                Console.Write(res4[a, b] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
                case 5:
                    int[,] res5 = inversa(A);
                    if (res5 == null)
                        Console.WriteLine("Matricea nu este inversabila");
                    else
                    {
                        Console.WriteLine("A ridicat la puterea indicata este:");
                        for (int a = 0; a < n; a++)
                        {
                            for (int b = 0; b < m; b++)
                            {
                                Console.Write(res5[a, b] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Introduceti o tasta valida");
                    break;
            }
            static int[,] suma(int[,] A)
            {
                Console.WriteLine("Introduceti numarul de linii (n) si numarul de coloane (m) ale celei de-a doua matrici");
                int n = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine());
                int[,] B = new int[n, m];
                int randuriA = A.GetLength(0);
                int coloaneA = A.GetLength(1);
                if (randuriA == n && coloaneA == m)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                            B[i, j] = rnd.Next(10);
                    }
                    for (int a = 0; a < n; a++)
                    {
                        for (int b = 0; b < m; b++)
                            Console.Write(B[a,b] + " ");
                        Console.WriteLine();
                    }
                    int[,] sumaAB = new int[n, m];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                            sumaAB[i, j] = A[i, j] + B[i, j];
                    }
                    return sumaAB;
                }
                else
                    return null;
            }
            static int[,] diferenta(int[,] A)
            {
                Console.WriteLine("Introduceti numarul de linii (n) si numarul de coloane (m) ale celei de-a doua matrici");
                int n = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine());
                int[,] B = new int[n, m];
                int randuriA = A.GetLength(0);
                int coloaneA = A.GetLength(1);
                if (randuriA == n && coloaneA == m)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                            B[i, j] = rnd.Next(10);
                    }
                    for (int a = 0; a < n; a++)
                    {
                        for (int b = 0; b < m; b++)
                            Console.Write(B[a, b] + " ");
                        Console.WriteLine();
                    }
                    int[,] diferentaAB = new int[n, m];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                            diferentaAB[i, j] = A[i, j] - B[i, j];
                    }
                    return diferentaAB;
                }
                else
                    return null;
            }
            static int[,] produsul(int[,] A)
            {
                Console.WriteLine("Introduceti numarul de linii (n) si numarul de coloane (m) ale celei de-a doua matrici");
                int n = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine());
                int[,] B = new int[n, m];
                int randuriA = A.GetLength(0);
                int coloaneA = A.GetLength(1);
                if (coloaneA == n && m == randuriA)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                            B[i, j] = rnd.Next(10);
                    }
                    for (int a = 0; a < n; a++)
                    {
                        for (int b = 0; b < m; b++)
                            Console.Write(B[a, b] + " ");
                        Console.WriteLine();
                    }
                    int[,] produsulAB = new int[n, n];
                    for (int i = 0; i <n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        { produsulAB[i, j] = 0;
                            for(int k = 0; k<n; k++)
                                    produsulAB[i, j] += A[i, k] * B[k, j];
                                }
                    }
                    return produsulAB;
                }
                else
                    return null;
            }
            static int[,] power(int [,]A)
            {
                Console.WriteLine("Introduceti puterea la care doriti sa ridicati matricea");
                int n = int.Parse(Console.ReadLine());
                int randuriA = A.GetLength(0);
                int coloaneA = A.GetLength(1);
                int[,] B = new int[randuriA, coloaneA];
                if (coloaneA == randuriA)
                {
                    int[,] powerA = new int[randuriA, coloaneA];
                    int contor = 1;
                    while (contor < n)
                    {
                        contor++;
                        if (contor == 2)
                            B = A;
                        else
                            B = powerA;
                        for (int i = 0; i < randuriA; i++)
                        {
                            for (int j = 0; j < coloaneA; j++)
                            {
                                powerA[i, j] = 0;
                                for (int k = 0; k < randuriA; k++)
                                    powerA[i, j] += A[i, k] * B[k, j];
                            }
                        }
                    }
                    return powerA;
                }
                else
                    return null;
            }
          static int[,] inversa(int[,] A)
            {
                int i, j, l, n;
                int[,] a = new int[100,200];
                for (int b = 0; b < A.GetLength(0); b++)
                {
                    for (int c = 0; c <A.GetLength(0); c++)
                    {
                        a[b, c] = A[b, c];
                    }
                }
                float d = 1;
                int randuriA = A.GetLength(0);
                int coloaneA = A.GetLength(1);
                if (randuriA == coloaneA)
                {
                    n = randuriA;
                    for (i = 1; i <= n; i++)
                        for (j = n + 1; j <= 2 * n; j++)
                            if (i == (j - n))
                                a[i, j] = 1;
                            else
                                a[i, j] = 0;
                    for (i = 1; (i <= n) && (d != 0); i++)
                    {
                        for (j = i; (j <= n) && (a[j, i] == 0); j++) ;
                        if (j > n)
                            d = 0;
                        else
                        if (j > i)
                            for (l = 1; l <= 2 * n; l++)
                                a[i, l] += a[j, l];
                        if (a[i, i] != 1)
                            for (l = 2 * n; l >= 1; l--)
                                a[i, l] /= a[i, i];
                        for (j = 1; j <= n; j++)
                            if (j != i)
                                for (l = 2 * n; l >= i; l--)
                                    a[j, l] -= a[j, i] * a[i, l];
                    }
                    if (d == 0)
                        return null;
                    else
                        return A;
                }
                else return null;
            }
        }
    }
}
