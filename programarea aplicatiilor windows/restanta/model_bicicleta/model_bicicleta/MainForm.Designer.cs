namespace model_bicicleta
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
            this.lvB = new System.Windows.Forms.ListView();
            this.lvU = new System.Windows.Forms.ListView();
            this.txtSuma = new System.Windows.Forms.TextBox();
            this.preview = new System.Windows.Forms.PrintPreviewDialog();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serializareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvB
            // 
            this.lvB.HideSelection = false;
            this.lvB.Location = new System.Drawing.Point(0, 27);
            this.lvB.Name = "lvB";
            this.lvB.Size = new System.Drawing.Size(379, 420);
            this.lvB.TabIndex = 0;
            this.lvB.UseCompatibleStateImageBehavior = false;
            // 
            // lvU
            // 
            this.lvU.HideSelection = false;
            this.lvU.Location = new System.Drawing.Point(380, 27);
            this.lvU.Name = "lvU";
            this.lvU.Size = new System.Drawing.Size(420, 420);
            this.lvU.TabIndex = 2;
            this.lvU.UseCompatibleStateImageBehavior = false;
            // 
            // txtSuma
            // 
            this.txtSuma.Location = new System.Drawing.Point(0, 453);
            this.txtSuma.Name = "txtSuma";
            this.txtSuma.Size = new System.Drawing.Size(800, 20);
            this.txtSuma.TabIndex = 3;
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printPreviewToolStripMenuItem,
            this.serializareToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // serializareToolStripMenuItem
            // 
            this.serializareToolStripMenuItem.Name = "serializareToolStripMenuItem";
            this.serializareToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.serializareToolStripMenuItem.Text = "Serializare";
            this.serializareToolStripMenuItem.Click += new System.EventHandler(this.serializareToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 476);
            this.Controls.Add(this.txtSuma);
            this.Controls.Add(this.lvU);
            this.Controls.Add(this.lvB);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Retea de Biciclete";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvB;
        private System.Windows.Forms.ListView lvU;
        private System.Windows.Forms.TextBox txtSuma;
        private System.Windows.Forms.PrintPreviewDialog preview;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serializareToolStripMenuItem;
    }
}

