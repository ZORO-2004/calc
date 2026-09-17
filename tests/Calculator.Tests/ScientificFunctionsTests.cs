using Xunit;
using Calculator.Core;

namespace Calculator.Tests;

public class ScientificFunctionsTests
{
    [Fact]
    public void Square_Positive_ReturnsSquared() => Assert.Equal(81, ScientificFunctions.Square(9));

    [Fact]
    public void Square_Negative_ReturnsPositive() => Assert.Equal(81, ScientificFunctions.Square(-9));

    [Fact]
    public void Cube_ReturnsCubed() => Assert.Equal(27, ScientificFunctions.Cube(3));

    [Fact]
    public void Pow_TwoAndTen_Returns1024() => Assert.Equal(1024, ScientificFunctions.Pow(2, 10));

    [Fact]
    public void Sqrt_Positive_ReturnsRoot() => Assert.Equal(4, ScientificFunctions.Sqrt(16));

    [Fact]
    public void Sqrt_Negative_ReturnsNaN() => Assert.True(double.IsNaN(ScientificFunctions.Sqrt(-4)));

    [Fact]
    public void Cbrt_ReturnsCubeRoot() => Assert.Equal(2, ScientificFunctions.Cbrt(8));

    [Fact]
    public void Reciprocal_ReturnsInverse() => Assert.Equal(0.25, ScientificFunctions.Reciprocal(4));

    [Fact]
    public void Reciprocal_Zero_ReturnsNaN() => Assert.True(double.IsNaN(ScientificFunctions.Reciprocal(0)));

    [Fact]
    public void Pi_Constant_IsMathPi() => Assert.Equal(Math.PI, ScientificFunctions.Pi);

    [Theory]
    [InlineData(30, 0.5)]
    [InlineData(90, 1)]
    public void Sin_Degrees_ReturnsExpected(double angle, double expected)
        => Assert.Equal(expected, ScientificFunctions.Sin(angle, AngleMode.Degrees), 10);

    [Fact]
    public void Cos_Degrees_60_ReturnsHalf()
        => Assert.Equal(0.5, ScientificFunctions.Cos(60, AngleMode.Degrees), 10);

    [Fact]
    public void Tan_Degrees_45_ReturnsOne()
        => Assert.Equal(1, ScientificFunctions.Tan(45, AngleMode.Degrees), 10);

    [Fact]
    public void Sin_Radians_PiOver2_ReturnsOne()
        => Assert.Equal(1, ScientificFunctions.Sin(ScientificFunctions.Pi / 2, AngleMode.Radians), 10);

    [Fact]
    public void Asin_Degrees_ReturnsDegrees()
        => Assert.Equal(30, ScientificFunctions.Asin(0.5, AngleMode.Degrees), 10);

    [Fact]
    public void Acos_Degrees_ReturnsDegrees()
        => Assert.Equal(60, ScientificFunctions.Acos(0.5, AngleMode.Degrees), 10);

    [Fact]
    public void Atan_Degrees_ReturnsDegrees()
        => Assert.Equal(45, ScientificFunctions.Atan(1, AngleMode.Degrees), 10);

    [Fact]
    public void Asin_OutOfRange_ReturnsNaN()
        => Assert.True(double.IsNaN(ScientificFunctions.Asin(2, AngleMode.Degrees)));

    [Fact]
    public void Ln_E_ReturnsOne() => Assert.Equal(1, ScientificFunctions.Ln(ScientificFunctions.E), 10);

    [Fact]
    public void Ln_Zero_ReturnsNaN() => Assert.True(double.IsNaN(ScientificFunctions.Ln(0)));

    [Fact]
    public void Ln_Negative_ReturnsNaN() => Assert.True(double.IsNaN(ScientificFunctions.Ln(-5)));

    [Fact]
    public void Log10_Thousand_ReturnsThree() => Assert.Equal(3, ScientificFunctions.Log10(1000), 10);

    [Fact]
    public void Exp_One_ReturnsE() => Assert.Equal(ScientificFunctions.E, ScientificFunctions.Exp(1), 10);

    [Fact]
    public void TenPow_Two_Returns100() => Assert.Equal(100, ScientificFunctions.TenPow(2), 10);

    [Fact]
    public void Factorial_Five_Returns120() => Assert.Equal(120, ScientificFunctions.Factorial(5));

    [Fact]
    public void Factorial_Zero_ReturnsOne() => Assert.Equal(1, ScientificFunctions.Factorial(0));

    [Fact]
    public void Factorial_Negative_ReturnsNaN() => Assert.True(double.IsNaN(ScientificFunctions.Factorial(-1)));

    [Fact]
    public void Factorial_171_ReturnsNaN() => Assert.True(double.IsNaN(ScientificFunctions.Factorial(171)));

    [Fact]
    public void Factorial_NonInteger_ReturnsNaN() => Assert.True(double.IsNaN(ScientificFunctions.Factorial(5.5)));
}