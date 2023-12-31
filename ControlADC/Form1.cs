using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;






namespace ControlADC
{
    public partial class MainPage : Form
    {
        private bool isReceivingData = false;
        private bool isConnected = false;
        private SerialPort serialPort1;
        private List<double> dataValues = new List<double>();
        private double maxValue = double.MinValue;
        private double minValue = double.MaxValue;
        private int dataCount = 0;

        public MainPage()
        {
            InitializeComponent();
            InicializarComboBoxPuertos();

            // Configure automatic chart update
            ConfigureAutomaticChartUpdate();


        }
        
        private void buttonStop_Click(object sender, EventArgs e)
        {
            isReceivingData = false;
            isConnected = false;
            buttonStart.Enabled = true;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            buttonSave.Enabled = true;
            Disconnect();

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                if (comboBoxSerialPort.SelectedItem == null)
                {
                    MessageBox.Show("Select a port before connecting.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }


                string selectedPort = comboBoxSerialPort.SelectedItem.ToString();

                if (selectedPort.StartsWith("COM"))
                {
                    ConnectToSerialPort(selectedPort);
                }

            }
            else
            {
                Disconnect();


                buttonSave.Enabled = false;
            }
        }
        


        private void Disconnect()
        {
            if (serialPort1 != null && serialPort1.IsOpen)
            {
                serialPort1.Close();
                serialPort1.Dispose(); // Release resources associated with the serial port.
            }

            isConnected = false;
            isReceivingData = false;
        }


        private void updateTimer_Tick(object sender, EventArgs e)
        {   //// Update chart with new data
            if (dataValues.Count > 0)
            {
                // Add new values to the data series
                foreach (var value in dataValues)
                {
                    chartData.Series["Data"].Points.AddY(value);
                }
                dataValues.Clear();

                // Set Y-axis range based on current values
                AutoScaleYAxis();

                // Shift and remove old points
                int puntosAMostrar = 100;
                if (chartData.Series["Data"].Points.Count > puntosAMostrar)
                {
                    chartData.Series["Data"].Points.RemoveAt(0);
                }

                // Manually set X-axis range
                int puntoFinal = chartData.Series["Data"].Points.Count - 1;
                int puntoInicial = Math.Max(0, puntoFinal - puntosAMostrar + 1);

                // Manually set X-axis range
                chartData.ChartAreas[0].AxisX.Minimum = puntoInicial;
                chartData.ChartAreas[0].AxisX.Maximum = puntoFinal;

                // Update max and min labels
                UpdateUI();
            }
        }

        private void UpdateChart(double value)
        {
            // Add new data point to the chart series
            chartData.Series["Data"].Points.AddY(value);

            // Adjust the view window to show the last 100 points
            int windowSize = 100;
            if (chartData.Series["Data"].Points.Count > windowSize)
            {
                chartData.ChartAreas[0].AxisX.Minimum = chartData.Series["Data"].Points.Count - windowSize;
                chartData.ChartAreas[0].AxisX.Maximum = chartData.Series["Data"].Points.Count - 1;
            }
            else
            {
                chartData.ChartAreas[0].AxisX.Minimum = 0;
                chartData.ChartAreas[0].AxisX.Maximum = windowSize - 1;
            }

            AutoScaleYAxis();
        }

        private void AutoScaleYAxis()
        {
            try
            {
                // Get Y-axis values from the chart series
                var yValues = chartData.Series["Data"].Points.Select(p => p.YValues[0]).ToList();
                double minY = yValues.Min();
                double maxY = yValues.Max();

                // Manually set Y-axis range only if necessary
                if (minY < chartData.ChartAreas[0].AxisY.Minimum || maxY > chartData.ChartAreas[0].AxisY.Maximum)
                {
                    chartData.ChartAreas[0].AxisY.Minimum = minY;
                    chartData.ChartAreas[0].AxisY.Maximum = maxY;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Exception while adjusting Y-axis range: " + ex.Message);
            }
        }



        private void UpdateUI()
        {
            var yValues = chartData.Series["Data"].Points.Select(p => p.YValues[0]).ToList();
            double minY = yValues.Min();
            double maxY = yValues.Max();

            // Update max and min labels with the latest values
            panelMax.BeginInvoke((MethodInvoker)(() =>
            {
                labelMax.Text = maxY.ToString();
            }));

            panelMin.BeginInvoke((MethodInvoker)(() =>
            {
                labelMin.Text = minY.ToString();
            }));
        }







        private void ConnectToSerialPort(string portName)
        {
            try
            {
                // Initialize and open the serial port
                serialPort1 = new SerialPort(portName, 9600);
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
                serialPort1.Open();

                isConnected = true;

                buttonStart.Enabled = false;
                buttonStop.Enabled = true;
                isReceivingData = true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (chartData.Series["Data"].Points.Count == 0)

            {
                // Display a message if there are no data points to save
                MessageBox.Show("No data to save.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                // Configure Save File Dialog for saving data to a text file
                saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";
                saveFileDialog1.Title = "Save data to a text file";
                saveFileDialog1.FileName = "amplitude_data";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Save data points to the selected file
                        string filePath = saveFileDialog1.FileName;

                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            foreach (var point in chartData.Series["Data"].Points)
                            {
                                writer.WriteLine(point.YValues[0]);
                            }
                        }
                        MessageBox.Show("Data saved successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void InicializarComboBoxPuertos()
        {
            // Initialize the ComboBox with available COM ports
            string[] ports = SerialPort.GetPortNames();
            comboBoxSerialPort.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                comboBoxSerialPort.SelectedIndex = 0;
            }
        }



        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!isReceivingData)
                return;// Exit data reception if isReceivingData is false

            SerialPort sp = (SerialPort)sender;
            string serialData = sp.ReadLine();
            //Console.WriteLine("Data: " + serialData);

            string[] lines = serialData.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                try
                {
                    double value;
                    if (double.TryParse(line, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                    {
                      // Console.WriteLine("Data: " + value);
                        AgregarDatoAlListBox(value.ToString());

                        chartData.Invoke((MethodInvoker)(() =>
                        {
                            UpdateChart(value); // Call method to update the chart
                        }));
                        dataCount++; // Increment data count

                        if (value > maxValue)
                        {
                            maxValue = value;
                            panelMax.BeginInvoke((MethodInvoker)(() =>
                            {
                                labelMax.Text = maxValue.ToString();
                            }));
                        }

                        if (value < minValue)
                        {
                            minValue = value;
                            panelMin.BeginInvoke((MethodInvoker)(() =>
                            {
                                labelMin.Text = minValue.ToString();
                            }));
                        }
                        labelDataCount.BeginInvoke((MethodInvoker)(() =>
                        {
                            labelDataCount.Text = dataCount.ToString();
                        }));
                    }
                    else
                    {
                        Console.WriteLine("Invalid number format: " + line);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number format: " + line);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Overflow when converting to double: " + line);
                }

                // Check if data reception should be exited
                if (!isReceivingData)
                    break;
            }
        }


        private void AgregarDatoAlListBox(string nuevoDato)
        {
            listBoxDataFeed.Invoke((MethodInvoker)(() =>
            {
                listBoxDataFeed.Items.Add(nuevoDato);
                listBoxDataFeed.TopIndex = listBoxDataFeed.Items.Count - 1;
            }));
        }

        private void btnPorts_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear current items in the combo box
                comboBoxSerialPort.Items.Clear();

                // Get the names of available COM ports
                string[] ports = SerialPort.GetPortNames();

                // Add COM port names to the combo box
                comboBoxSerialPort.Items.AddRange(ports);

                // If ports are available, select the first one by default
                if (ports.Length > 0)
                {
                    comboBoxSerialPort.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No available COM ports found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching for ports: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ConfigureAutomaticChartUpdate()
        {
            Timer updateTimer = new Timer();
            updateTimer.Interval = 100; // Update every 100 ms 
            updateTimer.Tick += updateTimer_Tick;
            updateTimer.Start();
            chartData.ChartAreas[0].AxisY.IsStartedFromZero = false;

        }







    }
}
