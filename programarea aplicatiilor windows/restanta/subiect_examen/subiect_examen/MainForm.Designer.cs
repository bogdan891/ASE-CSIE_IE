namespace subiect_examen
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
            this.generareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergereTrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serializareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvTrenuri = new System.Windows.Forms.DataGridView();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.printPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrenuri)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generareToolStripMenuItem,
            this.stergereTrenToolStripMenuItem,
            this.serializareToolStripMenuItem,
            this.printPreviewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generareToolStripMenuItem
            // 
            this.generareToolStripMenuItem.Name = "generareToolStripMenuItem";
            this.generareToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.generareToolStripMenuItem.Text = "Generare ";
            this.generareToolStripMenuItem.Click += new System.EventHandler(this.generareToolStripMenuItem_Click);
            // 
            // stergereTrenToolStripMenuItem
            // 
            this.stergereTrenToolStripMenuItem.Name = "stergereTrenToolStripMenuItem";
            this.stergereTrenToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.stergereTrenToolStripMenuItem.Text = "Stergere tren";
            this.stergereTrenToolStripMenuItem.Click += new System.EventHandler(this.stergereTrenToolStripMenuItem_Click);
            // 
            // serializareToolStripMenuItem
            // 
            this.serializareToolStripMenuItem.Name = "serializareToolStripMenuItem";
            this.serializareToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.serializareToolStripMenuItem.Text = "Serializare";
            this.serializareToolStripMenuItem.Click += new System.EventHandler(this.serializareToolStripMenuItem_Click);
            // 
            // dgvTrenuri
            // 
            this.dgvTrenuri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrenuri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrenuri.Location = new System.Drawing.Point(0, 24);
            this.dgvTrenuri.Name = "dgvTrenuri";
            this.dgvTrenuri.Size = new System.Drawing.Size(800, 426);
            this.dgvTrenuri.TabIndex = 1;
            // 
            // printPreview
            // 
            this.printPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreview.Enabled = true;
            this.printPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreview.Icon")));
            this.printPreview.Name = "printPreview";
            this.printPreview.Visible = false;
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTrenuri);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Trenuri";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrenuri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergereTrenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serializareToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvTrenuri;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.PrintPreviewDialog printPreview;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
    }
}

