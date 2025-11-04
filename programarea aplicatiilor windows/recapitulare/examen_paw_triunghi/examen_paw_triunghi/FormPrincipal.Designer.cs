namespace examen_paw_triunghi
{
    partial class FormPrincipal
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
            this.fisierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inserareTriunghiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvareBazaDeDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afisareTriunghiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvareTriunghiuriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incarcareTriunghiuriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fisierToolStripMenuItem,
            this.inserareTriunghiToolStripMenuItem,
            this.salvareBazaDeDateToolStripMenuItem,
            this.afisareTriunghiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(641, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fisierToolStripMenuItem
            // 
            this.fisierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salvareTriunghiuriToolStripMenuItem,
            this.incarcareTriunghiuriToolStripMenuItem});
            this.fisierToolStripMenuItem.Name = "fisierToolStripMenuItem";
            this.fisierToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fisierToolStripMenuItem.Text = "Fisier";
            // 
            // inserareTriunghiToolStripMenuItem
            // 
            this.inserareTriunghiToolStripMenuItem.Name = "inserareTriunghiToolStripMenuItem";
            this.inserareTriunghiToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.inserareTriunghiToolStripMenuItem.Text = "Inserare Triunghi";
            this.inserareTriunghiToolStripMenuItem.Click += new System.EventHandler(this.inserareTriunghiToolStripMenuItem_Click);
            // 
            // salvareBazaDeDateToolStripMenuItem
            // 
            this.salvareBazaDeDateToolStripMenuItem.Name = "salvareBazaDeDateToolStripMenuItem";
            this.salvareBazaDeDateToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.salvareBazaDeDateToolStripMenuItem.Text = "Salvare baza de date";
            this.salvareBazaDeDateToolStripMenuItem.Click += new System.EventHandler(this.salvareBazaDeDateToolStripMenuItem_Click);
            // 
            // afisareTriunghiToolStripMenuItem
            // 
            this.afisareTriunghiToolStripMenuItem.Name = "afisareTriunghiToolStripMenuItem";
            this.afisareTriunghiToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.afisareTriunghiToolStripMenuItem.Text = "Afisare triunghiuri";
            this.afisareTriunghiToolStripMenuItem.Click += new System.EventHandler(this.afisareTriunghiToolStripMenuItem_Click);
            // 
            // salvareTriunghiuriToolStripMenuItem
            // 
            this.salvareTriunghiuriToolStripMenuItem.Name = "salvareTriunghiuriToolStripMenuItem";
            this.salvareTriunghiuriToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.salvareTriunghiuriToolStripMenuItem.Text = "Salvare Triunghiuri";
            this.salvareTriunghiuriToolStripMenuItem.Click += new System.EventHandler(this.salvareTriunghiuriToolStripMenuItem_Click);
            // 
            // incarcareTriunghiuriToolStripMenuItem
            // 
            this.incarcareTriunghiuriToolStripMenuItem.Name = "incarcareTriunghiuriToolStripMenuItem";
            this.incarcareTriunghiuriToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.incarcareTriunghiuriToolStripMenuItem.Text = "Incarcare Triunghiuri";
            this.incarcareTriunghiuriToolStripMenuItem.Click += new System.EventHandler(this.incarcareTriunghiuriToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 469);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "Pagina Principală";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fisierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inserareTriunghiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvareBazaDeDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afisareTriunghiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvareTriunghiuriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incarcareTriunghiuriToolStripMenuItem;
    }
}

