namespace model_angajati
{
    partial class AddEditAngajat
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.dataN = new System.Windows.Forms.DateTimePicker();
            this.comboCompanie = new System.Windows.Forms.ComboBox();
            this.btnSalvare = new System.Windows.Forms.Button();
            this.btnAnulare = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data Nasterii";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Companie";
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(86, 9);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(200, 20);
            this.txtNume.TabIndex = 3;
            // 
            // dataN
            // 
            this.dataN.Location = new System.Drawing.Point(86, 39);
            this.dataN.Name = "dataN";
            this.dataN.Size = new System.Drawing.Size(200, 20);
            this.dataN.TabIndex = 4;
            // 
            // comboCompanie
            // 
            this.comboCompanie.FormattingEnabled = true;
            this.comboCompanie.Location = new System.Drawing.Point(86, 74);
            this.comboCompanie.Name = "comboCompanie";
            this.comboCompanie.Size = new System.Drawing.Size(200, 21);
            this.comboCompanie.TabIndex = 5;
            // 
            // btnSalvare
            // 
            this.btnSalvare.Location = new System.Drawing.Point(12, 132);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(114, 59);
            this.btnSalvare.TabIndex = 6;
            this.btnSalvare.Text = "Salvare";
            this.btnSalvare.UseVisualStyleBackColor = true;
            this.btnSalvare.Click += new System.EventHandler(this.btnSalvare_Click);
            // 
            // btnAnulare
            // 
            this.btnAnulare.Location = new System.Drawing.Point(208, 132);
            this.btnAnulare.Name = "btnAnulare";
            this.btnAnulare.Size = new System.Drawing.Size(114, 59);
            this.btnAnulare.TabIndex = 7;
            this.btnAnulare.Text = "Anulare";
            this.btnAnulare.UseVisualStyleBackColor = true;
            this.btnAnulare.Click += new System.EventHandler(this.btnAnulare_Click);
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // AddEditAngajat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 203);
            this.Controls.Add(this.btnAnulare);
            this.Controls.Add(this.btnSalvare);
            this.Controls.Add(this.comboCompanie);
            this.Controls.Add(this.dataN);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEditAngajat";
            this.Text = "AddEditAngajat";
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.DateTimePicker dataN;
        private System.Windows.Forms.ComboBox comboCompanie;
        private System.Windows.Forms.Button btnSalvare;
        private System.Windows.Forms.Button btnAnulare;
        private System.Windows.Forms.ErrorProvider err;
    }
}