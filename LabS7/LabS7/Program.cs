using System;

namespace LabS7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti numarul complex:");
            string firstNumber = Console.ReadLine();
            string[] fword = firstNumber.Split('+');
            string remove = fword[1];
            string img1 = remove.Remove(remove.Length - 1, 1);
            int real = Convert.ToInt32(fword[0]);
            int imaginar = Convert.ToInt32(img1);
            Complex c = new Complex(real, imaginar);
            int k = int.Parse(Console.ReadLine());
            ComplexD power = new ComplexD(real, imaginar);
            Console.WriteLine(power.ridicare_la_putere(k));
        }
    }
    class Complex
    {
        public int Re { get; set; }
        public int Im { get; set; }
        public Complex(int Re, int Im)
        {
            this.Re = Re;
            this.Im = Im;
        }
        public static Complex operator *(Complex c1, Complex c2)
        {
            int realResult = (c1.Re * c2.Re - c1.Im * c2.Im) + (c1.Re * c2.Im + c1.Re * c2.Re);
            int imaginarResult = c1.Im - c2.Im;
            Complex result = new Complex(realResult, imaginarResult);
            return result;
        }
        public virtual string ridicare_la_putere(int k)
        {
            Complex c = new Complex(this.Re, this.Im);
            for (int i = 1; i < k; i++)
                c = c * this;
            return c.ToString();
        }
    }

    class ComplexD : Complex
    {
        public ComplexD(int Re, int Im) : base(Re, Im)
        { }
            public override string ridicare_la_putere(int k)
            {
            double r = Math.Sqrt(Math.Pow(this.Re, 2) + Math.Pow(this.Im, 2));
            double fi = Math.Atan(this.Im / this.Re);

            return String.Format("{0:0.00}", Math.Pow(r, k)) + " ( cos " +
            String.Format("{0:0.00}", k * fi) + " + i * sin " +
            String.Format("{0:0.00}", k * fi) + " )";
            } 
    }
        
}


