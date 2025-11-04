namespace model_angajati
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adaugaAngajatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergeAngajatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvareInXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstAngajati = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugaAngajatToolStripMenuItem,
            this.stergeAngajatToolStripMenuItem,
            this.salvareInXMLToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(319, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adaugaAngajatToolStripMenuItem
            // 
            this.adaugaAngajatToolStripMenuItem.Name = "adaugaAngajatToolStripMenuItem";
            this.adaugaAngajatToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.adaugaAngajatToolStripMenuItem.Text = "Adauga Angajat";
            this.adaugaAngajatToolStripMenuItem.Click += new System.EventHandler(this.adaugaAngajatToolStripMenuItem_Click);
            // 
            // stergeAngajatToolStripMenuItem
            // 
            this.stergeAngajatToolStripMenuItem.Name = "stergeAngajatToolStripMenuItem";
            this.stergeAngajatToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.stergeAngajatToolStripMenuItem.Text = "Sterge Angajat";
            this.stergeAngajatToolStripMenuItem.Click += new System.EventHandler(this.stergeAngajatToolStripMenuItem_Click);
            // 
            // salvareInXMLToolStripMenuItem
            // 
            this.salvareInXMLToolStripMenuItem.Name = "salvareInXMLToolStripMenuItem";
            this.salvareInXMLToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.salvareInXMLToolStripMenuItem.Text = "Salvare in XML";
            this.salvareInXMLToolStripMenuItem.Click += new System.EventHandler(this.salvareInXMLToolStripMenuItem_Click);
            // 
            // lstAngajati
            // 
            this.lstAngajati.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAngajati.HideSelection = false;
            this.lstAngajati.Location = new System.Drawing.Point(0, 24);
            this.lstAngajati.Name = "lstAngajati";
            this.lstAngajati.Size = new System.Drawing.Size(319, 281);
            this.lstAngajati.TabIndex = 1;
            this.lstAngajati.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 305);
            this.Controls.Add(this.lstAngajati);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Angajati";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adaugaAngajatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergeAngajatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvareInXMLToolStripMenuItem;
        private System.Windows.Forms.ListView lstAngajati;
    }
}

