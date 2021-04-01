using System;

namespace S5LabComplex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti un numar complex sub forma a+bi");
            Console.WriteLine("Pentru a aduna doua numere complexe apasati tasta '1'");
            Console.WriteLine("Pentru a scadea doua numere complexe apasati tasta '2'");
            Console.WriteLine("Pentru a inmulti doua numere complexe apasati tasta '3'");
            Console.WriteLine("Pentru a ridica la o anumita putere un numar complex apasati tasta '4'");
            Console.WriteLine("Pentru a aduce un numar complex la forma trigonometrica apasati tasta '5'");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti primul numar complex:");
            string firstNumber = Console.ReadLine();
            string[] fword = firstNumber.Split('+');
            string remove = fword[1];
            string img1 = remove.Remove(remove.Length - 1, 1);
            int firstReal = Convert.ToInt32(fword[0]);
            int firstImaginar = Convert.ToInt32(img1);
            Complex c1 = new Complex(firstReal, firstImaginar);
            if (input == 1 || input == 2 || input == 3)
            {
                Console.WriteLine("Introduceti al doilea numar complex:");
                string secondNumber = Console.ReadLine();
                string[] sword = secondNumber.Split('+');

                string remove2 = sword[1];
                string img2 = remove2.Remove(remove2.Length - 1, 1);
                int secondReal = Convert.ToInt32(sword[0]);
                int secondImaginar = Convert.ToInt32(img2);
                Complex c2 = new Complex(secondReal, secondImaginar);
                Complex c3 = c1 + c2;
                Complex c4 = c1 - c2;
                Complex c5 = c1 * c2;
                View(c1, c3, c4, c5, input, 0);
            }
            if (input == 4 || input == 5)
            {
                int n = 0;
                if (input == 4)
                {
                    Console.WriteLine("De cate ori doriti sa multiplicati numarul complex introdus?");
                    Console.WriteLine("n=");
                    n = int.Parse(Console.ReadLine());
                }
                Complex c2 = new Complex(0, 0);
                Complex c3 = c1 + c2;
                Complex c4 = c1 - c2;
                Complex c5 = c1 * c2;
                View(c1, c3, c4, c5, input, n);
            }
        }
        public static void View(Complex c1, Complex c3, Complex c4, Complex c5, int input, int n)
        {
            switch (input)
            {
                case 1:
                    Console.WriteLine($" Suma = {c3.realPart} + {c3.imaginarPart}i");
                    break;
                case 2:
                    if (c4.imaginarPart >= 0) Console.WriteLine($" Diferenta = {c4.realPart} + {c4.imaginarPart}i");
                    else Console.WriteLine($" Diferenta = {c4.realPart}{c4.imaginarPart}i");
                    break;
                case 3:
                    if (c5.imaginarPart >= 0) Console.WriteLine($" Produsul = {c5.realPart} + {c5.imaginarPart}i");
                    else Console.WriteLine($" Produsul = {c5.realPart}{c5.imaginarPart}i");
                    break;
                case 4:
                    Console.WriteLine("Ridicarea la putere in forma trigonometrica a numarului complex introdus este " + Power(c1, n));

                    break;
                case 5:
                    Console.WriteLine("Forma trigonometrica = " + formaTrigonometrica(c1));
                    break;

                default:
                    break;
            }

        }
        public static string formaTrigonometrica(Complex c1)
        {
            float r = (float)Math.Sqrt(Math.Pow(c1.realPart, 2) + Math.Pow(c1.imaginarPart, 2));
            float teta = (float)Math.Atan(c1.imaginarPart / c1.imaginarPart);
            string result = $"{r}(cos{teta} + isin{teta})";
            return result;
        }
        public static string Power(Complex c1, int n)
        {

            float r = (float)Math.Sqrt(Math.Pow(c1.realPart, 2) + Math.Pow(c1.imaginarPart, 2));
            float teta = (float)Math.Atan(c1.imaginarPart / c1.imaginarPart);
            string result = $"{Math.Pow(r, n)}(cos{n * teta} + isin{n * teta})";
            return result;
        }
    }
    class Complex
    {
        public int realPart { get; set; }
        public int imaginarPart { get; set; }
        public Complex(int re, int img)
        {
            realPart = re;
            imaginarPart = img;
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            int realResult = c1.realPart + c2.realPart;
            int imaginarResult = c1.imaginarPart + c2.imaginarPart;
            Complex result = new Complex(realResult, imaginarResult);
            return result;
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            int realResult = c1.realPart - c2.realPart;
            int imaginarResult = c1.imaginarPart - c2.imaginarPart;
            Complex result = new Complex(realResult, imaginarResult);
            return result;
        }
        public static Complex operator *(Complex c1, Complex c2)
        {
            int realResult = (c1.realPart * c2.realPart - c1.imaginarPart * c2.imaginarPart) + (c1.realPart * c2.imaginarPart + c1.imaginarPart * c2.realPart);
            int imaginarResult = c1.imaginarPart - c2.imaginarPart;
            Complex result = new Complex(realResult, imaginarResult);
            return result;
        }

    }

}
