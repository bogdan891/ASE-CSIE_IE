namespace CarRentalApp {
    partial class UpdateCarForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.hasInsuranceCheckBox = new System.Windows.Forms.CheckBox();
            this.licenseNumberTextBox = new System.Windows.Forms.TextBox();
            this.licenseNumberLabel = new System.Windows.Forms.Label();
            this.seatsLabel = new System.Windows.Forms.Label();
            this.seatsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.yearLabel = new System.Windows.Forms.Label();
            this.yearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.modelTextBox = new System.Windows.Forms.TextBox();
            this.modelLabel = new System.Windows.Forms.Label();
            this.makeTextBox = new System.Windows.Forms.TextBox();
            this.makeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.seatsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(322, 166);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 25;
            this.cancelButton.Text = "Anuleaza";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(241, 166);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 24;
            this.saveButton.Text = "Salveaza";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // hasInsuranceCheckBox
            // 
            this.hasInsuranceCheckBox.AutoSize = true;
            this.hasInsuranceCheckBox.Location = new System.Drawing.Point(118, 143);
            this.hasInsuranceCheckBox.Name = "hasInsuranceCheckBox";
            this.hasInsuranceCheckBox.Size = new System.Drawing.Size(88, 17);
            this.hasInsuranceCheckBox.TabIndex = 23;
            this.hasInsuranceCheckBox.Text = "Are asigurare";
            this.hasInsuranceCheckBox.UseVisualStyleBackColor = true;
            // 
            // licenseNumberTextBox
            // 
            this.licenseNumberTextBox.Location = new System.Drawing.Point(118, 116);
            this.licenseNumberTextBox.Name = "licenseNumberTextBox";
            this.licenseNumberTextBox.Size = new System.Drawing.Size(279, 20);
            this.licenseNumberTextBox.TabIndex = 22;
            // 
            // licenseNumberLabel
            // 
            this.licenseNumberLabel.AutoSize = true;
            this.licenseNumberLabel.Location = new System.Drawing.Point(10, 119);
            this.licenseNumberLabel.Name = "licenseNumberLabel";
            this.licenseNumberLabel.Size = new System.Drawing.Size(100, 13);
            this.licenseNumberLabel.TabIndex = 21;
            this.licenseNumberLabel.Text = "Numar inmatriculare";
            // 
            // seatsLabel
            // 
            this.seatsLabel.AutoSize = true;
            this.seatsLabel.Location = new System.Drawing.Point(10, 92);
            this.seatsLabel.Name = "seatsLabel";
            this.seatsLabel.Size = new System.Drawing.Size(66, 13);
            this.seatsLabel.TabIndex = 20;
            this.seatsLabel.Text = "Numar locuri";
            // 
            // seatsNumericUpDown
            // 
            this.seatsNumericUpDown.Location = new System.Drawing.Point(118, 90);
            this.seatsNumericUpDown.Name = "seatsNumericUpDown";
            this.seatsNumericUpDown.Size = new System.Drawing.Size(279, 20);
            this.seatsNumericUpDown.TabIndex = 19;
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(10, 66);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(28, 13);
            this.yearLabel.TabIndex = 18;
            this.yearLabel.Text = "Anul";
            // 
            // yearNumericUpDown
            // 
            this.yearNumericUpDown.Location = new System.Drawing.Point(118, 64);
            this.yearNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.yearNumericUpDown.Name = "yearNumericUpDown";
            this.yearNumericUpDown.Size = new System.Drawing.Size(279, 20);
            this.yearNumericUpDown.TabIndex = 17;
            // 
            // modelTextBox
            // 
            this.modelTextBox.Location = new System.Drawing.Point(118, 38);
            this.modelTextBox.Name = "modelTextBox";
            this.modelTextBox.Size = new System.Drawing.Size(279, 20);
            this.modelTextBox.TabIndex = 16;
            // 
            // modelLabel
            // 
            this.modelLabel.AutoSize = true;
            this.modelLabel.Location = new System.Drawing.Point(10, 41);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(36, 13);
            this.modelLabel.TabIndex = 15;
            this.modelLabel.Text = "Model";
            // 
            // makeTextBox
            // 
            this.makeTextBox.Location = new System.Drawing.Point(118, 12);
            this.makeTextBox.Name = "makeTextBox";
            this.makeTextBox.Size = new System.Drawing.Size(279, 20);
            this.makeTextBox.TabIndex = 14;
            // 
            // makeLabel
            // 
            this.makeLabel.AutoSize = true;
            this.makeLabel.Location = new System.Drawing.Point(10, 15);
            this.makeLabel.Name = "makeLabel";
            this.makeLabel.Size = new System.Drawing.Size(37, 13);
            this.makeLabel.TabIndex = 13;
            this.makeLabel.Text = "Marca";
            // 
            // UpdateCarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 203);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.hasInsuranceCheckBox);
            this.Controls.Add(this.licenseNumberTextBox);
            this.Controls.Add(this.licenseNumberLabel);
            this.Controls.Add(this.seatsLabel);
            this.Controls.Add(this.seatsNumericUpDown);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.yearNumericUpDown);
            this.Controls.Add(this.modelTextBox);
            this.Controls.Add(this.modelLabel);
            this.Controls.Add(this.makeTextBox);
            this.Controls.Add(this.makeLabel);
            this.Name = "UpdateCarForm";
            this.Text = "UpdateCarForm";
            ((System.ComponentModel.ISupportInitialize)(this.seatsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox hasInsuranceCheckBox;
        private System.Windows.Forms.TextBox licenseNumberTextBox;
        private System.Windows.Forms.Label licenseNumberLabel;
        private System.Windows.Forms.Label seatsLabel;
        private System.Windows.Forms.NumericUpDown seatsNumericUpDown;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.NumericUpDown yearNumericUpDown;
        private System.Windows.Forms.TextBox modelTextBox;
        private System.Windows.Forms.Label modelLabel;
        private System.Windows.Forms.TextBox makeTextBox;
        private System.Windows.Forms.Label makeLabel;
    }
}