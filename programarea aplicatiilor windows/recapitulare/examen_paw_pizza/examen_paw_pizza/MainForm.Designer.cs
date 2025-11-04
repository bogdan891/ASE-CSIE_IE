namespace examen_paw_pizza
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
            this.afisareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datagridViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvareInFisierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstPizza = new System.Windows.Forms.ListView();
            this.stergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afisareToolStripMenuItem,
            this.adaugareToolStripMenuItem,
            this.stergeToolStripMenuItem,
            this.salvareInFisierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(308, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // afisareToolStripMenuItem
            // 
            this.afisareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datagridViewToolStripMenuItem,
            this.treeViewToolStripMenuItem,
            this.listboxToolStripMenuItem});
            this.afisareToolStripMenuItem.Name = "afisareToolStripMenuItem";
            this.afisareToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.afisareToolStripMenuItem.Text = "Afisare";
            // 
            // datagridViewToolStripMenuItem
            // 
            this.datagridViewToolStripMenuItem.Name = "datagridViewToolStripMenuItem";
            this.datagridViewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.datagridViewToolStripMenuItem.Text = "Datagrid view";
            // 
            // treeViewToolStripMenuItem
            // 
            this.treeViewToolStripMenuItem.Name = "treeViewToolStripMenuItem";
            this.treeViewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.treeViewToolStripMenuItem.Text = "Tree view";
            // 
            // listboxToolStripMenuItem
            // 
            this.listboxToolStripMenuItem.Name = "listboxToolStripMenuItem";
            this.listboxToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.listboxToolStripMenuItem.Text = "Listbox";
            // 
            // adaugareToolStripMenuItem
            // 
            this.adaugareToolStripMenuItem.Name = "adaugareToolStripMenuItem";
            this.adaugareToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.adaugareToolStripMenuItem.Text = "Adaugare";
            this.adaugareToolStripMenuItem.Click += new System.EventHandler(this.adaugareToolStripMenuItem_Click);
            // 
            // salvareInFisierToolStripMenuItem
            // 
            this.salvareInFisierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.binarToolStripMenuItem,
            this.cSVToolStripMenuItem,
            this.xMLToolStripMenuItem});
            this.salvareInFisierToolStripMenuItem.Name = "salvareInFisierToolStripMenuItem";
            this.salvareInFisierToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.salvareInFisierToolStripMenuItem.Text = "Salvare in fisier";
            // 
            // binarToolStripMenuItem
            // 
            this.binarToolStripMenuItem.Name = "binarToolStripMenuItem";
            this.binarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.binarToolStripMenuItem.Text = "Binar";
            this.binarToolStripMenuItem.Click += new System.EventHandler(this.binarToolStripMenuItem_Click);
            // 
            // cSVToolStripMenuItem
            // 
            this.cSVToolStripMenuItem.Name = "cSVToolStripMenuItem";
            this.cSVToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cSVToolStripMenuItem.Text = "CSV";
            this.cSVToolStripMenuItem.Click += new System.EventHandler(this.cSVToolStripMenuItem_Click);
            // 
            // xMLToolStripMenuItem
            // 
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.xMLToolStripMenuItem.Text = "XML";
            this.xMLToolStripMenuItem.Click += new System.EventHandler(this.xMLToolStripMenuItem_Click);
            // 
            // lstPizza
            // 
            this.lstPizza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPizza.HideSelection = false;
            this.lstPizza.Location = new System.Drawing.Point(0, 24);
            this.lstPizza.Name = "lstPizza";
            this.lstPizza.Size = new System.Drawing.Size(308, 319);
            this.lstPizza.TabIndex = 1;
            this.lstPizza.UseCompatibleStateImageBehavior = false;
            // 
            // stergeToolStripMenuItem
            // 
            this.stergeToolStripMenuItem.Name = "stergeToolStripMenuItem";
            this.stergeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.stergeToolStripMenuItem.Text = "Sterge";
            this.stergeToolStripMenuItem.Click += new System.EventHandler(this.stergeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 343);
            this.Controls.Add(this.lstPizza);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem afisareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datagridViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treeViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvareInFisierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
        private System.Windows.Forms.ListView lstPizza;
        private System.Windows.Forms.ToolStripMenuItem stergeToolStripMenuItem;
    }
}

