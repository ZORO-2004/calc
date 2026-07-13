# C# Calculator with GUI Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build a functional calculator application using C# with a Windows Forms GUI that supports basic arithmetic operations.

**Architecture:** A Windows Forms application with a clean separation between the calculation logic (testable core) and the GUI interface. The core logic will be in a separate class library for unit testing, and the GUI will be a separate WinForms project that consumes the core library.

**Tech Stack:** C# (.NET 8.0), Windows Forms, xUnit for testing, .NET CLI for build/run

## Global Constraints

- .NET 8.0 SDK required
- Use Windows Forms (not WPF) for the GUI
- Solution must be organized into separate projects: Core (class library), Tests (xUnit), UI (WinForms)
- All calculation logic must be unit tested using TDD
- No external UI libraries beyond Windows Forms
- Code must follow C# naming conventions
- Calculator must support: addition, subtraction, multiplication, division, clear, and decimal input

---

## File Structure

```
Calculator/
├── Calculator.sln
├── src/
│   ├── Calculator.Core/
│   │   ├── Calculator.Core.csproj
│   │   └── CalculatorEngine.cs
│   └── Calculator.UI/
│       ├── Calculator.UI.csproj
│       ├── Program.cs
│       ├── MainForm.cs
│       └── MainForm.Designer.cs
└── tests/
    └── Calculator.Tests/
        ├── Calculator.Tests.csproj
        └── CalculatorEngineTests.cs
```

---

### Task 1: Create Solution Structure and Projects

**Files:**
- Create: `Calculator.sln`
- Create: `src/Calculator.Core/Calculator.Core.csproj`
- Create: `src/Calculator.UI/Calculator.UI.csproj`
- Create: `tests/Calculator.Tests/Calculator.Tests.csproj`
- Create: `tests/Calculator.Tests/UnitTest1.cs` (placeholder, will be removed in Task 2)

**Interfaces:**
- Consumes: nothing
- Produces: empty solution with three projects properly configured

- [ ] **Step 1: Create the solution file**

```bash
dotnet new sln -n Calculator
```

- [ ] **Step 2: Create the Core class library project**

```bash
dotnet new classlib -n Calculator.Core -o src/Calculator.Core --framework net8.0
```

- [ ] **Step 3: Create the UI WinForms project**

```bash
dotnet new winforms -n Calculator.UI -o src/Calculator.UI --framework net8.0
```

- [ ] **Step 4: Create the test project**

```bash
dotnet new xunit -n Calculator.Tests -o tests/Calculator.Tests --framework net8.0
```

- [ ] **Step 5: Add all projects to the solution**

```bash
dotnet sln add src/Calculator.Core/Calculator.Core.csproj
dotnet sln add src/Calculator.UI/Calculator.UI.csproj
dotnet sln add tests/Calculator.Tests/Calculator.Tests.csproj
```

- [ ] **Step 6: Add project references**

```bash
dotnet add tests/Calculator.Tests/Calculator.Tests.csproj reference src/Calculator.Core/Calculator.Core.csproj
dotnet add src/Calculator.UI/Calculator.UI.csproj reference src/Calculator.Core/Calculator.Core.csproj
```

- [ ] **Step 7: Remove default files from Core and Test projects**

```bash
Remove-Item src/Calculator.Core/Class1.cs
Remove-Item tests/Calculator.Tests/UnitTest1.cs
```

- [ ] **Step 8: Build to verify everything compiles**

```bash
dotnet build
```

Expected: Build succeeds with 0 errors.

- [ ] **Step 9: Commit**

```bash
git add .
git commit -m "feat: create solution structure with Core, UI, and Tests projects"
```

---

### Task 2: Implement CalculatorEngine with TDD - Addition

**Files:**
- Create: `tests/Calculator.Tests/CalculatorEngineTests.cs`
- Modify: `src/Calculator.Core/CalculatorEngine.cs`

**Interfaces:**
- Consumes: nothing
- Produces: `CalculatorEngine` class with a working `Add` method

- [ ] **Step 1: Write the failing test for Add method**

Create file `tests/Calculator.Tests/CalculatorEngineTests.cs`:

```csharp
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
```

- [ ] **Step 2: Run test to verify it fails**

```bash
dotnet test tests/Calculator.Tests/Calculator.Tests.csproj
```

Expected: FAIL with "CalculatorEngine does not exist" or similar compile error.

- [ ] **Step 3: Create minimal CalculatorEngine implementation**

Replace contents of `src/Calculator.Core/CalculatorEngine.cs`:

```csharp
namespace Calculator.Core;

public class CalculatorEngine
{
    public double Add(double a, double b)
    {
        return a + b;
    }
}
```

- [ ] **Step 4: Run test to verify it passes**

```bash
dotnet test tests/Calculator.Tests/Calculator.Tests.csproj
```

Expected: PASS (1 test, 0 failures).

- [ ] **Step 5: Commit**

```bash
git add .
git commit -m "feat(core): implement Add method in CalculatorEngine"
```

---

### Task 3: Add Subtraction with TDD

**Files:**
- Modify: `tests/Calculator.Tests/CalculatorEngineTests.cs`
- Modify: `src/Calculator.Core/CalculatorEngine.cs`

**Interfaces:**
- Consumes: CalculatorEngine from Task 2
- Produces: Adds Subtract method to CalculatorEngine

- [ ] **Step 1: Write the failing test for Subtract method**

Add to `tests/Calculator.Tests/CalculatorEngineTests.cs`:

```csharp
    [Fact]
    public void Subtract_TwoPositiveNumbers_ReturnsDifference()
    {
        var engine = new CalculatorEngine();
        var result = engine.Subtract(10, 3);
        Assert.Equal(7, result);
    }
```

- [ ] **Step 2: Run test to verify it fails**

```bash
dotnet test tests/Calculator.Tests/Calculator.Tests.csproj
```

Expected: FAIL with "Subtract does not exist".

- [ ] **Step 3: Add minimal Subtract implementation**

Add to `src/Calculator.Core/CalculatorEngine.cs`:

```csharp
    public double Subtract(double a, double b)
    {
        return a - b;
    }
```

- [ ] **Step 4: Run test to verify it passes**

```bash
dotnet test tests/Calculator.Tests/Calculator.Tests.csproj
```

Expected: PASS (2 tests, 0 failures).

- [ ] **Step 5: Commit**

```bash
git add .
git commit -m "feat(core): implement Subtract method in CalculatorEngine"
```

---

### Task 4: Add Multiplication with TDD

**Files:**
- Modify: `tests/Calculator.Tests/CalculatorEngineTests.cs`
- Modify: `src/Calculator.Core/CalculatorEngine.cs`

**Interfaces:**
- Consumes: CalculatorEngine from Tasks 2-3
- Produces: Adds Multiply method to CalculatorEngine

- [ ] **Step 1: Write the failing test for Multiply method**

Add to `tests/Calculator.Tests/CalculatorEngineTests.cs`:

```csharp
    [Fact]
    public void Multiply_TwoPositiveNumbers_ReturnsProduct()
    {
        var engine = new CalculatorEngine();
        var result = engine.Multiply(4, 5);
        Assert.Equal(20, result);
    }
```

- [ ] **Step 2: Run test to verify it fails**

```bash
dotnet test tests/Calculator.Tests/Calculator.Tests.csproj
```

Expected: FAIL with "Multiply does not exist".

- [ ] **Step 3: Add minimal Multiply implementation**

Add to `src/Calculator.Core/CalculatorEngine.cs`:

```csharp
    public double Multiply(double a, double b)
    {
        return a * b;
    }
```

- [ ] **Step 4: Run test to verify it passes**

```bash
dotnet test tests/Calculator.Tests/Calculator.Tests.csproj
```

Expected: PASS (3 tests, 0 failures).

- [ ] **Step 5: Commit**

```bash
git add .
git commit -m "feat(core): implement Multiply method in CalculatorEngine"
```

---

### Task 5: Add Division with TDD

**Files:**
- Modify: `tests/Calculator.Tests/CalculatorEngineTests.cs`
- Modify: `src/Calculator.Core/CalculatorEngine.cs`

**Interfaces:**
- Consumes: CalculatorEngine from Tasks 2-4
- Produces: Adds Divide method that throws on division by zero

- [ ] **Step 1: Write the failing test for Divide method**

Add to `tests/Calculator.Tests/CalculatorEngineTests.cs`:

```csharp
    [Fact]
    public void Divide_TwoPositiveNumbers_ReturnsQuotient()
    {
        var engine = new CalculatorEngine();
        var result = engine.Divide(20, 4);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        var engine = new CalculatorEngine();
        Assert.Throws<DivideByZeroException>(() => engine.Divide(10, 0));
    }
```

- [ ] **Step 2: Run test to verify it fails**

```bash
dotnet test tests/Calculator.Tests/Calculator.Tests.csproj
```

Expected: FAIL with "Divide does not exist".

- [ ] **Step 3: Add minimal Divide implementation**

Add to `src/Calculator.Core/CalculatorEngine.cs`:

```csharp
    public double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero");
        return a / b;
    }
```

- [ ] **Step 4: Run test to verify it passes**

```bash
dotnet test tests/Calculator.Tests/Calculator.Tests.csproj
```

Expected: PASS (5 tests, 0 failures).

- [ ] **Step 5: Commit**

```bash
git add .
git commit -m "feat(core): implement Divide method with zero check in CalculatorEngine"
```

---

### Task 6: Create MainForm GUI

**Files:**
- Create: `src/Calculator.UI/MainForm.cs`
- Create: `src/Calculator.UI/MainForm.Designer.cs`
- Modify: `src/Calculator.UI/Program.cs` (if needed)
- Modify: `src/Calculator.UI/Calculator.UI.csproj` (remove auto-generated Form1 if present)

**Interfaces:**
- Consumes: CalculatorEngine from Core project
- Produces: Functional Windows Forms calculator UI

- [ ] **Step 1: Remove default Form1 files if they exist**

```bash
Remove-Item src/Calculator.UI/Form1.cs -ErrorAction SilentlyContinue
Remove-Item src/Calculator.UI/Form1.Designer.cs -ErrorAction SilentlyContinue
```

- [ ] **Step 2: Create MainForm.Designer.cs**

Create file `src/Calculator.UI/MainForm.Designer.cs`:

```csharp
namespace Calculator.UI;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TextBox txtDisplay;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnDivide;
    private System.Windows.Forms.Button btnMultiply;
    private System.Windows.Forms.Button btnSubtract;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnEquals;
    private System.Windows.Forms.Button btnDecimal;
    private System.Windows.Forms.Button[] btnDigits;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.txtDisplay = new System.Windows.Forms.TextBox();
        this.btnClear = new System.Windows.Forms.Button();
        this.btnDivide = new System.Windows.Forms.Button();
        this.btnMultiply = new System.Windows.Forms.Button();
        this.btnSubtract = new System.Windows.Forms.Button();
        this.btnAdd = new System.Windows.Forms.Button();
        this.btnEquals = new System.Windows.Forms.Button();
        this.btnDecimal = new System.Windows.Forms.Button();
        this.btnDigits = new System.Windows.Forms.Button[10];
        
        // txtDisplay
        this.txtDisplay.Font = new System.Drawing.Font("Segoe UI", 20F);
        this.txtDisplay.Location = new System.Drawing.Point(12, 12);
        this.txtDisplay.Name = "txtDisplay";
        this.txtDisplay.ReadOnly = true;
        this.txtDisplay.Size = new System.Drawing.Size(260, 43);
        this.txtDisplay.Text = "0";
        this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        
        // Buttons grid layout
        int btnSize = 60;
        int startX = 12;
        int startY = 70;
        int spacing = 5;
        
        // Row 1: 7, 8, 9, /
        CreateButton(ref this.btnDigits[7], "7", startX, startY, btnSize);
        CreateButton(ref this.btnDigits[8], "8", startX + (btnSize + spacing), startY, btnSize);
        CreateButton(ref this.btnDigits[9], "9", startX + 2 * (btnSize + spacing), startY, btnSize);
        CreateButton(ref this.btnDivide, "/", startX + 3 * (btnSize + spacing), startY, btnSize);
        
        // Row 2: 4, 5, 6, *
        CreateButton(ref this.btnDigits[4], "4", startX, startY + (btnSize + spacing), btnSize);
        CreateButton(ref this.btnDigits[5], "5", startX + (btnSize + spacing), startY + (btnSize + spacing), btnSize);
        CreateButton(ref this.btnDigits[6], "6", startX + 2 * (btnSize + spacing), startY + (btnSize + spacing), btnSize);
        CreateButton(ref this.btnMultiply, "*", startX + 3 * (btnSize + spacing), startY + (btnSize + spacing), btnSize);
        
        // Row 3: 1, 2, 3, -
        CreateButton(ref this.btnDigits[1], "1", startX, startY + 2 * (btnSize + spacing), btnSize);
        CreateButton(ref this.btnDigits[2], "2", startX + (btnSize + spacing), startY + 2 * (btnSize + spacing), btnSize);
        CreateButton(ref this.btnDigits[3], "3", startX + 2 * (btnSize + spacing), startY + 2 * (btnSize + spacing), btnSize);
        CreateButton(ref this.btnSubtract, "-", startX + 3 * (btnSize + spacing), startY + 2 * (btnSize + spacing), btnSize);
        
        // Row 4: 0, ., =, +
        CreateButton(ref this.btnDigits[0], "0", startX, startY + 3 * (btnSize + spacing), btnSize);
        CreateButton(ref this.btnDecimal, ".", startX + (btnSize + spacing), startY + 3 * (btnSize + spacing), btnSize);
        CreateButton(ref this.btnEquals, "=", startX + 2 * (btnSize + spacing), startY + 3 * (btnSize + spacing), btnSize);
        CreateButton(ref this.btnAdd, "+", startX + 3 * (btnSize + spacing), startY + 3 * (btnSize + spacing), btnSize);
        
        // btnClear
        this.btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnClear.Location = new System.Drawing.Point(startX, startY + 4 * (btnSize + spacing));
        this.btnClear.Name = "btnClear";
        this.btnClear.Size = new System.Drawing.Size(4 * btnSize + 3 * spacing, btnSize);
        this.btnClear.Text = "CLEAR";
        this.btnClear.UseVisualStyleBackColor = true;
        this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
        
        // MainForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, startY + 5 * (btnSize + spacing));
        this.Controls.Add(this.txtDisplay);
        this.Controls.Add(this.btnClear);
        for (int i = 0; i < 10; i++)
        {
            this.Controls.Add(this.btnDigits[i]);
        }
        this.Controls.Add(this.btnDivide);
        this.Controls.Add(this.btnMultiply);
        this.Controls.Add(this.btnSubtract);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.btnEquals);
        this.Controls.Add(this.btnDecimal);
        this.Name = "MainForm";
        this.Text = "Calculator";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    
    private void CreateButton(ref System.Windows.Forms.Button btn, string text, int x, int y, int size)
    {
        btn = new System.Windows.Forms.Button();
        btn.Font = new System.Drawing.Font("Segoe UI", 14F);
        btn.Location = new System.Drawing.Point(x, y);
        btn.Name = "btn" + text;
        btn.Size = new System.Drawing.Size(size, size);
        btn.Text = text;
        btn.UseVisualStyleBackColor = true;
        btn.Click += new System.EventHandler(this.btn_Click);
    }
}
```

- [ ] **Step 3: Create MainForm.cs**

Create file `src/Calculator.UI/MainForm.cs`:

```csharp
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

    private void btnClear_Click(object sender, EventArgs e)
    {
        txtDisplay.Text = "0";
        _firstNumber = 0;
        _operation = "";
        _isNewEntry = true;
    }
}
```

- [ ] **Step 4: Wire up operator button click events**

The `InitializeComponent` method in `MainForm.Designer.cs` already wires up digit buttons to `btn_Click` and clear to `btnClear_Click`. We need to wire operator buttons. Add the following to the end of `InitializeComponent` method in `MainForm.Designer.cs`, just before `this.ResumeLayout(false);`:

```csharp
        this.btnDivide.Click += new System.EventHandler(this.btnOperator_Click);
        this.btnMultiply.Click += new System.EventHandler(this.btnOperator_Click);
        this.btnSubtract.Click += new System.EventHandler(this.btnOperator_Click);
        this.btnAdd.Click += new System.EventHandler(this.btnOperator_Click);
        this.btnEquals.Click += new System.EventHandler(this.btnEquals_Click);
        this.btnDecimal.Click += new System.EventHandler(this.btnDecimal_Click);
```

- [ ] **Step 5: Add btnDecimal_Click method to MainForm.cs**

Add to `src/Calculator.UI/MainForm.cs`:

```csharp
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
```

- [ ] **Step 6: Update Program.cs to use MainForm**

Replace contents of `src/Calculator.UI/Program.cs`:

```csharp
using System;
using System.Windows.Forms;

namespace Calculator.UI;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}
```

- [ ] **Step 7: Build the entire solution**

```bash
dotnet build
```

Expected: Build succeeds with 0 errors.

- [ ] **Step 8: Run all tests to ensure nothing broke**

```bash
dotnet test
```

Expected: All 5 tests pass.

- [ ] **Step 9: Commit**

```bash
git add .
git commit -m "feat(ui): create MainForm with full calculator GUI"
```

---

### Task 7: Final Verification

**Files:** None (verification only)

**Interfaces:** None

- [ ] **Step 1: Run all tests one final time**

```bash
dotnet test
```

Expected: All 5 tests pass.

- [ ] **Step 2: Build in Release mode**

```bash
dotnet build -c Release
```

Expected: Build succeeds with 0 errors.

- [ ] **Step 3: Commit any pending changes**

```bash
git status
```

If there are uncommitted changes:

```bash
git add .
git commit -m "chore: final cleanup"
```

---

## Self-Review

1. **Spec coverage:** ✓ Addition, subtraction, multiplication, division, clear, decimal - all covered in Tasks 2-6
2. **Placeholder scan:** ✓ All steps have actual code and commands
3. **Type consistency:** ✓ CalculatorEngine uses `double` consistently throughout

## Execution Handoff

Plan complete and saved to `docs/superpowers/plans/2026-07-13-csharp-calculator-gui.md`. Two execution options:

1. **Subagent-Driven (recommended)** - I dispatch a fresh subagent per task, review between tasks, fast iteration
2. **Inline Execution** - Execute tasks in this session using executing-plans, batch execution with checkpoints

Which approach?
