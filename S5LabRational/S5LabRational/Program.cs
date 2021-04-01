using System;
        /*Acest program functioneaza corespunzator pentru introducerea unui numar 
         * rational sub forma a/b, la introducerea acestuia sub o alta forma 
         va lansa eroare datorita modului de extragere a numerelor din string.*/
namespace S5LabRational
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti un numar Rational sub forma a/b");
            Console.WriteLine("Pentru a aduna doua numere Rationale apasati tasta '1'");
            Console.WriteLine("Pentru a scadea doua numere Rationale apasati tasta '2'");
            Console.WriteLine("Pentru a inmulti doua numere Rationale apasati tasta '3'");
            Console.WriteLine("Pentru a ridica la o anumita putere un numar Rational apasati tasta '4'");
            Console.WriteLine("Pentru a aduce un numar Rational la forma ireductibila apasati tasta '5'");
            Console.WriteLine("Pentru a compara doua numere Rationale apasati tasta '6'");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti primul numar Rational:");
            string firstNumber = Console.ReadLine();
            string[] fword = firstNumber.Split('/');
            int firstNumarator = Convert.ToInt32(fword[0]);
            int firstNumitor = Convert.ToInt32(fword[1]);
            Rational r1 = new Rational(firstNumarator, firstNumitor);
            if (input == 1 || input == 2 || input == 3 || input == 6)
            {
                Console.WriteLine("Introduceti al doilea numar Rational:");
                string secondNumber = Console.ReadLine();
                string[] sword = secondNumber.Split('/');
                int secondNumarator = Convert.ToInt32(sword[0]);
                int secondNumitor = Convert.ToInt32(sword[1]);
                Rational r2 = new Rational(secondNumarator, secondNumitor);
                Rational r3 = r1 + r2;
                Rational r4 = r1 - r2;
                Rational r5 = r1 * r2;
                View(r1, r2, r3, r4, r5, input, 0);
            }
            if (input == 4 || input == 5)
            {
                int n = 0;
                if (input == 4)
                {
                    Console.WriteLine("De cate ori doriti sa multiplicati numarul Rational introdus?");
                    Console.WriteLine("n=");
                    n = int.Parse(Console.ReadLine());
                }
                Rational r2 = new Rational(1, 1);
                Rational r3 = r1 + r2;
                Rational r4 = r1 - r2;
                Rational r5 = r1 * r2;
                View(r1, r2, r3, r4, r5, input, n);
            }
        }
        public static void View(Rational r1, Rational r2, Rational r3, Rational r4, Rational r5, int input, int n)
        {
            switch (input)
            {
                case 1:
                    Console.WriteLine($" Suma = {r3.numarator} / {r3.numitor}");
                    break;
                case 2:
                    Console.WriteLine($" Suma = {r4.numarator} / {r4.numitor}");
                    break;
                case 3:
                    Console.WriteLine($" Suma = {r5.numarator} / {r5.numitor}");
                    break;
                case 4:
                    Console.WriteLine("Ridicarea la putere a numarului Rational introdus este " + Power(r1, n));

                    break;
                case 5:
                    Console.WriteLine("Forma ireductibila = " + formaIreductibila(r1));
                    break;
                case 6:
                    int produs1, produs2;
                    produs1 = r1.numarator * r2.numitor;
                    produs2 = r2.numarator * r1.numitor;
                    if(produs1 == produs2)
                        Console.WriteLine("Numerele sunt egale");
                    if(r1.numarator/r1.numitor>r2.numarator/r1.numitor)
                        Console.WriteLine($"{r1.numarator}/{r1.numitor} > {r2.numarator}/{r2.numitor}");
                    if (r1.numarator / r1.numitor < r2.numarator / r1.numitor)
                        Console.WriteLine($"{r1.numarator}/{r1.numitor} < {r2.numarator}/{r2.numitor}");
                    break;
                default:
                    break;
            }
        }
        public static string formaIreductibila(Rational r1)
        {
            int numarator = r1.numarator;
            int numitor = r1.numitor;
            int cmmdc = 2;
            while (cmmdc > 1)
            {
                int a, b;
                a = numarator;
                b = numitor;

                while (b != 0)
                {
                    int rest = a % b;
                    a = b;
                    b = rest;
                }
                cmmdc = a;
                numarator = numarator / cmmdc;
                numitor = numitor / cmmdc;
            }
            string result;
            if (numitor == 1)
                result = Convert.ToString(numarator);
            else
                result = $"{numarator}/{numitor}";
            return result;
        }
        public static string Power(Rational r1, int n)
        {

            int N = (int)Math.Pow(r1.numarator, n);
            int num = (int)Math.Pow(r1.numitor, n);
            string result = $"{N}/{num})";
            return result;
        }
    }
    class Rational
    {
        public int numarator { get; set; }
        public int numitor { get; set; }
        public Rational(int numarator, int numitor)
        {
            this.numarator = numarator;
            this.numitor = numitor;
                }
        public static Rational operator +(Rational r1, Rational r2)
        {
            int produs = r1.numitor * r2.numitor;
            int numitor1 = r1.numitor;
            int numitor2 = r2.numitor;
            while(numitor2 != 0)
            {
                int rest = numitor1 % numitor2;
                numitor1 = numitor2;
                numitor2 = rest;
            }
            int cmmmc = produs / numitor1;
            int amplificatorR1 = cmmmc / r1.numitor;
            int amplificatorR2 = cmmmc / r2.numitor;
            int numaratorResult = amplificatorR1 * r1.numarator + amplificatorR2 * r2.numarator;
            int numitorResult = cmmmc;
            Rational result = new Rational(numaratorResult, numitorResult);
            return result;
        }
        public static Rational operator -(Rational r1, Rational r2)
        {
            int produs = r1.numitor * r2.numitor;
            int numitor1 = r1.numitor;
            int numitor2 = r2.numitor;
            while (numitor2 != 0)
            {
                int rest = numitor1 % numitor2;
                numitor1 = numitor2;
                numitor2 = rest;
            }
            int cmmmc = produs / numitor1;
            int amplificatorR1 = cmmmc / r1.numitor;
            int amplificatorR2 = cmmmc / r2.numitor;
            int numaratorResult = amplificatorR1 * r1.numarator - amplificatorR2 * r2.numarator;
            int numitorResult = cmmmc;
            Rational result = new Rational(numaratorResult, numitorResult);
            return result;
        }
        public static Rational operator *(Rational r1, Rational r2)
        {
            int numaratorResult = r1.numarator * r2.numarator;
            int numitorResult = r1.numitor * r2.numitor;
            Rational result = new Rational(numaratorResult, numitorResult);
            return result;
        }

    }

}
/*
public static int cmmmc(int firstNumitor, int secondNumitor)
{
    int produs = firstNumitor * secondNumitor;
    while (secondNumitor != 0)
    {
        int rest = firstNumitor / secondNumitor;
        firstNumitor = secondNumitor;
        secondNumitor = rest;
    }
    int cmmmc = produs / firstNumitor;
    return cmmmc;*/