using System;
using System.Windows.Forms;
using Calculator.Core;

namespace Calculator.UI;

public partial class MainForm : Form
{
    private readonly CalculatorController _controller = new();

    public MainForm()
    {
        InitializeComponent();
        UpdateAngleButton();
        RefreshDisplay();
    }

    private void RefreshDisplay() => txtDisplay.Text = _controller.DisplayText;

    private void UpdateAngleButton() =>
        btnAngle!.Text = _controller.AngleMode == AngleMode.Degrees ? "DEG" : "RAD";

    private void btn_Click(object sender, EventArgs e)
    {
        if (sender is Button btn) _controller.Digit(btn.Text);
        RefreshDisplay();
    }

    private void btnOperator_Click(object sender, EventArgs e)
    {
        if (sender is Button btn) _controller.Binary(btn.Text);
        RefreshDisplay();
    }

    private void btnEquals_Click(object sender, EventArgs e)
    {
        _controller.Equals();
        RefreshDisplay();
    }

    private void btnDecimal_Click(object sender, EventArgs e)
    {
        _controller.Decimal();
        RefreshDisplay();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        _controller.Clear();
        RefreshDisplay();
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        _controller.Backspace();
        RefreshDisplay();
    }

    private void miNew_Click(object sender, EventArgs e)
    {
        _controller.Clear();
        RefreshDisplay();
    }

    private void miExit_Click(object sender, EventArgs e) => Close();

    private void miScientific_Click(object sender, EventArgs e)
    {
        pnlScientific.Visible = miScientific.Checked;
    }

    private void miAbout_Click(object sender, EventArgs e) =>
        MessageBox.Show("Scientific Calculator v2 — .NET 8 + WinForms", "About",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData >= Keys.D0 && keyData <= Keys.D9)
        { _controller.Digit(((int)(keyData - Keys.D0)).ToString()); RefreshDisplay(); return true; }
        if (keyData >= Keys.NumPad0 && keyData <= Keys.NumPad9)
        { _controller.Digit(((int)(keyData - Keys.NumPad0)).ToString()); RefreshDisplay(); return true; }
        switch (keyData)
        {
            case Keys.OemPeriod:
            case Keys.Oemcomma:
            case Keys.Decimal:
                _controller.Decimal(); RefreshDisplay(); return true;
            case Keys.Oemplus | Keys.Shift:
                _controller.Binary("+"); RefreshDisplay(); return true;
            case Keys.Oemplus:
                _controller.Equals(); RefreshDisplay(); return true;
            case Keys.OemMinus:
                _controller.Binary("-"); RefreshDisplay(); return true;
            case Keys.Multiply:
            case Keys.X:
            case Keys.X | Keys.Shift:
                _controller.Binary("*"); RefreshDisplay(); return true;
            case Keys.Divide:
            case Keys.OemQuestion:
            case Keys.OemBackslash:
                _controller.Binary("/"); RefreshDisplay(); return true;
            case Keys.Enter:
                _controller.Equals(); RefreshDisplay(); return true;
            case Keys.Escape:
                _controller.Clear(); RefreshDisplay(); return true;
            case Keys.Back:
                _controller.Backspace(); RefreshDisplay(); return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void SciButton_Click(object sender, EventArgs e)
    {
        if (sender is not Button b) return;
        switch ((string)b.Tag!)
        {
            case "sin": _controller.Sin(); break;
            case "cos": _controller.Cos(); break;
            case "tan": _controller.Tan(); break;
            case "asin": _controller.Asin(); break;
            case "acos": _controller.Acos(); break;
            case "atan": _controller.Atan(); break;
            case "sqrt": _controller.Sqrt(); break;
            case "cbrt": _controller.Cbrt(); break;
            case "square": _controller.Square(); break;
            case "cube": _controller.Cube(); break;
            case "recip": _controller.Reciprocal(); break;
            case "ln": _controller.Ln(); break;
            case "log10": _controller.Log10(); break;
            case "exp": _controller.Exp(); break;
            case "tenpow": _controller.TenPow(); break;
            case "factorial": _controller.Factorial(); break;
            case "power": _controller.Binary("^"); break;
            case "pi": _controller.Pi(); break;
            case "e": _controller.E(); break;
            case "sign": _controller.Sign(); break;
            case "degrees": _controller.ToggleAngleMode(); break;
            case "ms": _controller.MemoryStore(); break;
            case "mr": _controller.MemoryRecall(); break;
            case "mc": _controller.MemoryClear(); break;
            case "madd": _controller.MemoryAdd(); break;
            case "ce": _controller.ClearEntry(); break;
            case "c": _controller.Clear(); break;
        }
        RefreshDisplay();
        UpdateAngleButton();
    }
}
