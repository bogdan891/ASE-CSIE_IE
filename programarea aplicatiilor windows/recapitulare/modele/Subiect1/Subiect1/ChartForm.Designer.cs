namespace Subiect1
{
    partial class ChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.angajatiChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.angajatiChart)).BeginInit();
            this.SuspendLayout();
            // 
            // angajatiChart
            // 
            chartArea1.Name = "ChartArea1";
            this.angajatiChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.angajatiChart.Legends.Add(legend1);
            this.angajatiChart.Location = new System.Drawing.Point(58, 37);
            this.angajatiChart.Name = "angajatiChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.angajatiChart.Series.Add(series1);
            this.angajatiChart.Size = new System.Drawing.Size(642, 481);
            this.angajatiChart.TabIndex = 0;
            this.angajatiChart.Text = "angajatiChart";
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 556);
            this.Controls.Add(this.angajatiChart);
            this.Name = "ChartForm";
            this.Text = "ChartForm";
            ((System.ComponentModel.ISupportInitialize)(this.angajatiChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart angajatiChart;
    }
}