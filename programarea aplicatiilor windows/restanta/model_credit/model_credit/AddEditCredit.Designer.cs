namespace model_credit
{
    partial class AddEditCredit
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.txtDobanda = new System.Windows.Forms.TextBox();
            this.txtValoare = new System.Windows.Forms.TextBox();
            this.dataAcord = new System.Windows.Forms.DateTimePicker();
            this.numPerioada = new System.Windows.Forms.NumericUpDown();
            this.btnSalvare = new System.Windows.Forms.Button();
            this.btnAnulare = new System.Windows.Forms.Button();
            this.erp = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numPerioada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valoarea Creditului";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Perioada de Creditare";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Data Acordarii";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Dobanda";
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(51, 6);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(223, 20);
            this.txtClient.TabIndex = 6;
            // 
            // txtDobanda
            // 
            this.txtDobanda.Location = new System.Drawing.Point(69, 64);
            this.txtDobanda.Name = "txtDobanda";
            this.txtDobanda.Size = new System.Drawing.Size(205, 20);
            this.txtDobanda.TabIndex = 7;
            // 
            // txtValoare
            // 
            this.txtValoare.Location = new System.Drawing.Point(113, 35);
            this.txtValoare.Name = "txtValoare";
            this.txtValoare.Size = new System.Drawing.Size(161, 20);
            this.txtValoare.TabIndex = 8;
            // 
            // dataAcord
            // 
            this.dataAcord.Location = new System.Drawing.Point(92, 95);
            this.dataAcord.Name = "dataAcord";
            this.dataAcord.Size = new System.Drawing.Size(182, 20);
            this.dataAcord.TabIndex = 9;
            // 
            // numPerioada
            // 
            this.numPerioada.Location = new System.Drawing.Point(127, 126);
            this.numPerioada.Name = "numPerioada";
            this.numPerioada.Size = new System.Drawing.Size(147, 20);
            this.numPerioada.TabIndex = 10;
            // 
            // btnSalvare
            // 
            this.btnSalvare.Location = new System.Drawing.Point(16, 156);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(90, 38);
            this.btnSalvare.TabIndex = 11;
            this.btnSalvare.Text = "Salvare";
            this.btnSalvare.UseVisualStyleBackColor = true;
            this.btnSalvare.Click += new System.EventHandler(this.btnSalvare_Click);
            // 
            // btnAnulare
            // 
            this.btnAnulare.Location = new System.Drawing.Point(184, 156);
            this.btnAnulare.Name = "btnAnulare";
            this.btnAnulare.Size = new System.Drawing.Size(90, 38);
            this.btnAnulare.TabIndex = 12;
            this.btnAnulare.Text = "Anulare";
            this.btnAnulare.UseVisualStyleBackColor = true;
            this.btnAnulare.Click += new System.EventHandler(this.btnAnulare_Click);
            // 
            // erp
            // 
            this.erp.ContainerControl = this;
            // 
            // AddEditCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 205);
            this.Controls.Add(this.btnAnulare);
            this.Controls.Add(this.btnSalvare);
            this.Controls.Add(this.numPerioada);
            this.Controls.Add(this.dataAcord);
            this.Controls.Add(this.txtValoare);
            this.Controls.Add(this.txtDobanda);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEditCredit";
            this.Text = "AddEditCredit";
            ((System.ComponentModel.ISupportInitialize)(this.numPerioada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.TextBox txtDobanda;
        private System.Windows.Forms.TextBox txtValoare;
        private System.Windows.Forms.DateTimePicker dataAcord;
        private System.Windows.Forms.NumericUpDown numPerioada;
        private System.Windows.Forms.Button btnSalvare;
        private System.Windows.Forms.Button btnAnulare;
        private System.Windows.Forms.ErrorProvider erp;
    }
}