namespace examen_paw_studenti
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.txtMedia = new System.Windows.Forms.TextBox();
            this.txtMatricol = new System.Windows.Forms.TextBox();
            this.btnSalvare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nr Matricol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nume";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Media";
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(84, 37);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(193, 20);
            this.txtNume.TabIndex = 3;
            // 
            // txtMedia
            // 
            this.txtMedia.Location = new System.Drawing.Point(84, 67);
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.Size = new System.Drawing.Size(193, 20);
            this.txtMedia.TabIndex = 4;
            // 
            // txtMatricol
            // 
            this.txtMatricol.Location = new System.Drawing.Point(84, 9);
            this.txtMatricol.Name = "txtMatricol";
            this.txtMatricol.Size = new System.Drawing.Size(193, 20);
            this.txtMatricol.TabIndex = 5;
            // 
            // btnSalvare
            // 
            this.btnSalvare.Location = new System.Drawing.Point(15, 112);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(110, 48);
            this.btnSalvare.TabIndex = 6;
            this.btnSalvare.Text = "Salvare";
            this.btnSalvare.UseVisualStyleBackColor = true;
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 172);
            this.Controls.Add(this.btnSalvare);
            this.Controls.Add(this.txtMatricol);
            this.Controls.Add(this.txtMedia);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEditForm";
            this.Text = "AddEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.TextBox txtMedia;
        private System.Windows.Forms.TextBox txtMatricol;
        private System.Windows.Forms.Button btnSalvare;
    }
}