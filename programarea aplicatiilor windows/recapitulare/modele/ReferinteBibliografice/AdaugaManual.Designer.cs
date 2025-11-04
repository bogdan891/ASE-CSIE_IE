namespace ReferinteBibliografice
{
    partial class AdaugaManual
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
            this.tbISBN = new System.Windows.Forms.TextBox();
            this.tbPret = new System.Windows.Forms.TextBox();
            this.tbTitlu = new System.Windows.Forms.TextBox();
            this.cbCategorie = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbISBN
            // 
            this.tbISBN.Location = new System.Drawing.Point(303, 77);
            this.tbISBN.Name = "tbISBN";
            this.tbISBN.Size = new System.Drawing.Size(121, 22);
            this.tbISBN.TabIndex = 0;
            // 
            // tbPret
            // 
            this.tbPret.Location = new System.Drawing.Point(303, 233);
            this.tbPret.Name = "tbPret";
            this.tbPret.Size = new System.Drawing.Size(121, 22);
            this.tbPret.TabIndex = 1;
            // 
            // tbTitlu
            // 
            this.tbTitlu.Location = new System.Drawing.Point(303, 181);
            this.tbTitlu.Name = "tbTitlu";
            this.tbTitlu.Size = new System.Drawing.Size(121, 22);
            this.tbTitlu.TabIndex = 2;
            // 
            // cbCategorie
            // 
            this.cbCategorie.FormattingEnabled = true;
            this.cbCategorie.Items.AddRange(new object[] {
            "SF",
            "Politise",
            "Corpul uman",
            "Psihologie"});
            this.cbCategorie.Location = new System.Drawing.Point(303, 127);
            this.cbCategorie.Name = "cbCategorie";
            this.cbCategorie.Size = new System.Drawing.Size(121, 24);
            this.cbCategorie.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "ISBN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Categorie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Titlu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pret";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "Adauga";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AdaugaManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCategorie);
            this.Controls.Add(this.tbTitlu);
            this.Controls.Add(this.tbPret);
            this.Controls.Add(this.tbISBN);
            this.Name = "AdaugaManual";
            this.Text = "AdaugaManual";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbISBN;
        private System.Windows.Forms.TextBox tbPret;
        private System.Windows.Forms.TextBox tbTitlu;
        private System.Windows.Forms.ComboBox cbCategorie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}