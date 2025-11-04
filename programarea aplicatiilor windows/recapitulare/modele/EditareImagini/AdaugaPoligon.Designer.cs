namespace EditareImagini
{
    partial class AdaugaPoligon
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCuloare = new System.Windows.Forms.TextBox();
            this.tbGrosime = new System.Windows.Forms.TextBox();
            this.tbCod = new System.Windows.Forms.TextBox();
            this.tbEticheta = new System.Windows.Forms.TextBox();
            this.tbPuncte = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Culoare";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Grosime linie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cod figura";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Eticheta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Puncte";
            // 
            // tbCuloare
            // 
            this.tbCuloare.Location = new System.Drawing.Point(266, 80);
            this.tbCuloare.Name = "tbCuloare";
            this.tbCuloare.Size = new System.Drawing.Size(100, 22);
            this.tbCuloare.TabIndex = 5;
            // 
            // tbGrosime
            // 
            this.tbGrosime.Location = new System.Drawing.Point(266, 115);
            this.tbGrosime.Name = "tbGrosime";
            this.tbGrosime.Size = new System.Drawing.Size(100, 22);
            this.tbGrosime.TabIndex = 6;
            // 
            // tbCod
            // 
            this.tbCod.Location = new System.Drawing.Point(266, 154);
            this.tbCod.Name = "tbCod";
            this.tbCod.Size = new System.Drawing.Size(100, 22);
            this.tbCod.TabIndex = 7;
            // 
            // tbEticheta
            // 
            this.tbEticheta.Location = new System.Drawing.Point(266, 191);
            this.tbEticheta.Name = "tbEticheta";
            this.tbEticheta.Size = new System.Drawing.Size(100, 22);
            this.tbEticheta.TabIndex = 8;
            // 
            // tbPuncte
            // 
            this.tbPuncte.Location = new System.Drawing.Point(266, 228);
            this.tbPuncte.Multiline = true;
            this.tbPuncte.Name = "tbPuncte";
            this.tbPuncte.Size = new System.Drawing.Size(100, 117);
            this.tbPuncte.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(393, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(343, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Punctele se adauga in felul urmator \"valoare1;valoare2,\" ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Salveaza";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AdaugaPoligon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPuncte);
            this.Controls.Add(this.tbEticheta);
            this.Controls.Add(this.tbCod);
            this.Controls.Add(this.tbGrosime);
            this.Controls.Add(this.tbCuloare);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AdaugaPoligon";
            this.Text = "AdaugaPoligon";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCuloare;
        private System.Windows.Forms.TextBox tbGrosime;
        private System.Windows.Forms.TextBox tbCod;
        private System.Windows.Forms.TextBox tbEticheta;
        private System.Windows.Forms.TextBox tbPuncte;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}