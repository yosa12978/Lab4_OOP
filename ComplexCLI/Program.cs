using System.Diagnostics.CodeAnalysis;

namespace ComplexCLI
{
    public struct Complex
    {
        public double Re;
        public double Im;
        public Complex(double Re, double Im)
        {
            this.Re = Re;
            this.Im = Im;
        }

        public double Abs
        {
            get
            {
                return Math.Sqrt(Re * Re + Im * Im);
            }
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Re - b.Re, a.Im - b.Im);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.Re * b.Re - a.Im * b.Im, a.Re * b.Im + a.Im * b.Re);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            if (b.Re == 0 && b.Im == 0)
            {
                throw new DivideByZeroException("Нельзя делить на ноль");
            }
            double re = (a.Re * b.Re + a.Im * b.Im) / (b.Re * b.Re + b.Im * b.Im);
            double im = (a.Im * b.Re - a.Re * b.Im) / (b.Re * b.Re + b.Im * b.Im);
            return new Complex(re, im);
        }

        public static bool operator ==(Complex a, Complex b)
        {
            return a.Re == b.Re && a.Im == b.Im;
        }
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return this == (Complex?)obj;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Re, Im);
        }

        public static bool operator !=(Complex a, Complex b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return $"{Re} + {Im}i";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Complex a = new(1, 1);
            Complex b = new(1, 1);
            Console.WriteLine(a.Equals(b));
        }
    }
}