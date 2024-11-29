using System.Numerics;

namespace Lab {
    interface INumber<T> where T : INumber<T> {
        T Add(T b);
        T Subtract(T b);
        T Multiply(T b);
        T Divide(T b);
    }

    public class MyFrac : INumber<MyFrac> {
        private BigInteger nom { get; }
        private BigInteger denom { get; }

        public MyFrac(BigInteger numerator, BigInteger denominator) {
            if (denominator == 0)
                throw new DivideByZeroException("bad frac");

            if (denominator < 0) {
                numerator = -numerator;
                denominator = -denominator;
            }

            BigInteger gcd = BigInteger.GreatestCommonDivisor(BigInteger.Abs(numerator), denominator);
            nom = numerator / gcd;
            denom = denominator / gcd;
        }

        public MyFrac(MyFrac that) : this(that.nom, that.denom) {}

        public MyFrac Add(MyFrac that) {
            BigInteger f1 = nom * that.denom + that.nom * denom;
            BigInteger f2 = denom * that.denom;
            return new MyFrac(f1, f2);
        }

        public MyFrac Subtract(MyFrac that) {
            BigInteger f1 = nom * that.denom - that.nom * denom;
            BigInteger f2 = denom * that.denom;
            return new MyFrac(f1, f2);
        }

        public MyFrac Multiply(MyFrac that) {
            return new MyFrac(nom * that.nom, denom * that.denom);
        }

        public MyFrac Divide(MyFrac that) {
            if (that.nom == 0)
                throw new DivideByZeroException("frac");

            return new MyFrac(nom * that.denom, denom * that.nom);
        }

        public override string ToString() => $"{nom}/{denom}";
    }

    public class MyComplex : INumber<MyComplex> {
        public double re { get; }
        public double im { get; }

        public MyComplex(double real, double imaginary) {
            re = real;
            im = imaginary;
        }

        public MyComplex(MyComplex that) : this(that.re, that.im) {}

        public MyComplex Add(MyComplex that) {
            return new MyComplex(re + that.re, im + that.im);
        }

        public MyComplex Subtract(MyComplex that) {
            return new MyComplex(re - that.re, im - that.im);
        }

        // (ac - bd) + (ad + bc)i
        public MyComplex Multiply(MyComplex that) {
            double c1 = re * that.re - im * that.im;
            double c2 = re * that.im + im * that.re;
            return new MyComplex(c1, c2);
        }

        // ((ac + bd)/(c² + d²)) + ((bc - ad)/(c² + d²)) i
        public MyComplex Divide(MyComplex that) {
            double denominator = that.re * that.re + that.im * that.im;
            if (denominator == 0)
                throw new DivideByZeroException("complex");

            double c1 = (re * that.re + im * that.im) / denominator;
            double c2 = (im * that.re - re * that.im) / denominator;
            return new MyComplex(c1, c2);
        }

        public override string ToString() => $"{re} {(im>=0?"+":"-")} {(im>=0?im:Math.Abs(im))}i";
    }
}