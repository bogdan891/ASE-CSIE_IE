namespace examen_paw_prod
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
            this.lstProduse = new System.Windows.Forms.ListView();
            this.adaugareProdusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serializareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deserializareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretulMinimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.adaugareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstProduse
            // 
            this.lstProduse.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lstProduse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstProduse.HideSelection = false;
            this.lstProduse.Location = new System.Drawing.Point(0, 24);
            this.lstProduse.Name = "lstProduse";
            this.lstProduse.Size = new System.Drawing.Size(364, 426);
            this.lstProduse.TabIndex = 2;
            this.lstProduse.UseCompatibleStateImageBehavior = false;
            // 
            // adaugareProdusToolStripMenuItem
            // 
            this.adaugareProdusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugareToolStripMenuItem,
            this.editareToolStripMenuItem});
            this.adaugareProdusToolStripMenuItem.Name = "adaugareProdusToolStripMenuItem";
            this.adaugareProdusToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.adaugareProdusToolStripMenuItem.Text = "Gestionare";
            // 
            // serializareToolStripMenuItem
            // 
            this.serializareToolStripMenuItem.Name = "serializareToolStripMenuItem";
            this.serializareToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.serializareToolStripMenuItem.Text = "Serializare";
            this.serializareToolStripMenuItem.Click += new System.EventHandler(this.serializareToolStripMenuItem_Click);
            // 
            // deserializareToolStripMenuItem
            // 
            this.deserializareToolStripMenuItem.Name = "deserializareToolStripMenuItem";
            this.deserializareToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.deserializareToolStripMenuItem.Text = "Deserializare";
            this.deserializareToolStripMenuItem.Click += new System.EventHandler(this.deserializareToolStripMenuItem_Click);
            // 
            // pretulMinimToolStripMenuItem
            // 
            this.pretulMinimToolStripMenuItem.Name = "pretulMinimToolStripMenuItem";
            this.pretulMinimToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.pretulMinimToolStripMenuItem.Text = "Pretul minim";
            this.pretulMinimToolStripMenuItem.Click += new System.EventHandler(this.pretulMinimToolStripMenuItem_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugareProdusToolStripMenuItem,
            this.serializareToolStripMenuItem,
            this.deserializareToolStripMenuItem,
            this.pretulMinimToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(364, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // adaugareToolStripMenuItem
            // 
            this.adaugareToolStripMenuItem.Name = "adaugareToolStripMenuItem";
            this.adaugareToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.adaugareToolStripMenuItem.Text = "Adaugare";
            this.adaugareToolStripMenuItem.Click += new System.EventHandler(this.adaugareToolStripMenuItem_Click);
            // 
            // editareToolStripMenuItem
            // 
            this.editareToolStripMenuItem.Name = "editareToolStripMenuItem";
            this.editareToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editareToolStripMenuItem.Text = "Editare";
            this.editareToolStripMenuItem.Click += new System.EventHandler(this.editareToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 450);
            this.Controls.Add(this.lstProduse);
            this.Controls.Add(this.menuStrip2);
            this.Name = "MainForm";
            this.Text = "Gestionare produse";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lstProduse;
        private System.Windows.Forms.ToolStripMenuItem adaugareProdusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serializareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deserializareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretulMinimToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem adaugareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editareToolStripMenuItem;
    }
}

