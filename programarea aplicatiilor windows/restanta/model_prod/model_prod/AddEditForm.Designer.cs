namespace model_prod
{
    partial class AddEditForm
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
            this.txtDenumire = new System.Windows.Forms.TextBox();
            this.txtPret = new System.Windows.Forms.TextBox();
            this.btnSalvare = new System.Windows.Forms.Button();
            this.btnAnulare = new System.Windows.Forms.Button();
            this.numCod = new System.Windows.Forms.NumericUpDown();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numCod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
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
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Denumire";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pret";
            // 
            // txtDenumire
            // 
            this.txtDenumire.Location = new System.Drawing.Point(80, 42);
            this.txtDenumire.Name = "txtDenumire";
            this.txtDenumire.Size = new System.Drawing.Size(188, 20);
            this.txtDenumire.TabIndex = 4;
            // 
            // txtPret
            // 
            this.txtPret.Location = new System.Drawing.Point(80, 82);
            this.txtPret.Name = "txtPret";
            this.txtPret.Size = new System.Drawing.Size(188, 20);
            this.txtPret.TabIndex = 5;
            // 
            // btnSalvare
            // 
            this.btnSalvare.Location = new System.Drawing.Point(12, 144);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(84, 55);
            this.btnSalvare.TabIndex = 6;
            this.btnSalvare.Text = "Salvare";
            this.btnSalvare.UseVisualStyleBackColor = true;
            this.btnSalvare.Click += new System.EventHandler(this.btnSalvare_Click);
            // 
            // btnAnulare
            // 
            this.btnAnulare.Location = new System.Drawing.Point(192, 144);
            this.btnAnulare.Name = "btnAnulare";
            this.btnAnulare.Size = new System.Drawing.Size(84, 55);
            this.btnAnulare.TabIndex = 7;
            this.btnAnulare.Text = "Anulare";
            this.btnAnulare.UseVisualStyleBackColor = true;
            this.btnAnulare.Click += new System.EventHandler(this.btnAnulare_Click);
            // 
            // numCod
            // 
            this.numCod.Location = new System.Drawing.Point(80, 9);
            this.numCod.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numCod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCod.Name = "numCod";
            this.numCod.Size = new System.Drawing.Size(188, 20);
            this.numCod.TabIndex = 8;
            this.numCod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 211);
            this.Controls.Add(this.numCod);
            this.Controls.Add(this.btnAnulare);
            this.Controls.Add(this.btnSalvare);
            this.Controls.Add(this.txtPret);
            this.Controls.Add(this.txtDenumire);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEditForm";
            this.Text = "AddEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.numCod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDenumire;
        private System.Windows.Forms.TextBox txtPret;
        private System.Windows.Forms.Button btnSalvare;
        private System.Windows.Forms.Button btnAnulare;
        private System.Windows.Forms.NumericUpDown numCod;
        private System.Windows.Forms.ErrorProvider err;
    }
}