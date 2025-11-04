namespace Charts {
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.companiesListBox = new System.Windows.Forms.ListBox();
            this.stocksChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.stocksChart)).BeginInit();
            this.SuspendLayout();
            // 
            // companiesListBox
            // 
            this.companiesListBox.FormattingEnabled = true;
            this.companiesListBox.Location = new System.Drawing.Point(12, 12);
            this.companiesListBox.Name = "companiesListBox";
            this.companiesListBox.Size = new System.Drawing.Size(210, 550);
            this.companiesListBox.TabIndex = 0;
            this.companiesListBox.SelectedIndexChanged += new System.EventHandler(this.companiesListBox_SelectedIndexChanged);
            // 
            // stocksChart
            // 
            chartArea2.Name = "ChartArea1";
            this.stocksChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.stocksChart.Legends.Add(legend2);
            this.stocksChart.Location = new System.Drawing.Point(228, 12);
            this.stocksChart.Name = "stocksChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.stocksChart.Series.Add(series2);
            this.stocksChart.Size = new System.Drawing.Size(717, 550);
            this.stocksChart.TabIndex = 1;
            this.stocksChart.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 572);
            this.Controls.Add(this.stocksChart);
            this.Controls.Add(this.companiesListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.stocksChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox companiesListBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart stocksChart;
    }
}

