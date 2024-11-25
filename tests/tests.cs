using Lab;
using System.Numerics;
using Xunit;

namespace Lab_tests {
    public class FracTests {
        [Fact]
        public void TestGCD()
        {
            var frac = new MyFrac(2, 4);
            Assert.Equal("1/2", frac.ToString());
        }

        [Fact]
        public void TestConstructorNegativeDenom()
        {
            var frac = new MyFrac(1, -2);
            Assert.Equal("-1/2", frac.ToString());
        }

        [Fact]
        public void TestBadFrac()
        {
            Assert.Throws<DivideByZeroException>(() => new MyFrac(1, 0));
        }

        [Fact]
        public void TestAPlusB()
        {
            MyFrac f1 = new MyFrac(1,-2);
            MyFrac f2 = new MyFrac(1, 3);
            MyFrac result = f1.Add(f2);
            Assert.Equal("-1/6", result.ToString());
        }

        [Fact]
        public void TestASubtractB()
        {
            MyFrac f1 = new MyFrac(1, 2);
            MyFrac f2 = new MyFrac(-1, 3);
            MyFrac result = f1.Subtract(f2);
            Assert.Equal("5/6", result.ToString());
        }

        [Fact]
        public void TestAMultiplyB()
        {
            MyFrac f1 = new MyFrac(1, 2);
            MyFrac f2 = new MyFrac(2, 3);
            MyFrac result = f1.Multiply(f2);
            Assert.Equal("1/3", result.ToString());
        }

        [Fact]
        public void TestADivideB()
        {
            MyFrac f1 = new MyFrac(1, 2);
            MyFrac f2 = new MyFrac(2, 3);
            MyFrac result = f1.Divide(f2);
            Assert.Equal("3/4", result.ToString());
        }

        [Fact]
        public void TestDivByZero()
        {
            MyFrac f1 = new MyFrac(1, 2);
            MyFrac f2 = new MyFrac(0, 1);
            Assert.Throws<DivideByZeroException>(() => f1.Divide(f2));
        }
    }

    public class ComplexTests {
        private const double eps = 1e-10;

        [Fact]
        public void TestAPlusB()
        {
            MyComplex c1 = new MyComplex(1, 2);
            MyComplex c2 = new MyComplex(3, 4);
            MyComplex result = c1.Add(c2);
            Assert.Equal(4, result.re, eps);
            Assert.Equal(6, result.im, eps);
        }

        [Fact]
        public void TestAMinusB()
        {
            MyComplex c1 = new MyComplex(1, 2);
            MyComplex c2 = new MyComplex(3, 4);
            MyComplex result = c1.Subtract(c2);
            Assert.Equal(-2, result.re, eps);
            Assert.Equal(-2, result.im, eps);
        }

        [Fact]
        public void TestAMultiplyB()
        {
            MyComplex c1 = new MyComplex(1, 2);
            MyComplex c2 = new MyComplex(3, 4);
            MyComplex result = c1.Multiply(c2);
            // (1*3 - 2*4) + (1*4 + 2*3)i = -5 + 10i
            Assert.Equal(-5, result.re, eps);
            Assert.Equal(10, result.im, eps);
        }

        [Fact]
        public void TestADivideB()
        {
            MyComplex c1 = new MyComplex(1, 2);
            MyComplex c2 = new MyComplex(3, 4);
            MyComplex result = c1.Divide(c2);
            Assert.Equal(0.44, result.re, eps);
            Assert.Equal(0.08, result.im, eps);
        }

        [Fact]
        public void TestDivByZero()
        {
            MyComplex c1 = new MyComplex(1, 2);
            MyComplex c2 = new MyComplex(0, 0);
            Assert.Throws<DivideByZeroException>(() => c1.Divide(c2));
        }

        [Fact]
        public void TestToString()
        {
            MyComplex c1 = new MyComplex(1, 2);
            MyComplex c2 = new MyComplex(1, -2);
            Assert.Equal("1 + 2i", c1.ToString());
            Assert.Equal("1 - 2i", c2.ToString());
        }
    }
}