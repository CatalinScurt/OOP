using System;

namespace LabS12
{
    class Program
    {
        static void Main(string[] args)
        {
            Cerc c = new Cerc(3);
            Patrat p = new Patrat(3);
            Console.WriteLine("Afiseaza informatii despre {0}:", c.Denumire);
            Console.WriteLine("aria={0:#.##} \t lungimea frontierei={1:#.##}", c.Aria(), c.LungFrontiera());
            Console.WriteLine("\nAfiseaza informatii despre {0}:", p.Denumire);
            Console.WriteLine("aria={0:#.##} \t lungimea frontierei={1:#.##}", p.Aria(), p.LungFrontiera());
        }
    }
    public interface IForma2D
    {
        double Aria();
        double LungFrontiera();
        string Denumire { get; }
    }
    public class Cerc : IForma2D
    {
        public Cerc(double r)
        {
            raza = r;
        }
        public double Aria()
        {
            return (PI * raza * raza);
        }
        public double LungFrontiera()
        {
            return (2 * PI * raza);
        }
        public string Denumire
        {
            get
            {
                return s;
            }
        }
        public double raza;
        private const float PI = 3.14159f;
        string s = "cerc";
    }
    public class Patrat : IForma2D
    {
        public Patrat(int l)
        {
            latura = l;
        }
        public double Aria()
        {
            return (latura * latura);
        }
        public double LungFrontiera()
        {
            return 4 * latura;
        }
        public string Denumire
        {
            get
            {
                return s;
            }
        }

        public double latura;
        string s = "patrat";
    }
    class IterfDemo
    {
        static void DisplayInfo(IForma2D f)
        {
            Console.WriteLine("aria={0:#.##} \t lungimea frontierei ={1:#.##}", f.Aria(),
           f.LungFrontiera());
        }

    } }
