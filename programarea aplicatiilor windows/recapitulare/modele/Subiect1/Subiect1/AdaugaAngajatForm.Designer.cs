namespace Subiect1
{
    partial class AdaugaAngajatForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.numeTextBox = new System.Windows.Forms.TextBox();
            this.salariu = new System.Windows.Forms.Label();
            this.salariuUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.managerComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.salariuUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume";
            // 
            // numeTextBox
            // 
            this.numeTextBox.Location = new System.Drawing.Point(81, 27);
            this.numeTextBox.Name = "numeTextBox";
            this.numeTextBox.Size = new System.Drawing.Size(370, 22);
            this.numeTextBox.TabIndex = 1;
            // 
            // salariu
            // 
            this.salariu.AutoSize = true;
            this.salariu.Location = new System.Drawing.Point(16, 65);
            this.salariu.Name = "salariu";
            this.salariu.Size = new System.Drawing.Size(49, 16);
            this.salariu.TabIndex = 2;
            this.salariu.Text = "Salariu";
            // 
            // salariuUpDown
            // 
            this.salariuUpDown.Location = new System.Drawing.Point(81, 65);
            this.salariuUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.salariuUpDown.Name = "salariuUpDown";
            this.salariuUpDown.Size = new System.Drawing.Size(370, 22);
            this.salariuUpDown.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Manager";
            // 
            // managerComboBox
            // 
            this.managerComboBox.FormattingEnabled = true;
            this.managerComboBox.Location = new System.Drawing.Point(81, 101);
            this.managerComboBox.Name = "managerComboBox";
            this.managerComboBox.Size = new System.Drawing.Size(121, 24);
            this.managerComboBox.TabIndex = 5;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(331, 194);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Salveaza";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // AdaugaAngajat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.managerComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.salariuUpDown);
            this.Controls.Add(this.salariu);
            this.Controls.Add(this.numeTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AdaugaAngajat";
            this.Text = "AdaugaAngajat";
            ((System.ComponentModel.ISupportInitialize)(this.salariuUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numeTextBox;
        private System.Windows.Forms.Label salariu;
        private System.Windows.Forms.NumericUpDown salariuUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox managerComboBox;
        private System.Windows.Forms.Button saveButton;
    }
}