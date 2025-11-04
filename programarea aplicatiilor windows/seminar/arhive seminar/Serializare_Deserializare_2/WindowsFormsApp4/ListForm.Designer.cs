namespace WindowsFormsApp4
{
    partial class ListForm
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
            this.sectiiDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.sectiiDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // sectiiDataGridView
            // 
            this.sectiiDataGridView.AllowUserToAddRows = false;
            this.sectiiDataGridView.AllowUserToDeleteRows = false;
            this.sectiiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sectiiDataGridView.Location = new System.Drawing.Point(12, 12);
            this.sectiiDataGridView.Name = "sectiiDataGridView";
            this.sectiiDataGridView.ReadOnly = true;
            this.sectiiDataGridView.RowHeadersWidth = 82;
            this.sectiiDataGridView.RowTemplate.Height = 33;
            this.sectiiDataGridView.Size = new System.Drawing.Size(1157, 611);
            this.sectiiDataGridView.TabIndex = 0;
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 635);
            this.Controls.Add(this.sectiiDataGridView);
            this.Name = "ListForm";
            this.Text = "ListForm";
            ((System.ComponentModel.ISupportInitialize)(this.sectiiDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView sectiiDataGridView;
    }
}