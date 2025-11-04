namespace examen_paw_poligon
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.numLinie = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEticheta = new System.Windows.Forms.TextBox();
            this.btnCuloare = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.btnAdaugaPunct = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnSalvare = new System.Windows.Forms.Button();
            this.btnAnulare = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numLinie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Culoare";
            // 
            // pnlPreview
            // 
            this.pnlPreview.Location = new System.Drawing.Point(61, 12);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(186, 38);
            this.pnlPreview.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Grosime Linie";
            // 
            // numLinie
            // 
            this.numLinie.Location = new System.Drawing.Point(88, 82);
            this.numLinie.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLinie.Name = "numLinie";
            this.numLinie.Size = new System.Drawing.Size(120, 20);
            this.numLinie.TabIndex = 3;
            this.numLinie.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Eticheta";
            // 
            // txtEticheta
            // 
            this.txtEticheta.Location = new System.Drawing.Point(74, 124);
            this.txtEticheta.Name = "txtEticheta";
            this.txtEticheta.Size = new System.Drawing.Size(143, 20);
            this.txtEticheta.TabIndex = 5;
            // 
            // btnCuloare
            // 
            this.btnCuloare.Location = new System.Drawing.Point(286, 11);
            this.btnCuloare.Name = "btnCuloare";
            this.btnCuloare.Size = new System.Drawing.Size(127, 39);
            this.btnCuloare.TabIndex = 6;
            this.btnCuloare.Text = "Culoare";
            this.btnCuloare.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "X";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(74, 164);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(143, 20);
            this.txtX.TabIndex = 9;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(74, 198);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(143, 20);
            this.txtY.TabIndex = 10;
            // 
            // btnAdaugaPunct
            // 
            this.btnAdaugaPunct.Location = new System.Drawing.Point(74, 235);
            this.btnAdaugaPunct.Name = "btnAdaugaPunct";
            this.btnAdaugaPunct.Size = new System.Drawing.Size(140, 43);
            this.btnAdaugaPunct.TabIndex = 11;
            this.btnAdaugaPunct.Text = "Adauga Punct";
            this.btnAdaugaPunct.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(255, 124);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(233, 147);
            this.listBox1.TabIndex = 12;
            // 
            // btnSalvare
            // 
            this.btnSalvare.Location = new System.Drawing.Point(15, 320);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(109, 41);
            this.btnSalvare.TabIndex = 13;
            this.btnSalvare.Text = "Salvare";
            this.btnSalvare.UseVisualStyleBackColor = true;
            // 
            // btnAnulare
            // 
            this.btnAnulare.Location = new System.Drawing.Point(391, 320);
            this.btnAnulare.Name = "btnAnulare";
            this.btnAnulare.Size = new System.Drawing.Size(111, 41);
            this.btnAnulare.TabIndex = 14;
            this.btnAnulare.Text = "Anulare";
            this.btnAnulare.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 377);
            this.Controls.Add(this.btnAnulare);
            this.Controls.Add(this.btnSalvare);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnAdaugaPunct);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCuloare);
            this.Controls.Add(this.txtEticheta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numLinie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlPreview);
            this.Controls.Add(this.label1);
            this.Name = "FormAddEdit";
            this.Text = "FormAddEdit";
            ((System.ComponentModel.ISupportInitialize)(this.numLinie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numLinie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEticheta;
        private System.Windows.Forms.Button btnCuloare;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Button btnAdaugaPunct;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSalvare;
        private System.Windows.Forms.Button btnAnulare;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}