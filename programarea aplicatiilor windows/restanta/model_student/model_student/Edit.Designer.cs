namespace model_student
{
    partial class Edit
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
            this.btnSalvare = new System.Windows.Forms.Button();
            this.bntAnulare = new System.Windows.Forms.Button();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.txtNrMatricol = new System.Windows.Forms.TextBox();
            this.txtMedia = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
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
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nr matricol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Media";
            // 
            // btnSalvare
            // 
            this.btnSalvare.Location = new System.Drawing.Point(15, 94);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(105, 50);
            this.btnSalvare.TabIndex = 3;
            this.btnSalvare.Text = "Salvare";
            this.btnSalvare.UseVisualStyleBackColor = true;
            this.btnSalvare.Click += new System.EventHandler(this.btnSalvare_Click);
            // 
            // bntAnulare
            // 
            this.bntAnulare.Location = new System.Drawing.Point(178, 94);
            this.bntAnulare.Name = "bntAnulare";
            this.bntAnulare.Size = new System.Drawing.Size(105, 50);
            this.bntAnulare.TabIndex = 4;
            this.bntAnulare.Text = "Anulare";
            this.bntAnulare.UseVisualStyleBackColor = true;
            this.bntAnulare.Click += new System.EventHandler(this.bntAnulare_Click);
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(75, 6);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(227, 20);
            this.txtNume.TabIndex = 5;
            // 
            // txtNrMatricol
            // 
            this.txtNrMatricol.Location = new System.Drawing.Point(75, 31);
            this.txtNrMatricol.Name = "txtNrMatricol";
            this.txtNrMatricol.Size = new System.Drawing.Size(79, 20);
            this.txtNrMatricol.TabIndex = 6;
            // 
            // txtMedia
            // 
            this.txtMedia.Location = new System.Drawing.Point(75, 55);
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.Size = new System.Drawing.Size(79, 20);
            this.txtMedia.TabIndex = 7;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 155);
            this.Controls.Add(this.txtMedia);
            this.Controls.Add(this.txtNrMatricol);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.bntAnulare);
            this.Controls.Add(this.btnSalvare);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Edit";
            this.Text = "Edit";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSalvare;
        private System.Windows.Forms.Button bntAnulare;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.TextBox txtNrMatricol;
        private System.Windows.Forms.TextBox txtMedia;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}