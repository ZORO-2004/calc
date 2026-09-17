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
    private System.Windows.Forms.Button btnBack;
    #nullable enable
    private System.Windows.Forms.Button? btnAngle;
    #nullable disable
    private System.Windows.Forms.Panel pnlScientific;
    private System.Windows.Forms.Button[] btnDigits;
    private System.Windows.Forms.MenuStrip msMenu;
    private System.Windows.Forms.ToolStripMenuItem miFile;
    private System.Windows.Forms.ToolStripMenuItem miNew;
    private System.Windows.Forms.ToolStripMenuItem miExit;
    private System.Windows.Forms.ToolStripMenuItem miView;
    private System.Windows.Forms.ToolStripMenuItem miScientific;
    private System.Windows.Forms.ToolStripMenuItem miHelp;
    private System.Windows.Forms.ToolStripMenuItem miAbout;

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
        this.btnBack = new System.Windows.Forms.Button();
        this.pnlScientific = new System.Windows.Forms.Panel();
        this.btnDigits = new System.Windows.Forms.Button[10];
        this.msMenu = new System.Windows.Forms.MenuStrip();
        this.miFile = new System.Windows.Forms.ToolStripMenuItem();
        this.miNew = new System.Windows.Forms.ToolStripMenuItem();
        this.miExit = new System.Windows.Forms.ToolStripMenuItem();
        this.miView = new System.Windows.Forms.ToolStripMenuItem();
        this.miScientific = new System.Windows.Forms.ToolStripMenuItem();
        this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
        this.miAbout = new System.Windows.Forms.ToolStripMenuItem();

        // txtDisplay (slimmer, backspace sits to its right)
        this.txtDisplay.Font = new System.Drawing.Font("Segoe UI", 20F);
        this.txtDisplay.Location = new System.Drawing.Point(12, 36);
        this.txtDisplay.Name = "txtDisplay";
        this.txtDisplay.ReadOnly = true;
        this.txtDisplay.Size = new System.Drawing.Size(210, 43);
        this.txtDisplay.Text = "0";
        this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

        // btnBack (backspace)
        this.btnBack.Font = new System.Drawing.Font("Segoe UI", 16F);
        this.btnBack.Location = new System.Drawing.Point(230, 36);
        this.btnBack.Name = "btnBack";
        this.btnBack.Size = new System.Drawing.Size(52, 43);
        this.btnBack.Text = "⌫";
        this.btnBack.UseVisualStyleBackColor = true;
        this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

        // Standard keypad grid
        int btnSize = 60;
        int spacing = 5;
        int startX = 12;
        int startY = 94;
        CreateButton(ref this.btnDigits[7], "7", startX, startY, btnSize);
        CreateButton(ref this.btnDigits[8], "8", startX + (btnSize + spacing), startY, btnSize);
        CreateButton(ref this.btnDigits[9], "9", startX + 2 * (btnSize + spacing), startY, btnSize);
        CreateButton(ref this.btnDivide, "/", startX + 3 * (btnSize + spacing), startY, btnSize);
        CreateButton(ref this.btnDigits[4], "4", startX, startY + (btnSize + spacing), btnSize);
        CreateButton(ref this.btnDigits[5], "5", startX + (btnSize + spacing), startY + (btnSize + spacing), btnSize);
        CreateButton(ref this.btnDigits[6], "6", startX + 2 * (btnSize + spacing), startY + (btnSize + spacing), btnSize);
        CreateButton(ref this.btnMultiply, "*", startX + 3 * (btnSize + spacing), startY + (btnSize + spacing), btnSize);
        CreateButton(ref this.btnDigits[1], "1", startX, startY + 2 * (btnSize + spacing), btnSize);
        CreateButton(ref this.btnDigits[2], "2", startX + (btnSize + spacing), startY + 2 * (btnSize + spacing), btnSize);
        CreateButton(ref this.btnDigits[3], "3", startX + 2 * (btnSize + spacing), startY + 2 * (btnSize + spacing), btnSize);
        CreateButton(ref this.btnSubtract, "-", startX + 3 * (btnSize + spacing), startY + 2 * (btnSize + spacing), btnSize);
        CreateButton(ref this.btnDigits[0], "0", startX, startY + 3 * (btnSize + spacing), btnSize);
        CreateButton(ref this.btnDecimal, ".", startX + (btnSize + spacing), startY + 3 * (btnSize + spacing), btnSize);
        CreateButton(ref this.btnEquals, "=", startX + 2 * (btnSize + spacing), startY + 3 * (btnSize + spacing), btnSize);
        CreateButton(ref this.btnAdd, "+", startX + 3 * (btnSize + spacing), startY + 3 * (btnSize + spacing), btnSize);

        this.btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnClear.Location = new System.Drawing.Point(startX, startY + 4 * (btnSize + spacing));
        this.btnClear.Name = "btnClear";
        this.btnClear.Size = new System.Drawing.Size(4 * btnSize + 3 * spacing, btnSize);
        this.btnClear.Text = "CLEAR";
        this.btnClear.UseVisualStyleBackColor = true;
        this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

        // pnlScientific — right-hand column, parent of all scientific buttons
        this.pnlScientific.Location = new System.Drawing.Point(285, 94);
        this.pnlScientific.Name = "pnlScientific";
        this.pnlScientific.Size = new System.Drawing.Size(232, 392);
        this.pnlScientific.BackColor = System.Drawing.Color.WhiteSmoke;

        int sciW = 52, sciH = 52, sciSp = 4;
        string[,] sci = {
            { "MS", "ms", "MR", "mr", "MC", "mc", "M+", "madd" },
            { "π", "pi", "e", "e", "DEG", "degrees", "", "" },
            { "sin", "sin", "cos", "cos", "tan", "tan", "^", "power" },
            { "asin", "asin", "acos", "acos", "atan", "atan", "±", "sign" },
            { "√", "sqrt", "∛", "cbrt", "x²", "square", "x³", "cube" },
            { "ln", "ln", "log", "log10", "eˣ", "exp", "10ˣ", "tenpow" },
            { "n!", "factorial", "1/x", "recip", "CE", "ce", "C", "c" },
        };
        for (int r = 0; r < 7; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                string text = sci[r, c * 2];
                string tag = sci[r, c * 2 + 1];
                if (string.IsNullOrEmpty(text)) continue;
                int x = 4 + c * (sciW + sciSp);
                int y = 4 + r * (sciH + sciSp);
                Button btn = CreateSciButton(text, tag, x, y);
                if (tag == "degrees")
                {
                    btn.Name = "btnAngle";
                    this.btnAngle = btn;
                }
                this.pnlScientific.Controls.Add(btn);
            }
        }

        // Event wiring
        for (int i = 0; i < 10; i++)
            this.btnDigits[i].Click += new System.EventHandler(this.btn_Click);
        this.btnDivide.Click += new System.EventHandler(this.btnOperator_Click);
        this.btnMultiply.Click += new System.EventHandler(this.btnOperator_Click);
        this.btnSubtract.Click += new System.EventHandler(this.btnOperator_Click);
        this.btnAdd.Click += new System.EventHandler(this.btnOperator_Click);
        this.btnEquals.Click += new System.EventHandler(this.btnEquals_Click);
        this.btnDecimal.Click += new System.EventHandler(this.btnDecimal_Click);

        // MenuStrip
        this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miFile, this.miView, this.miHelp });
        this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miNew, this.miExit });
        this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miScientific });
        this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miAbout });

        this.miFile.Text = "File";
        this.miNew.Text = "New";
        this.miExit.Text = "Exit";
        this.miView.Text = "View";
        this.miScientific.Text = "Scientific";
        this.miScientific.CheckOnClick = true;
        this.miScientific.Checked = true;
        this.miHelp.Text = "Help";
        this.miAbout.Text = "About";

        this.msMenu.Location = new System.Drawing.Point(0, 0);
        this.msMenu.Name = "msMenu";
        this.msMenu.Size = new System.Drawing.Size(532, 24);
        this.msMenu.TabIndex = 0;

        this.miNew.Click += new System.EventHandler(this.miNew_Click);
        this.miExit.Click += new System.EventHandler(this.miExit_Click);
        this.miScientific.Click += new System.EventHandler(this.miScientific_Click);
        this.miAbout.Click += new System.EventHandler(this.miAbout_Click);

        this.MainMenuStrip = this.msMenu;
        this.KeyPreview = true;

        // MainForm
        this.ClientSize = new System.Drawing.Size(532, 502);
        this.Controls.Add(this.txtDisplay);
        this.Controls.Add(this.btnBack);
        this.Controls.Add(this.pnlScientific);
        this.Controls.Add(this.btnClear);
        for (int i = 0; i < 10; i++)
            this.Controls.Add(this.btnDigits[i]);
        this.Controls.Add(this.btnDivide);
        this.Controls.Add(this.btnMultiply);
        this.Controls.Add(this.btnSubtract);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.btnEquals);
        this.Controls.Add(this.btnDecimal);
        this.Controls.Add(this.msMenu);
        this.Name = "MainForm";
        this.Text = "Scientific Calculator";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private Button CreateSciButton(string text, string tag, int x, int y)
    {
        Button btn = new();
        btn.Font = new System.Drawing.Font("Segoe UI", 11F);
        btn.Location = new System.Drawing.Point(x, y);
        btn.Name = "btn" + tag;
        btn.Size = new System.Drawing.Size(52, 52);
        btn.Text = text;
        btn.Tag = tag;
        btn.UseVisualStyleBackColor = true;
        btn.Click += new System.EventHandler(this.SciButton_Click);
        return btn;
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
    }
}
