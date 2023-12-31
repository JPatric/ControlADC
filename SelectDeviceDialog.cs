using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ControlADC
{
    public class SelectDeviceDialog : Form
    {
        private ComboBox comboBoxDevices;
        private Button buttonOK;
        private Button buttonCancel;

        public string SelectedDeviceName { get; private set; }

        public SelectDeviceDialog(List<string> deviceNames)
        {
            InitializeComponent();
            comboBoxDevices.Items.AddRange(deviceNames.ToArray());
        }

        private void InitializeComponent()
        {
            comboBoxDevices = new ComboBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            SuspendLayout();

            comboBoxDevices.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDevices.FormattingEnabled = true;
            comboBoxDevices.Location = new System.Drawing.Point(12, 12);
            comboBoxDevices.Name = "comboBoxDevices";
            comboBoxDevices.Size = new System.Drawing.Size(200, 21);
            comboBoxDevices.TabIndex = 0;

            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new System.Drawing.Point(12, 50);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new System.Drawing.Size(75, 23);
            buttonOK.TabIndex = 1;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;

            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new System.Drawing.Point(137, 50);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(75, 23);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancelar";
            buttonCancel.UseVisualStyleBackColor = true;

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(224, 86);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(comboBoxDevices);
            Name = "SelectDeviceDialog";
            Text = "Seleccionar dispositivo Bluetooth";
            ResumeLayout(false);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (DialogResult == DialogResult.OK)
            {
                // Obtener el dispositivo seleccionado.
                SelectedDeviceName = comboBoxDevices.SelectedItem as string;
            }
        }
    }
}
