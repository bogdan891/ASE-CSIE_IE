namespace CosCumparaturi
{
    partial class AdaugaProdu
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
            this.label4 = new System.Windows.Forms.Label();
            this.tbCod = new System.Windows.Forms.TextBox();
            this.tbPret = new System.Windows.Forms.TextBox();
            this.tbDenumire = new System.Windows.Forms.TextBox();
            this.tbCantitate = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cod produs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Denumire";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pret";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cantiate";
            // 
            // tbCod
            // 
            this.tbCod.Location = new System.Drawing.Point(306, 110);
            this.tbCod.Name = "tbCod";
            this.tbCod.Size = new System.Drawing.Size(100, 22);
            this.tbCod.TabIndex = 4;
            // 
            // tbPret
            // 
            this.tbPret.Location = new System.Drawing.Point(306, 203);
            this.tbPret.Name = "tbPret";
            this.tbPret.Size = new System.Drawing.Size(100, 22);
            this.tbPret.TabIndex = 5;
            // 
            // tbDenumire
            // 
            this.tbDenumire.Location = new System.Drawing.Point(306, 153);
            this.tbDenumire.Name = "tbDenumire";
            this.tbDenumire.Size = new System.Drawing.Size(100, 22);
            this.tbDenumire.TabIndex = 5;
            // 
            // tbCantitate
            // 
            this.tbCantitate.Location = new System.Drawing.Point(306, 249);
            this.tbCantitate.Name = "tbCantitate";
            this.tbCantitate.Size = new System.Drawing.Size(100, 22);
            this.tbCantitate.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(242, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Salveaza";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AdaugaProdu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbCantitate);
            this.Controls.Add(this.tbDenumire);
            this.Controls.Add(this.tbPret);
            this.Controls.Add(this.tbCod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AdaugaProdu";
            this.Text = "AdaugaProdu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbCod;
        public System.Windows.Forms.TextBox tbPret;
        public System.Windows.Forms.TextBox tbDenumire;
        public System.Windows.Forms.TextBox tbCantitate;
        public System.Windows.Forms.Button button1;
    }
}