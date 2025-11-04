namespace examen_paw_triunghi
{
    partial class FormTextDisplay
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
            this.textAfisare = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textAfisare
            // 
            this.textAfisare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textAfisare.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAfisare.Location = new System.Drawing.Point(0, 0);
            this.textAfisare.Multiline = true;
            this.textAfisare.Name = "textAfisare";
            this.textAfisare.ReadOnly = true;
            this.textAfisare.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textAfisare.Size = new System.Drawing.Size(519, 314);
            this.textAfisare.TabIndex = 0;
            // 
            // FormTextDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 314);
            this.Controls.Add(this.textAfisare);
            this.Name = "FormTextDisplay";
            this.Text = "Afisare elemente deserializate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textAfisare;
    }
}