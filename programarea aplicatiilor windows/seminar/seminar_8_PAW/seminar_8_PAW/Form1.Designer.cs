namespace seminar_8_PAW
{
    partial class Form1
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
            this.usersDataGrid = new System.Windows.Forms.DataGridView();
            this.addUserButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // usersDataGrid
            // 
            this.usersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGrid.Location = new System.Drawing.Point(22, 98);
            this.usersDataGrid.Name = "usersDataGrid";
            this.usersDataGrid.Size = new System.Drawing.Size(756, 337);
            this.usersDataGrid.TabIndex = 0;
            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(22, 24);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(139, 53);
            this.addUserButton.TabIndex = 1;
            this.addUserButton.Text = "Add User";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUser_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addUserButton);
            this.Controls.Add(this.usersDataGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView usersDataGrid;
        private System.Windows.Forms.Button addUserButton;
    }
}

