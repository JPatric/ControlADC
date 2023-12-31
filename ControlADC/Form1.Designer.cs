using System;

namespace ControlADC
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPorts = new System.Windows.Forms.Button();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxGain = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelValue = new System.Windows.Forms.Panel();
            this.listBoxDataFeed = new System.Windows.Forms.ListBox();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.panelMax = new System.Windows.Forms.Panel();
            this.labelMax = new System.Windows.Forms.Label();
            this.panelMin = new System.Windows.Forms.Panel();
            this.labelMin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDataCount = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).BeginInit();
            this.panelValue.SuspendLayout();
            this.panelMax.SuspendLayout();
            this.panelMin.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.btnPorts);
            this.groupBox1.Controls.Add(this.comboBoxSerialPort);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 362);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 111);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SERIAL PORT";
            // 
            // btnPorts
            // 
            this.btnPorts.Location = new System.Drawing.Point(38, 30);
            this.btnPorts.Name = "btnPorts";
            this.btnPorts.Size = new System.Drawing.Size(75, 23);
            this.btnPorts.TabIndex = 11;
            this.btnPorts.Text = "PORT";
            this.btnPorts.UseVisualStyleBackColor = true;
            this.btnPorts.Click += new System.EventHandler(this.btnPorts_Click);
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(38, 56);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSerialPort.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBoxGain);
            this.groupBox2.Controls.Add(this.buttonSave);
            this.groupBox2.Controls.Add(this.buttonStop);
            this.groupBox2.Controls.Add(this.buttonStart);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(228, 362);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(556, 111);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OPTION";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(429, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "GAIN";
            // 
            // comboBoxGain
            // 
            this.comboBoxGain.FormattingEnabled = true;
            this.comboBoxGain.Location = new System.Drawing.Point(397, 56);
            this.comboBoxGain.Name = "comboBoxGain";
            this.comboBoxGain.Size = new System.Drawing.Size(121, 24);
            this.comboBoxGain.TabIndex = 3;
            this.comboBoxGain.SelectedIndexChanged += new System.EventHandler(this.comboBoxGain_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.Location = new System.Drawing.Point(300, 28);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(67, 62);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "\r\n";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Image = ((System.Drawing.Image)(resources.GetObject("buttonStop.Image")));
            this.buttonStop.Location = new System.Drawing.Point(151, 33);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(92, 47);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "STOP";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Image = ((System.Drawing.Image)(resources.GetObject("buttonStart.Image")));
            this.buttonStart.Location = new System.Drawing.Point(16, 33);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(97, 47);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chartData);
            this.panel1.Location = new System.Drawing.Point(13, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 292);
            this.panel1.TabIndex = 3;
            // 
            // chartData
            // 
            this.chartData.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            chartArea2.Name = "ChartArea1";
            this.chartData.ChartAreas.Add(chartArea2);
            this.chartData.DataSource = this.chartData.Titles;
            legend2.Name = "Legend1";
            this.chartData.Legends.Add(legend2);
            this.chartData.Location = new System.Drawing.Point(3, 3);
            this.chartData.Name = "chartData";
            this.chartData.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series2.Legend = "Legend1";
            series2.Name = "Data";
            this.chartData.Series.Add(series2);
            this.chartData.Size = new System.Drawing.Size(1005, 284);
            this.chartData.TabIndex = 0;
            this.chartData.Text = "chart1";
            // 
            // panelValue
            // 
            this.panelValue.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelValue.Controls.Add(this.listBoxDataFeed);
            this.panelValue.Location = new System.Drawing.Point(1063, 42);
            this.panelValue.Name = "panelValue";
            this.panelValue.Size = new System.Drawing.Size(115, 288);
            this.panelValue.TabIndex = 4;
            // 
            // listBoxDataFeed
            // 
            this.listBoxDataFeed.FormattingEnabled = true;
            this.listBoxDataFeed.ItemHeight = 16;
            this.listBoxDataFeed.Location = new System.Drawing.Point(-2, -2);
            this.listBoxDataFeed.Name = "listBoxDataFeed";
            this.listBoxDataFeed.Size = new System.Drawing.Size(115, 292);
            this.listBoxDataFeed.TabIndex = 11;
            // 
            // panelMax
            // 
            this.panelMax.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMax.Controls.Add(this.labelMax);
            this.panelMax.Location = new System.Drawing.Point(991, 395);
            this.panelMax.Name = "panelMax";
            this.panelMax.Size = new System.Drawing.Size(96, 33);
            this.panelMax.TabIndex = 5;
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(11, 0);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(0, 16);
            this.labelMax.TabIndex = 9;
            // 
            // panelMin
            // 
            this.panelMin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMin.Controls.Add(this.labelMin);
            this.panelMin.Location = new System.Drawing.Point(1123, 392);
            this.panelMin.Name = "panelMin";
            this.panelMin.Size = new System.Drawing.Size(82, 36);
            this.panelMin.TabIndex = 6;
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(31, 5);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(7, 16);
            this.labelMin.TabIndex = 0;
            this.labelMin.Text = "\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1018, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "MAX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1147, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "MIN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "SAMPLE\r\n";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.labelDataCount);
            this.panel2.Location = new System.Drawing.Point(121, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(135, 28);
            this.panel2.TabIndex = 10;
            // 
            // labelDataCount
            // 
            this.labelDataCount.AutoSize = true;
            this.labelDataCount.Location = new System.Drawing.Point(49, 1);
            this.labelDataCount.Name = "labelDataCount";
            this.labelDataCount.Size = new System.Drawing.Size(14, 16);
            this.labelDataCount.TabIndex = 11;
            this.labelDataCount.Text = "0";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1252, 534);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelMin);
            this.Controls.Add(this.panelMax);
            this.Controls.Add(this.panelValue);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainPage";
            this.Text = "Control ADC";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).EndInit();
            this.panelValue.ResumeLayout(false);
            this.panelMax.ResumeLayout(false);
            this.panelMax.PerformLayout();
            this.panelMin.ResumeLayout(false);
            this.panelMin.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private void comboBoxGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ComboBox comboBoxSerialPort;
        private System.Windows.Forms.Button buttonSave;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelValue;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Panel panelMax;
        private System.Windows.Forms.Panel panelMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxGain;
        private System.Windows.Forms.Label labelMax;
        protected internal System.Windows.Forms.DataVisualization.Charting.Chart chartData;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelDataCount;
        private System.Windows.Forms.ListBox listBoxDataFeed;
        private System.Windows.Forms.Button btnPorts;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

