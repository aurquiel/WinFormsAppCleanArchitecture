namespace WinFormsAppCleanArchitecture
{
    partial class FormNewEditBeer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            txtAlcohol = new TextBox();
            cboBrand = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 25);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 64);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 1;
            label2.Text = "Marca";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 103);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 2;
            label3.Text = "Alcohol";
            // 
            // txtName
            // 
            txtName.Location = new Point(118, 25);
            txtName.MaxLength = 50;
            txtName.Name = "txtName";
            txtName.Size = new Size(270, 27);
            txtName.TabIndex = 1;
            // 
            // txtAlcohol
            // 
            txtAlcohol.Location = new Point(118, 103);
            txtAlcohol.MaxLength = 18;
            txtAlcohol.Name = "txtAlcohol";
            txtAlcohol.Size = new Size(270, 27);
            txtAlcohol.TabIndex = 3;
            txtAlcohol.KeyPress += txtAlcohol_KeyPress;
            // 
            // cboBrand
            // 
            cboBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBrand.FormattingEnabled = true;
            cboBrand.Location = new Point(118, 64);
            cboBrand.Name = "cboBrand";
            cboBrand.Size = new Size(270, 28);
            cboBrand.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(184, 165);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormNewEditBeer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 225);
            Controls.Add(button1);
            Controls.Add(cboBrand);
            Controls.Add(txtAlcohol);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNewEditBeer";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nueva Cerveza";
            Load += FormNewEditBeer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtName;
        private TextBox txtAlcohol;
        private ComboBox cboBrand;
        private Button button1;
    }
}