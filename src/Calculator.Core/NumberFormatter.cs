using System;
using System.Globalization;

namespace Calculator.Core;

public static class NumberFormatter
{
    public static string Format(double value)
    {
        if (double.IsNaN(value) || double.IsInfinity(value))
            return "Error";
        return value.ToString("G12", CultureInfo.InvariantCulture);
    }
}