using Xunit;
using Calculator.Core;

namespace Calculator.Tests;

public class NumberFormatterTests
{
    [Fact]
    public void Format_Integer_ReturnsInteger() => Assert.Equal("5", NumberFormatter.Format(5));

    [Fact]
    public void Format_Fraction_NoFloatingNoise()
        => Assert.Equal("0.3", NumberFormatter.Format(0.1 + 0.2));

    [Fact]
    public void Format_Pi_Returns12SignificantDigits()
        => Assert.Equal("3.14159265359", NumberFormatter.Format(Math.PI));

    [Fact]
    public void Format_NaN_ReturnsError() => Assert.Equal("Error", NumberFormatter.Format(double.NaN));

    [Fact]
    public void Format_PositiveInfinity_ReturnsError()
        => Assert.Equal("Error", NumberFormatter.Format(double.PositiveInfinity));

    [Fact]
    public void Format_NegativeInfinity_ReturnsError()
        => Assert.Equal("Error", NumberFormatter.Format(double.NegativeInfinity));

    [Fact]
    public void Format_Negative_KeepsSign() => Assert.Equal("-5", NumberFormatter.Format(-5));
}