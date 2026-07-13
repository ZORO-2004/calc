using System;
using System.Windows.Forms;
using Calculator.Core;

namespace Calculator.UI;

public partial class MainForm : Form
{
    private readonly CalculatorEngine _engine = new CalculatorEngine();
    private double _firstNumber = 0;
    private string _operation = "";
    private bool _isNewEntry = true;

    public MainForm()
    {
        InitializeComponent();
    }

    private void btn_Click(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            string digit = btn.Text;
            if (_isNewEntry)
            {
                txtDisplay.Text = digit;
                _isNewEntry = false;
            }
            else
            {
                txtDisplay.Text += digit;
            }
        }
    }

    private void btnOperator_Click(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            _firstNumber = double.Parse(txtDisplay.Text);
            _operation = btn.Text;
            _isNewEntry = true;
        }
    }

    private void btnEquals_Click(object sender, EventArgs e)
    {
        try
        {
            double secondNumber = double.Parse(txtDisplay.Text);
            double result = 0;

            switch (_operation)
            {
                case "+":
                    result = _engine.Add(_firstNumber, secondNumber);
                    break;
                case "-":
                    result = _engine.Subtract(_firstNumber, secondNumber);
                    break;
                case "*":
                    result = _engine.Multiply(_firstNumber, secondNumber);
                    break;
                case "/":
                    result = _engine.Divide(_firstNumber, secondNumber);
                    break;
            }

            txtDisplay.Text = result.ToString();
            _isNewEntry = true;
        }
        catch (DivideByZeroException ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtDisplay.Text = "0";
            _isNewEntry = true;
        }
    }

    private void btnDecimal_Click(object sender, EventArgs e)
    {
        if (_isNewEntry)
        {
            txtDisplay.Text = "0.";
            _isNewEntry = false;
        }
        else if (!txtDisplay.Text.Contains("."))
        {
            txtDisplay.Text += ".";
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        txtDisplay.Text = "0";
        _firstNumber = 0;
        _operation = "";
        _isNewEntry = true;
    }
}
