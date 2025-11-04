namespace model_student
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
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studenti = new System.Windows.Forms.DataGridView();
            this.bazaDeDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preview = new System.Windows.Forms.PrintPreviewDialog();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studenti)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printPreviewToolStripMenuItem,
            this.bazaDeDateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(314, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // studenti
            // 
            this.studenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studenti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studenti.Location = new System.Drawing.Point(0, 24);
            this.studenti.Name = "studenti";
            this.studenti.Size = new System.Drawing.Size(314, 357);
            this.studenti.TabIndex = 1;
            // 
            // bazaDeDateToolStripMenuItem
            // 
            this.bazaDeDateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizareToolStripMenuItem});
            this.bazaDeDateToolStripMenuItem.Name = "bazaDeDateToolStripMenuItem";
            this.bazaDeDateToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.bazaDeDateToolStripMenuItem.Text = "Baza de date";
            // 
            // actualizareToolStripMenuItem
            // 
            this.actualizareToolStripMenuItem.Name = "actualizareToolStripMenuItem";
            this.actualizareToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.actualizareToolStripMenuItem.Text = "Actualizare";
            this.actualizareToolStripMenuItem.Click += new System.EventHandler(this.actualizareToolStripMenuItem_Click);
            // 
            // preview
            // 
            this.preview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.preview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.preview.ClientSize = new System.Drawing.Size(400, 300);
            this.preview.Enabled = true;
            this.preview.Icon = ((System.Drawing.Icon)(resources.GetObject("preview.Icon")));
            this.preview.Name = "preview";
            this.preview.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 381);
            this.Controls.Add(this.studenti);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Studenti";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.DataGridView studenti;
        private System.Windows.Forms.ToolStripMenuItem bazaDeDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizareToolStripMenuItem;
        private System.Windows.Forms.PrintPreviewDialog preview;
        private System.Drawing.Printing.PrintDocument printDoc;
    }
}

