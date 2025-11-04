namespace WindowsFormsApp1 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.usersDataGridView = new System.Windows.Forms.DataGridView();
            this.insertDummyUserButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // usersDataGridView
            // 
            this.usersDataGridView.AllowUserToAddRows = false;
            this.usersDataGridView.AllowUserToDeleteRows = false;
            this.usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGridView.Location = new System.Drawing.Point(12, 51);
            this.usersDataGridView.Name = "usersDataGridView";
            this.usersDataGridView.ReadOnly = true;
            this.usersDataGridView.Size = new System.Drawing.Size(776, 387);
            this.usersDataGridView.TabIndex = 0;
            // 
            // insertDummyUserButton
            // 
            this.insertDummyUserButton.Location = new System.Drawing.Point(12, 12);
            this.insertDummyUserButton.Name = "insertDummyUserButton";
            this.insertDummyUserButton.Size = new System.Drawing.Size(75, 23);
            this.insertDummyUserButton.TabIndex = 1;
            this.insertDummyUserButton.Text = "Insert";
            this.insertDummyUserButton.UseVisualStyleBackColor = true;
            this.insertDummyUserButton.Click += new System.EventHandler(this.InsertDummyUserButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.insertDummyUserButton);
            this.Controls.Add(this.usersDataGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView usersDataGridView;
        private System.Windows.Forms.Button insertDummyUserButton;
    }
}

