namespace model_prod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adaugaProdusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fisierBinarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serializareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deserializareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstProduse = new System.Windows.Forms.ListView();
            this.pretulMinimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvareInBazaDeDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pPD = new System.Windows.Forms.PrintPreviewDialog();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugaProdusToolStripMenuItem,
            this.fisierBinarToolStripMenuItem,
            this.pretulMinimToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.salvareInBazaDeDateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(573, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adaugaProdusToolStripMenuItem
            // 
            this.adaugaProdusToolStripMenuItem.Name = "adaugaProdusToolStripMenuItem";
            this.adaugaProdusToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.adaugaProdusToolStripMenuItem.Text = "Adauga Produs";
            this.adaugaProdusToolStripMenuItem.Click += new System.EventHandler(this.adaugaProdusToolStripMenuItem_Click);
            // 
            // fisierBinarToolStripMenuItem
            // 
            this.fisierBinarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serializareToolStripMenuItem,
            this.deserializareToolStripMenuItem});
            this.fisierBinarToolStripMenuItem.Name = "fisierBinarToolStripMenuItem";
            this.fisierBinarToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.fisierBinarToolStripMenuItem.Text = "Fisier Binar";
            // 
            // serializareToolStripMenuItem
            // 
            this.serializareToolStripMenuItem.Name = "serializareToolStripMenuItem";
            this.serializareToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serializareToolStripMenuItem.Text = "Serializare";
            this.serializareToolStripMenuItem.Click += new System.EventHandler(this.serializareToolStripMenuItem_Click);
            // 
            // deserializareToolStripMenuItem
            // 
            this.deserializareToolStripMenuItem.Name = "deserializareToolStripMenuItem";
            this.deserializareToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deserializareToolStripMenuItem.Text = "Deserializare";
            this.deserializareToolStripMenuItem.Click += new System.EventHandler(this.deserializareToolStripMenuItem_Click);
            // 
            // lstProduse
            // 
            this.lstProduse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstProduse.HideSelection = false;
            this.lstProduse.Location = new System.Drawing.Point(0, 24);
            this.lstProduse.Name = "lstProduse";
            this.lstProduse.Size = new System.Drawing.Size(573, 426);
            this.lstProduse.TabIndex = 1;
            this.lstProduse.UseCompatibleStateImageBehavior = false;
            // 
            // pretulMinimToolStripMenuItem
            // 
            this.pretulMinimToolStripMenuItem.Name = "pretulMinimToolStripMenuItem";
            this.pretulMinimToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.pretulMinimToolStripMenuItem.Text = "Pretul Minim";
            this.pretulMinimToolStripMenuItem.Click += new System.EventHandler(this.pretulMinimToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // salvareInBazaDeDateToolStripMenuItem
            // 
            this.salvareInBazaDeDateToolStripMenuItem.Name = "salvareInBazaDeDateToolStripMenuItem";
            this.salvareInBazaDeDateToolStripMenuItem.Size = new System.Drawing.Size(138, 20);
            this.salvareInBazaDeDateToolStripMenuItem.Text = "Salvare in Baza de date";
            this.salvareInBazaDeDateToolStripMenuItem.Click += new System.EventHandler(this.salvareInBazaDeDateToolStripMenuItem_Click);
            // 
            // pPD
            // 
            this.pPD.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.pPD.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.pPD.ClientSize = new System.Drawing.Size(400, 300);
            this.pPD.Enabled = true;
            this.pPD.Icon = ((System.Drawing.Icon)(resources.GetObject("pPD.Icon")));
            this.pPD.Name = "pPD";
            this.pPD.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 450);
            this.Controls.Add(this.lstProduse);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Produse";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adaugaProdusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fisierBinarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serializareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deserializareToolStripMenuItem;
        private System.Windows.Forms.ListView lstProduse;
        private System.Windows.Forms.ToolStripMenuItem pretulMinimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvareInBazaDeDateToolStripMenuItem;
        private System.Windows.Forms.PrintPreviewDialog pPD;
        private System.Drawing.Printing.PrintDocument printDoc;
    }
}

