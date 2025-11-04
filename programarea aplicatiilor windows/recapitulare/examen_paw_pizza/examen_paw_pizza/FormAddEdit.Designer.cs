namespace examen_paw_pizza
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
            this.txtNume = new System.Windows.Forms.TextBox();
            this.txtBlat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckTopping = new System.Windows.Forms.CheckedListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.numDurata = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDurata)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Blat";
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(64, 6);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(215, 20);
            this.txtNume.TabIndex = 2;
            // 
            // txtBlat
            // 
            this.txtBlat.Location = new System.Drawing.Point(64, 36);
            this.txtBlat.Name = "txtBlat";
            this.txtBlat.Size = new System.Drawing.Size(215, 20);
            this.txtBlat.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Topping";
            // 
            // ckTopping
            // 
            this.ckTopping.FormattingEnabled = true;
            this.ckTopping.Location = new System.Drawing.Point(64, 99);
            this.ckTopping.Name = "ckTopping";
            this.ckTopping.Size = new System.Drawing.Size(215, 94);
            this.ckTopping.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 199);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 53);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Salvare";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Durata Realizare";
            // 
            // numDurata
            // 
            this.numDurata.Location = new System.Drawing.Point(104, 70);
            this.numDurata.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numDurata.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDurata.Name = "numDurata";
            this.numDurata.Size = new System.Drawing.Size(175, 20);
            this.numDurata.TabIndex = 8;
            this.numDurata.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 266);
            this.Controls.Add(this.numDurata);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ckTopping);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBlat);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAddEdit";
            this.Text = "FormAddEdit";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDurata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.TextBox txtBlat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox ckTopping;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.NumericUpDown numDurata;
        private System.Windows.Forms.Label label4;
    }
}