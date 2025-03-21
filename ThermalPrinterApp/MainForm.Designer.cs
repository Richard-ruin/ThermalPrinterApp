namespace ThermalPrinterApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Form Controls
        private System.Windows.Forms.GroupBox grpPrinterSettings;
        private System.Windows.Forms.Label lblPrinter;
        private System.Windows.Forms.ComboBox cmbPrinters;
        private System.Windows.Forms.RadioButton rbUSB;
        private System.Windows.Forms.RadioButton rbBluetooth;
        private System.Windows.Forms.RadioButton rbCOM;
        private System.Windows.Forms.ComboBox cmbCOMPorts;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnTestConnection;

        private System.Windows.Forms.GroupBox grpContent;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.CheckBox chkLarge;
        private System.Windows.Forms.RadioButton rbAlignLeft;
        private System.Windows.Forms.RadioButton rbAlignCenter;
        private System.Windows.Forms.RadioButton rbAlignRight;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.ComboBox cmbBarcodeType;
        private System.Windows.Forms.Button btnPrintText;
        private System.Windows.Forms.Button btnPrintBarcode;
        private System.Windows.Forms.Button btnPrintBoth;
        private System.Windows.Forms.Button btnCutPaper;

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;

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
            this.Size = new System.Drawing.Size(600, 500);
            this.Text = "Thermal Printer App";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Printer Settings Group
            this.grpPrinterSettings = new System.Windows.Forms.GroupBox();
            this.grpPrinterSettings.Text = "Printer Settings";
            this.grpPrinterSettings.Location = new System.Drawing.Point(10, 10);
            this.grpPrinterSettings.Size = new System.Drawing.Size(570, 120);

            // Printer selection combobox
            this.lblPrinter = new System.Windows.Forms.Label();
            this.lblPrinter.Text = "Printer:";
            this.lblPrinter.Location = new System.Drawing.Point(10, 20);
            this.lblPrinter.Size = new System.Drawing.Size(100, 20);

            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            this.cmbPrinters.Location = new System.Drawing.Point(110, 20);
            this.cmbPrinters.Size = new System.Drawing.Size(240, 20);
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Connection type
            this.rbUSB = new System.Windows.Forms.RadioButton();
            this.rbUSB.Text = "USB";
            this.rbUSB.Location = new System.Drawing.Point(10, 50);
            this.rbUSB.Checked = true;
            this.rbUSB.CheckedChanged += new System.EventHandler(this.RbUSB_CheckedChanged);

            this.rbBluetooth = new System.Windows.Forms.RadioButton();
            this.rbBluetooth.Text = "Bluetooth";
            this.rbBluetooth.Location = new System.Drawing.Point(110, 50);
            this.rbBluetooth.CheckedChanged += new System.EventHandler(this.RbBluetooth_CheckedChanged);

            this.rbCOM = new System.Windows.Forms.RadioButton();
            this.rbCOM.Text = "COM Port";
            this.rbCOM.Location = new System.Drawing.Point(210, 50);
            this.rbCOM.CheckedChanged += new System.EventHandler(this.RbCOM_CheckedChanged);

            this.cmbCOMPorts = new System.Windows.Forms.ComboBox();
            this.cmbCOMPorts.Location = new System.Drawing.Point(310, 50);
            this.cmbCOMPorts.Size = new System.Drawing.Size(120, 20);
            this.cmbCOMPorts.Enabled = false;

            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(440, 20);
            this.btnRefresh.Size = new System.Drawing.Size(100, 23);
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);

            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.Location = new System.Drawing.Point(440, 50);
            this.btnTestConnection.Size = new System.Drawing.Size(100, 23);
            this.btnTestConnection.Click += new System.EventHandler(this.BtnTestConnection_Click);

            // Content Group
            this.grpContent = new System.Windows.Forms.GroupBox();
            this.grpContent.Text = "Print Content";
            this.grpContent.Location = new System.Drawing.Point(10, 140);
            this.grpContent.Size = new System.Drawing.Size(570, 280);

            // Text content
            this.lblText = new System.Windows.Forms.Label();
            this.lblText.Text = "Text:";
            this.lblText.Location = new System.Drawing.Point(10, 20);
            this.lblText.Size = new System.Drawing.Size(100, 20);

            this.txtContent = new System.Windows.Forms.TextBox();
            this.txtContent.Multiline = true;
            this.txtContent.Location = new System.Drawing.Point(10, 40);
            this.txtContent.Size = new System.Drawing.Size(340, 100);

            // Font options
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.chkBold.Text = "Bold";
            this.chkBold.Location = new System.Drawing.Point(370, 40);

            this.chkLarge = new System.Windows.Forms.CheckBox();
            this.chkLarge.Text = "Large Font";
            this.chkLarge.Location = new System.Drawing.Point(370, 65);

            // Alignment
            this.rbAlignLeft = new System.Windows.Forms.RadioButton();
            this.rbAlignLeft.Text = "Left";
            this.rbAlignLeft.Location = new System.Drawing.Point(370, 90);
            this.rbAlignLeft.Checked = true;

            this.rbAlignCenter = new System.Windows.Forms.RadioButton();
            this.rbAlignCenter.Text = "Center";
            this.rbAlignCenter.Location = new System.Drawing.Point(420, 90);

            this.rbAlignRight = new System.Windows.Forms.RadioButton();
            this.rbAlignRight.Text = "Right";
            this.rbAlignRight.Location = new System.Drawing.Point(480, 90);

            // Barcode section
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblBarcode.Text = "Barcode/QR:";
            this.lblBarcode.Location = new System.Drawing.Point(10, 150);
            this.lblBarcode.Size = new System.Drawing.Size(100, 20);

            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtBarcode.Location = new System.Drawing.Point(110, 150);
            this.txtBarcode.Size = new System.Drawing.Size(240, 20);

            this.cmbBarcodeType = new System.Windows.Forms.ComboBox();
            this.cmbBarcodeType.Location = new System.Drawing.Point(360, 150);
            this.cmbBarcodeType.Size = new System.Drawing.Size(120, 20);
            this.cmbBarcodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBarcodeType.Items.AddRange(new object[] { "QR Code", "CODE 39", "CODE 128", "EAN-13", "UPC-A" });
            this.cmbBarcodeType.SelectedIndex = 0;

            // Print buttons
            this.btnPrintText = new System.Windows.Forms.Button();
            this.btnPrintText.Text = "Print Text";
            this.btnPrintText.Location = new System.Drawing.Point(10, 190);
            this.btnPrintText.Size = new System.Drawing.Size(120, 30);
            this.btnPrintText.Click += new System.EventHandler(this.BtnPrintText_Click);

            this.btnPrintBarcode = new System.Windows.Forms.Button();
            this.btnPrintBarcode.Text = "Print Barcode/QR";
            this.btnPrintBarcode.Location = new System.Drawing.Point(140, 190);
            this.btnPrintBarcode.Size = new System.Drawing.Size(120, 30);
            this.btnPrintBarcode.Click += new System.EventHandler(this.BtnPrintBarcode_Click);

            this.btnPrintBoth = new System.Windows.Forms.Button();
            this.btnPrintBoth.Text = "Print All";
            this.btnPrintBoth.Location = new System.Drawing.Point(270, 190);
            this.btnPrintBoth.Size = new System.Drawing.Size(120, 30);
            this.btnPrintBoth.Click += new System.EventHandler(this.BtnPrintBoth_Click);

            this.btnCutPaper = new System.Windows.Forms.Button();
            this.btnCutPaper.Text = "Feed & Cut Paper";
            this.btnCutPaper.Location = new System.Drawing.Point(400, 190);
            this.btnCutPaper.Size = new System.Drawing.Size(120, 30);
            this.btnCutPaper.Click += new System.EventHandler(this.BtnCutPaper_Click);

            // Status bar
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel.Text = "Ready";
            this.statusStrip.Items.Add(this.statusLabel);

            // Add controls to the form
            this.grpPrinterSettings.Controls.Add(this.lblPrinter);
            this.grpPrinterSettings.Controls.Add(this.cmbPrinters);
            this.grpPrinterSettings.Controls.Add(this.rbUSB);
            this.grpPrinterSettings.Controls.Add(this.rbBluetooth);
            this.grpPrinterSettings.Controls.Add(this.rbCOM);
            this.grpPrinterSettings.Controls.Add(this.cmbCOMPorts);
            this.grpPrinterSettings.Controls.Add(this.btnRefresh);
            this.grpPrinterSettings.Controls.Add(this.btnTestConnection);

            this.grpContent.Controls.Add(this.lblText);
            this.grpContent.Controls.Add(this.txtContent);
            this.grpContent.Controls.Add(this.chkBold);
            this.grpContent.Controls.Add(this.chkLarge);
            this.grpContent.Controls.Add(this.rbAlignLeft);
            this.grpContent.Controls.Add(this.rbAlignCenter);
            this.grpContent.Controls.Add(this.rbAlignRight);
            this.grpContent.Controls.Add(this.lblBarcode);
            this.grpContent.Controls.Add(this.txtBarcode);
            this.grpContent.Controls.Add(this.cmbBarcodeType);
            this.grpContent.Controls.Add(this.btnPrintText);
            this.grpContent.Controls.Add(this.btnPrintBarcode);
            this.grpContent.Controls.Add(this.btnPrintBoth);
            this.grpContent.Controls.Add(this.btnCutPaper);

            this.Controls.Add(this.grpPrinterSettings);
            this.Controls.Add(this.grpContent);
            this.Controls.Add(this.statusStrip);
        }

        #endregion
    }
}