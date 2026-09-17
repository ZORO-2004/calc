using System;

namespace Calculator.Core;

public static class ScientificFunctions
{
    public const double Pi = Math.PI;
    public const double E = Math.E;

    public static double Square(double x) => x * x;
    public static double Cube(double x) => x * x * x;
    public static double Pow(double x, double y) => Math.Pow(x, y);

    public static double Sqrt(double x) => x < 0 ? double.NaN : Math.Sqrt(x);
    public static double Cbrt(double x) => Math.Cbrt(x);

    public static double Reciprocal(double x) => x == 0 ? double.NaN : 1.0 / x;
}