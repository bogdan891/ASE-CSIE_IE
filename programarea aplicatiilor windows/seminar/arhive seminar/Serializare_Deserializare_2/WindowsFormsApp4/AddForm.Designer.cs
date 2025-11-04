namespace WindowsFormsApp4
{
    partial class AddForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numeTextBox = new System.Windows.Forms.TextBox();
            this.candidatNumeric1 = new System.Windows.Forms.NumericUpDown();
            this.candidatNumeric2 = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.candidatNumeric1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candidatNumeric2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume sectie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Voturi candidat 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Voturi candidat 2";
            // 
            // numeTextBox
            // 
            this.numeTextBox.Location = new System.Drawing.Point(205, 18);
            this.numeTextBox.Name = "numeTextBox";
            this.numeTextBox.Size = new System.Drawing.Size(402, 31);
            this.numeTextBox.TabIndex = 3;
            // 
            // candidatNumeric1
            // 
            this.candidatNumeric1.Location = new System.Drawing.Point(205, 155);
            this.candidatNumeric1.Name = "candidatNumeric1";
            this.candidatNumeric1.Size = new System.Drawing.Size(402, 31);
            this.candidatNumeric1.TabIndex = 4;
            // 
            // candidatNumeric2
            // 
            this.candidatNumeric2.Location = new System.Drawing.Point(205, 243);
            this.candidatNumeric2.Name = "candidatNumeric2";
            this.candidatNumeric2.Size = new System.Drawing.Size(402, 31);
            this.candidatNumeric2.TabIndex = 5;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(205, 357);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(136, 76);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Salveaza";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(422, 357);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(154, 76);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Anuleaza";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 583);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.candidatNumeric2);
            this.Controls.Add(this.candidatNumeric1);
            this.Controls.Add(this.numeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddForm";
            this.Text = "AddForm";
            ((System.ComponentModel.ISupportInitialize)(this.candidatNumeric1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candidatNumeric2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox numeTextBox;
        private System.Windows.Forms.NumericUpDown candidatNumeric1;
        private System.Windows.Forms.NumericUpDown candidatNumeric2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}