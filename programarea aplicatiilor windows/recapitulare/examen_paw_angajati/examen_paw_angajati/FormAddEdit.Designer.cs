namespace examen_paw_angajati
{
    partial class FormAddEdit
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
            this.dateDN = new System.Windows.Forms.DateTimePicker();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.comboCompanie = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data Nasterii";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Companie";
            // 
            // dateDN
            // 
            this.dateDN.Location = new System.Drawing.Point(86, 48);
            this.dateDN.Name = "dateDN";
            this.dateDN.Size = new System.Drawing.Size(200, 20);
            this.dateDN.TabIndex = 3;
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(86, 6);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(200, 20);
            this.txtNume.TabIndex = 4;
            // 
            // comboCompanie
            // 
            this.comboCompanie.FormattingEnabled = true;
            this.comboCompanie.Location = new System.Drawing.Point(86, 93);
            this.comboCompanie.Name = "comboCompanie";
            this.comboCompanie.Size = new System.Drawing.Size(200, 21);
            this.comboCompanie.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 52);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Salvare";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 205);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.comboCompanie);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.dateDN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAddEdit";
            this.Text = "FormAddEdit";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateDN;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.ComboBox comboCompanie;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}