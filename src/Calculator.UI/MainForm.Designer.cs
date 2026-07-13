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

        // Wire up operator button click events
        this.btnDivide.Click += new System.EventHandler(this.btnOperator_Click);
        this.btnMultiply.Click += new System.EventHandler(this.btnOperator_Click);
        this.btnSubtract.Click += new System.EventHandler(this.btnOperator_Click);
        this.btnAdd.Click += new System.EventHandler(this.btnOperator_Click);
        this.btnEquals.Click += new System.EventHandler(this.btnEquals_Click);
        this.btnDecimal.Click += new System.EventHandler(this.btnDecimal_Click);

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
