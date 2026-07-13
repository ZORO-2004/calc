using Xunit;
using Calculator.Core;

namespace Calculator.Tests;

public class CalculatorEngineTests
{
    [Fact]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        var engine = new CalculatorEngine();
        var result = engine.Add(2, 3);
        Assert.Equal(5, result);
    }
}
