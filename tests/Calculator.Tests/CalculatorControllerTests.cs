using Xunit;
using Calculator.Core;

namespace Calculator.Tests;

public class CalculatorControllerTests
{
    private static readonly CalculatorController C = new();
    private static void Clean() { C.Clear(); C.MemoryClear(); }

    [Fact]
    public void Digit_Initial_ShowsZero()
    { Clean(); Assert.Equal("0", C.DisplayText); }

    [Fact]
    public void Digit_Digit_ShowsDigit()
    { Clean(); C.Digit("5"); Assert.Equal("5", C.DisplayText); }

    [Fact]
    public void Digit_TwoDigits_Appends()
    { Clean(); C.Digit("5"); C.Digit("3"); Assert.Equal("53", C.DisplayText); }

    [Fact]
    public void Digit_AfterOperator_StartsNewNumber()
    { Clean(); C.Digit("2"); C.Binary("+"); C.Digit("3"); Assert.Equal("3", C.DisplayText); }

    [Fact]
    public void Add_TwoNumbers_ShowsSum()
    { Clean(); C.Digit("2"); C.Binary("+"); C.Digit("3"); C.Equals(); Assert.Equal("5", C.DisplayText); }

    [Fact]
    public void Subtract_ShowsDifference()
    { Clean(); C.Digit("1"); C.Digit("0"); C.Binary("-"); C.Digit("4"); C.Equals(); Assert.Equal("6", C.DisplayText); }

    [Fact]
    public void Multiply_ShowsProduct()
    { Clean(); C.Digit("6"); C.Binary("*"); C.Digit("7"); C.Equals(); Assert.Equal("42", C.DisplayText); }

    [Fact]
    public void Divide_ShowsQuotient()
    { Clean(); C.Digit("2"); C.Digit("0"); C.Binary("/"); C.Digit("4"); C.Equals(); Assert.Equal("5", C.DisplayText); }

    [Fact]
    public void Divide_ByZero_ShowsError_ThenRecovers()
    {
        Clean(); C.Digit("5"); C.Binary("/"); C.Digit("0"); C.Equals();
        Assert.Equal("Error", C.DisplayText);
        C.Digit("3");
        Assert.Equal("3", C.DisplayText);
    }

    [Fact]
    public void Power_ShowsResult()
    { Clean(); C.Digit("2"); C.Binary("^"); C.Digit("1"); C.Digit("0"); C.Equals(); Assert.Equal("1024", C.DisplayText); }

    [Fact]
    public void ChainedBinary_ComputesIntermediate()
    {
        Clean(); C.Digit("2"); C.Binary("+"); C.Digit("3"); C.Binary("*");
        Assert.Equal("5", C.DisplayText);
        C.Digit("4"); C.Equals();
        Assert.Equal("20", C.DisplayText);
    }

    [Fact]
    public void Equals_WithoutOperation_NoOp()
    { Clean(); C.Digit("5"); C.Equals(); Assert.Equal("5", C.DisplayText); }

    [Fact]
    public void RepeatedEquals_AppliesLastOperation()
    {
        Clean(); C.Digit("2"); C.Binary("+"); C.Digit("3"); C.Equals();
        Assert.Equal("5", C.DisplayText);
        C.Equals();
        Assert.Equal("8", C.DisplayText);
    }

    [Fact]
    public void Equals_AfterOperator_UsesAccumulator()
    { Clean(); C.Digit("2"); C.Binary("+"); C.Equals(); Assert.Equal("4", C.DisplayText); }

    [Fact]
    public void Unary_Sqrt_ShowsRoot()
    { Clean(); C.Digit("9"); C.Sqrt(); Assert.Equal("3", C.DisplayText); }

    [Fact]
    public void Unary_Sqrt_Negative_ShowsError()
    { Clean(); C.Digit("9"); C.Sign(); C.Sqrt(); Assert.Equal("Error", C.DisplayText); }

    [Fact]
    public void Unary_ThenOperation_UsesResult()
    { Clean(); C.Digit("9"); C.Sqrt(); C.Binary("+"); C.Digit("2"); C.Equals(); Assert.Equal("5", C.DisplayText); }

    [Fact]
    public void Pi_ShowsValue()
    { Clean(); C.Pi(); Assert.Equal("3.14159265359", C.DisplayText); }

    [Fact]
    public void Sin_Degrees_Thirty_ShowsHalf()
    { Clean(); C.Digit("3"); C.Digit("0"); C.Sin(); Assert.Equal("0.5", C.DisplayText); }

    [Fact]
    public void Sin_Radians_PiOverTwo_ShowsOne()
    { Clean(); C.Pi(); C.Binary("/"); C.Digit("2"); C.Equals(); C.ToggleAngleMode(); C.Sin(); Assert.Equal("1", C.DisplayText); C.ToggleAngleMode(); }

    [Fact]
    public void Log10_ShowsResult()
    { Clean(); C.Digit("1"); C.Digit("0"); C.Digit("0"); C.Digit("0"); C.Log10(); Assert.Equal("3", C.DisplayText); }

    [Fact]
    public void Factorial_ShowsResult()
    { Clean(); C.Digit("5"); C.Factorial(); Assert.Equal("120", C.DisplayText); }

    [Fact]
    public void Clear_ResetsAll()
    {
        Clean(); C.Digit("2"); C.Binary("+"); C.Digit("3"); C.Clear();
        Assert.Equal("0", C.DisplayText);
    }

    [Fact]
    public void ClearEntry_ClearsCurrentEntry()
    {
        Clean(); C.Digit("5"); C.Digit("3"); C.ClearEntry();
        Assert.Equal("0", C.DisplayText);
    }

    [Fact]
    public void Backspace_RemovesLastChar()
    { Clean(); C.Digit("5"); C.Digit("3"); C.Backspace(); Assert.Equal("5", C.DisplayText); }

    [Fact]
    public void Decimal_AddsDecimalPoint()
    { Clean(); C.Digit("5"); C.Decimal(); Assert.Equal("5.", C.DisplayText); }

    [Fact]
    public void Sign_TogglesNegative()
    { Clean(); C.Digit("5"); C.Sign(); Assert.Equal("-5", C.DisplayText); }

    [Fact]
    public void Memory_StoreRecall_RetainsValue()
    { Clean(); C.Digit("5"); C.MemoryStore(); C.Clear(); C.MemoryRecall(); Assert.Equal("5", C.DisplayText); }

    [Fact]
    public void Memory_Add_AddsToStore()
    { Clean(); C.Digit("5"); C.MemoryStore(); C.Digit("3"); C.MemoryAdd(); C.Clear(); C.MemoryRecall(); Assert.Equal("8", C.DisplayText); }

    [Fact]
    public void Memory_Clear_KeepsDisplay()
    { Clean(); C.Digit("5"); C.MemoryStore(); C.MemoryClear(); Assert.Equal("5", C.DisplayText); }

    [Fact]
    public void Memory_RecallEmpty_NoOp()
    { Clean(); C.MemoryRecall(); Assert.Equal("0", C.DisplayText); }
}
