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

    public static double ToRadians(double x, AngleMode mode) =>
        mode == AngleMode.Degrees ? x * Math.PI / 180.0 : x;

    public static double ToDegrees(double x, AngleMode mode) =>
        mode == AngleMode.Degrees ? x * 180.0 / Math.PI : x;

    public static double Sin(double x, AngleMode mode) => Math.Sin(ToRadians(x, mode));
    public static double Cos(double x, AngleMode mode) => Math.Cos(ToRadians(x, mode));
    public static double Tan(double x, AngleMode mode) => Math.Tan(ToRadians(x, mode));

    public static double Asin(double x, AngleMode mode) => ToDegrees(Math.Asin(x), mode);
    public static double Acos(double x, AngleMode mode) => ToDegrees(Math.Acos(x), mode);
    public static double Atan(double x, AngleMode mode) => ToDegrees(Math.Atan(x), mode);

    public static double Ln(double x) => x <= 0 ? double.NaN : Math.Log(x);
    public static double Log10(double x) => x <= 0 ? double.NaN : Math.Log10(x);
    public static double Exp(double x) => Math.Exp(x);
    public static double TenPow(double x) => Math.Pow(10, x);

    public static double Factorial(double n)
    {
        if (n < 0 || n > 170 || n != Math.Floor(n)) return double.NaN;
        double result = 1;
        for (int i = 2; i <= (int)n; i++) result *= i;
        return result;
    }
}