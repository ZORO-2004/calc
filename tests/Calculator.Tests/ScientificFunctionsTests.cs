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
}