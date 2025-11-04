namespace examen_paw_angajati
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
            this.salvareRaportXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listAngajati = new System.Windows.Forms.ListView();
            this.asociereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugaAngajatToolStripMenuItem,
            this.stergeAngajatToolStripMenuItem,
            this.salvareRaportXMLToolStripMenuItem,
            this.asociereToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(390, 24);
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
            // salvareRaportXMLToolStripMenuItem
            // 
            this.salvareRaportXMLToolStripMenuItem.Name = "salvareRaportXMLToolStripMenuItem";
            this.salvareRaportXMLToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.salvareRaportXMLToolStripMenuItem.Text = "Salvare raport XML";
            this.salvareRaportXMLToolStripMenuItem.Click += new System.EventHandler(this.salvareRaportXMLToolStripMenuItem_Click);
            // 
            // listAngajati
            // 
            this.listAngajati.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listAngajati.HideSelection = false;
            this.listAngajati.Location = new System.Drawing.Point(0, 24);
            this.listAngajati.Name = "listAngajati";
            this.listAngajati.Size = new System.Drawing.Size(390, 426);
            this.listAngajati.TabIndex = 1;
            this.listAngajati.UseCompatibleStateImageBehavior = false;
            // 
            // asociereToolStripMenuItem
            // 
            this.asociereToolStripMenuItem.Name = "asociereToolStripMenuItem";
            this.asociereToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.asociereToolStripMenuItem.Text = "Asociere";
            this.asociereToolStripMenuItem.Click += new System.EventHandler(this.asociereToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 450);
            this.Controls.Add(this.listAngajati);
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
        private System.Windows.Forms.ToolStripMenuItem salvareRaportXMLToolStripMenuItem;
        private System.Windows.Forms.ListView listAngajati;
        private System.Windows.Forms.ToolStripMenuItem asociereToolStripMenuItem;
    }
}

