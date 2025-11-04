namespace examen_paw_prod
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDenumire = new System.Windows.Forms.TextBox();
            this.numCod = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPret = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCod)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cod Produs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Denumire";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pret unitar";
            // 
            // txtDenumire
            // 
            this.txtDenumire.Location = new System.Drawing.Point(80, 28);
            this.txtDenumire.Name = "txtDenumire";
            this.txtDenumire.Size = new System.Drawing.Size(250, 20);
            this.txtDenumire.TabIndex = 4;
            // 
            // numCod
            // 
            this.numCod.Location = new System.Drawing.Point(80, 2);
            this.numCod.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numCod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCod.Name = "numCod";
            this.numCod.Size = new System.Drawing.Size(250, 20);
            this.numCod.TabIndex = 5;
            this.numCod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 99);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 56);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Salvare";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPret
            // 
            this.txtPret.Location = new System.Drawing.Point(80, 53);
            this.txtPret.Name = "txtPret";
            this.txtPret.Size = new System.Drawing.Size(250, 20);
            this.txtPret.TabIndex = 8;
            // 
            // FormAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 162);
            this.Controls.Add(this.txtPret);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numCod);
            this.Controls.Add(this.txtDenumire);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAddEdit";
            this.Text = "FormAddEdit";
            ((System.ComponentModel.ISupportInitialize)(this.numCod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDenumire;
        private System.Windows.Forms.NumericUpDown numCod;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPret;
    }
}