using System;
using System.Globalization;

namespace Calculator.Core;

public sealed class CalculatorController
{
    public const int MaxInputLength = 16;

    private readonly CalculatorEngine _engine = new();
    private AngleMode _angleMode = AngleMode.Degrees;
    private double? _memory;

    private string _display = "0";
    private double _accumulator;
    private string _pendingOp = "";
    private bool _isNewEntry = true;
    private bool _isError;
    private string _lastOp = "";
    private double _lastOperand;
    private bool _lastWasEquals;

    public string DisplayText => _display;
    public AngleMode AngleMode => _angleMode;

    public void Digit(string digit)
    {
        if (_isError) Reset();
        if (_isNewEntry)
        {
            _display = digit == "0" ? "0" : digit;
            _isNewEntry = false;
        }
        else if (_display.Length < MaxInputLength)
        {
            _display = _display == "0" ? digit : _display + digit;
        }
        _lastWasEquals = false;
    }

    public void Decimal()
    {
        if (_isError) Reset();
        if (_isNewEntry)
        {
            _display = "0.";
            _isNewEntry = false;
        }
        else if (!_display.Contains('.') && _display.Length < MaxInputLength)
        {
            _display += ".";
        }
        _lastWasEquals = false;
    }

    public void Backspace()
    {
        if (_isError) { Reset(); return; }
        if (_isNewEntry) return;
        _display = _display.Length > 1 ? _display[..^1] : "0";
        if (_display is "-" or "." or "")
        {
            _display = "0";
            _isNewEntry = true;
        }
        else if (_display == "0")
        {
            _isNewEntry = true;
        }
    }

    public void Sign()
    {
        if (_isError || _isNewEntry) return;
        _display = _display.StartsWith('-') ? _display[1..] : "-" + _display;
    }

    public void Binary(string op)
    {
        if (_isError) return;
        if (TryParseDisplay(out double value))
        {
            if (!string.IsNullOrEmpty(_pendingOp) && !_isNewEntry)
            {
                double intermediate = Compute(_accumulator, _pendingOp, value);
                if (IsInvalid(intermediate)) { SetError(); return; }
                _display = NumberFormatter.Format(intermediate);
                value = intermediate;
            }
            _accumulator = value;
            _pendingOp = op;
            _isNewEntry = true;
            _lastWasEquals = false;
        }
    }

    public void Equals()
    {
        if (_isError) return;

        if (_lastWasEquals)
        {
            if (string.IsNullOrEmpty(_lastOp)) return;
            double repeatResult = Compute(_accumulator, _lastOp, _lastOperand);
            if (IsInvalid(repeatResult)) { SetError(); return; }
            _accumulator = repeatResult;
            _display = NumberFormatter.Format(repeatResult);
            _isNewEntry = true;
            return;
        }

        if (string.IsNullOrEmpty(_pendingOp)) return;

        double operand = _isNewEntry ? _accumulator : ParseDisplay();
        double result = Compute(_accumulator, _pendingOp, operand);
        if (IsInvalid(result)) { SetError(); return; }

        _lastOp = _pendingOp;
        _lastOperand = operand;
        _pendingOp = "";
        _accumulator = result;
        _display = NumberFormatter.Format(result);
        _isNewEntry = true;
        _lastWasEquals = true;
    }

    private double ParseDisplay() =>
        double.Parse(_display, NumberStyles.Float, CultureInfo.InvariantCulture);

    private bool TryParseDisplay(out double value) =>
        double.TryParse(_display, NumberStyles.Float, CultureInfo.InvariantCulture, out value);

    private static bool IsInvalid(double v) => double.IsNaN(v) || double.IsInfinity(v);

    private double Compute(double a, string op, double b)
    {
        if (op == "/" && b == 0) return double.NaN;
        return op switch
        {
            "+" => _engine.Add(a, b),
            "-" => _engine.Subtract(a, b),
            "*" => _engine.Multiply(a, b),
            "/" => _engine.Divide(a, b),
            "^" => ScientificFunctions.Pow(a, b),
            _ => b
        };
    }

    private void SetError()
    {
        _display = "Error";
        _isError = true;
        _isNewEntry = true;
        _lastOp = "";
        _lastWasEquals = false;
    }

    private void Reset()
    {
        _display = "0";
        _accumulator = 0;
        _pendingOp = "";
        _isNewEntry = true;
        _isError = false;
        _lastOp = "";
        _lastWasEquals = false;
    }

    public void Clear() => Reset();

    public void ClearEntry()
    {
        if (_isError) { Reset(); return; }
        _display = "0";
        _isNewEntry = true;
    }

    public void ToggleAngleMode()
    {
        _angleMode = _angleMode == AngleMode.Degrees ? AngleMode.Radians : AngleMode.Degrees;
    }

    private void ApplyUnary(Func<double, double> fn)
    {
        if (_isError) return;
        if (TryParseDisplay(out double value))
        {
            double result = fn(value);
            if (IsInvalid(result)) { SetError(); return; }
            _accumulator = result;
            _display = NumberFormatter.Format(result);
            _isNewEntry = true;
            _lastWasEquals = false;
        }
    }

    public void Sin() => ApplyUnary(x => ScientificFunctions.Sin(x, _angleMode));
    public void Cos() => ApplyUnary(x => ScientificFunctions.Cos(x, _angleMode));
    public void Tan() => ApplyUnary(x => ScientificFunctions.Tan(x, _angleMode));
    public void Asin() => ApplyUnary(x => ScientificFunctions.Asin(x, _angleMode));
    public void Acos() => ApplyUnary(x => ScientificFunctions.Acos(x, _angleMode));
    public void Atan() => ApplyUnary(x => ScientificFunctions.Atan(x, _angleMode));

    public void Sqrt() => ApplyUnary(ScientificFunctions.Sqrt);
    public void Cbrt() => ApplyUnary(ScientificFunctions.Cbrt);
    public void Square() => ApplyUnary(ScientificFunctions.Square);
    public void Cube() => ApplyUnary(ScientificFunctions.Cube);
    public void Reciprocal() => ApplyUnary(ScientificFunctions.Reciprocal);

    public void Ln() => ApplyUnary(ScientificFunctions.Ln);
    public void Log10() => ApplyUnary(ScientificFunctions.Log10);
    public void Exp() => ApplyUnary(ScientificFunctions.Exp);
    public void TenPow() => ApplyUnary(ScientificFunctions.TenPow);
    public void Factorial() => ApplyUnary(ScientificFunctions.Factorial);

    public void Pi() => PushConstant(Math.PI);
    public void E() => PushConstant(Math.E);

    private void PushConstant(double value)
    {
        _accumulator = value;
        _display = NumberFormatter.Format(value);
        _isNewEntry = true;
        _lastWasEquals = false;
    }

    public void MemoryStore()
    {
        if (TryParseDisplay(out double value))
        {
            _memory = value;
            _isNewEntry = true;
        }
    }

    public void MemoryRecall()
    {
        if (_memory is null) return;
        _accumulator = _memory.Value;
        _display = NumberFormatter.Format(_memory.Value);
        _isNewEntry = true;
        _lastWasEquals = false;
    }

    public void MemoryClear() => _memory = null;

    public void MemoryAdd()
    {
        if (TryParseDisplay(out double value))
            _memory = (_memory ?? 0) + value;
    }
}