using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace ThermalPrinterApp
{
    public partial class MainForm : Form
    {
        // ESC/POS Commands
        private static readonly byte[] ESC_INIT = { 0x1B, 0x40 }; // Initialize printer
        private static readonly byte[] ESC_ALIGN_LEFT = { 0x1B, 0x61, 0x00 }; // Align left
        private static readonly byte[] ESC_ALIGN_CENTER = { 0x1B, 0x61, 0x01 }; // Align center
        private static readonly byte[] ESC_ALIGN_RIGHT = { 0x1B, 0x61, 0x02 }; // Align right
        private static readonly byte[] ESC_FONT_NORMAL = { 0x1B, 0x21, 0x00 }; // Normal font
        private static readonly byte[] ESC_FONT_BOLD = { 0x1B, 0x21, 0x08 }; // Bold font
        private static readonly byte[] ESC_FONT_LARGE = { 0x1B, 0x21, 0x30 }; // Large font
        private static readonly byte[] ESC_CUT_PAPER = { 0x1D, 0x56, 0x41 }; // Cut paper (full cut)
        private static readonly byte[] ESC_LINE_FEED = { 0x0A }; // Line feed
        private static readonly byte[] ESC_BARCODE_MODE = { 0x1D, 0x6B }; // Barcode mode
        private static readonly byte[] ESC_QRCODE_SELECT_MODEL = { 0x1D, 0x28, 0x6B, 0x04, 0x00, 0x31, 0x41, 0x32, 0x00 }; // Select QR model
        private static readonly byte[] ESC_QRCODE_SET_SIZE = { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x43, 0x05 }; // Set QR size (1-16)

        // Printer connection properties
        private string printerName = "";
        private bool isUSBConnection = true;
        private string comPort = "COM1";

        // Set printing properties
        private int paperWidth = 384; // 8 dots/mm * 48 mm = 384 dots
        private bool isBluetoothEnabled = false;

        public MainForm()
        {
            InitializeComponent();
            LoadPrinters();
        }

        private void LoadPrinters()
        {
            cmbPrinters.Items.Clear();
            foreach (var printer in PrinterSettings.InstalledPrinters)
            {
                cmbPrinters.Items.Add(printer.ToString());
            }

            if (cmbPrinters.Items.Count > 0)
            {
                cmbPrinters.SelectedIndex = 0;
                printerName = cmbPrinters.SelectedItem.ToString();
            }

            // Load COM ports
            cmbCOMPorts.Items.Clear();
            foreach (string port in SerialPort.GetPortNames())
            {
                cmbCOMPorts.Items.Add(port);
            }

            if (cmbCOMPorts.Items.Count > 0)
            {
                cmbCOMPorts.SelectedIndex = 0;
                comPort = cmbCOMPorts.SelectedItem.ToString();
            }

            statusLabel.Text = "Printers loaded.";
        }

        private void RbUSB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUSB.Checked)
            {
                isUSBConnection = true;
                isBluetoothEnabled = false;
                cmbCOMPorts.Enabled = false;
            }
        }

        private void RbBluetooth_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBluetooth.Checked)
            {
                isUSBConnection = false;
                isBluetoothEnabled = true;
                cmbCOMPorts.Enabled = false;
            }
        }

        private void RbCOM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCOM.Checked)
            {
                isUSBConnection = false;
                isBluetoothEnabled = false;
                cmbCOMPorts.Enabled = true;
                if (cmbCOMPorts.Items.Count > 0)
                {
                    comPort = cmbCOMPorts.SelectedItem.ToString();
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadPrinters();
        }

        private void BtnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (isUSBConnection)
                {
                    // Test USB printer connection
                    if (cmbPrinters.SelectedItem == null)
                    {
                        statusLabel.Text = "No printer selected.";
                        return;
                    }

                    printerName = cmbPrinters.SelectedItem.ToString();
                    PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings.PrinterName = printerName;

                    if (pd.PrinterSettings.IsValid)
                    {
                        statusLabel.Text = $"Connected to {printerName} successfully.";
                    }
                    else
                    {
                        statusLabel.Text = $"Printer {printerName} is not valid.";
                    }
                }
                else if (isBluetoothEnabled)
                {
                    // Test Bluetooth connection
                    // For Bluetooth, we would need a more complex implementation
                    // This is a simplified version
                    statusLabel.Text = "Bluetooth connection test is not implemented yet.";
                }
                else
                {
                    // Test COM port connection
                    using (SerialPort port = new SerialPort(comPort, 9600, Parity.None, 8, StopBits.One))
                    {
                        port.Open();
                        statusLabel.Text = $"Connected to {comPort} successfully.";
                        port.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Connection test failed: {ex.Message}";
            }
        }

        private void BtnPrintText_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContent.Text))
            {
                statusLabel.Text = "No text to print.";
                return;
            }

            PrintText(txtContent.Text);
        }

        private void BtnPrintBarcode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                statusLabel.Text = "No barcode/QR content to print.";
                return;
            }

            PrintBarcode(txtBarcode.Text, cmbBarcodeType.SelectedItem.ToString());
        }

        private void BtnPrintBoth_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContent.Text) && string.IsNullOrEmpty(txtBarcode.Text))
            {
                statusLabel.Text = "No content to print.";
                return;
            }

            if (!string.IsNullOrEmpty(txtContent.Text))
            {
                PrintText(txtContent.Text);
            }

            if (!string.IsNullOrEmpty(txtBarcode.Text))
            {
                PrintBarcode(txtBarcode.Text, cmbBarcodeType.SelectedItem.ToString());
            }
        }

        private void BtnCutPaper_Click(object sender, EventArgs e)
        {
            CutPaper();
        }

        private void PrintText(string text)
        {
            try
            {
                MemoryStream ms = new MemoryStream();

                // Initialize printer
                ms.Write(ESC_INIT, 0, ESC_INIT.Length);

                // Set alignment
                if (rbAlignLeft.Checked)
                {
                    ms.Write(ESC_ALIGN_LEFT, 0, ESC_ALIGN_LEFT.Length);
                }
                else if (rbAlignCenter.Checked)
                {
                    ms.Write(ESC_ALIGN_CENTER, 0, ESC_ALIGN_CENTER.Length);
                }
                else if (rbAlignRight.Checked)
                {
                    ms.Write(ESC_ALIGN_RIGHT, 0, ESC_ALIGN_RIGHT.Length);
                }

                // Set font style
                if (chkBold.Checked && chkLarge.Checked)
                {
                    byte[] fontStyle = { 0x1B, 0x21, 0x38 }; // Bold + Large
                    ms.Write(fontStyle, 0, fontStyle.Length);
                }
                else if (chkBold.Checked)
                {
                    ms.Write(ESC_FONT_BOLD, 0, ESC_FONT_BOLD.Length);
                }
                else if (chkLarge.Checked)
                {
                    ms.Write(ESC_FONT_LARGE, 0, ESC_FONT_LARGE.Length);
                }
                else
                {
                    ms.Write(ESC_FONT_NORMAL, 0, ESC_FONT_NORMAL.Length);
                }

                // Write text
                byte[] textBytes = Encoding.GetEncoding(850).GetBytes(text);
                ms.Write(textBytes, 0, textBytes.Length);

                // Line feed
                ms.Write(ESC_LINE_FEED, 0, ESC_LINE_FEED.Length);
                ms.Write(ESC_LINE_FEED, 0, ESC_LINE_FEED.Length);

                // Reset font
                ms.Write(ESC_FONT_NORMAL, 0, ESC_FONT_NORMAL.Length);

                // Send to printer
                SendToPrinter(ms.ToArray());
                statusLabel.Text = "Text printed successfully.";
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Error printing text: {ex.Message}";
            }
        }

        private void PrintBarcode(string content, string barcodeType)
        {
            try
            {
                MemoryStream ms = new MemoryStream();

                // Initialize printer
                ms.Write(ESC_INIT, 0, ESC_INIT.Length);

                // Center alignment for barcode
                ms.Write(ESC_ALIGN_CENTER, 0, ESC_ALIGN_CENTER.Length);

                // Add a line feed
                ms.Write(ESC_LINE_FEED, 0, ESC_LINE_FEED.Length);

                // Print barcode based on type
                if (barcodeType == "QR Code")
                {
                    PrintQRCode(ms, content);
                }
                else if (barcodeType == "CODE 39")
                {
                    PrintCode39(ms, content);
                }
                else if (barcodeType == "CODE 128")
                {
                    PrintCode128(ms, content);
                }
                else if (barcodeType == "EAN-13")
                {
                    PrintEAN13(ms, content);
                }
                else if (barcodeType == "UPC-A")
                {
                    PrintUPCA(ms, content);
                }

                // Line feed after barcode
                ms.Write(ESC_LINE_FEED, 0, ESC_LINE_FEED.Length);
                ms.Write(ESC_LINE_FEED, 0, ESC_LINE_FEED.Length);

                // Reset alignment
                ms.Write(ESC_ALIGN_LEFT, 0, ESC_ALIGN_LEFT.Length);

                // Send to printer
                SendToPrinter(ms.ToArray());
                statusLabel.Text = $"{barcodeType} printed successfully.";
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Error printing barcode: {ex.Message}";
            }
        }

        private void PrintQRCode(MemoryStream ms, string content)
        {
            // This is a simplified implementation of QR Code printing
            // ESC/POS has specific commands for QR Codes, but implementation varies by printer model

            // Select QR code model
            ms.Write(ESC_QRCODE_SELECT_MODEL, 0, ESC_QRCODE_SELECT_MODEL.Length);

            // Set QR code size
            ms.Write(ESC_QRCODE_SET_SIZE, 0, ESC_QRCODE_SET_SIZE.Length);

            // Store QR code data
            byte[] qrHeader = { 0x1D, 0x28, 0x6B };
            byte[] qrData = Encoding.ASCII.GetBytes(content);
            byte[] qrStoreHeader = new byte[] {
                0x1D, 0x28, 0x6B, (byte)(qrData.Length + 3), 0x00, 0x31, 0x50, 0x30
            };
            ms.Write(qrStoreHeader, 0, qrStoreHeader.Length);
            ms.Write(qrData, 0, qrData.Length);

            // Print QR code
            byte[] qrPrint = { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x51, 0x30 };
            ms.Write(qrPrint, 0, qrPrint.Length);
        }

        private void PrintCode39(MemoryStream ms, string content)
        {
            // Code 39 setup - height
            byte[] barcodeHeight = { 0x1D, 0x68, 0x50 }; // Set height to 80 dots
            ms.Write(barcodeHeight, 0, barcodeHeight.Length);

            // Code 39 print
            ms.Write(ESC_BARCODE_MODE, 0, ESC_BARCODE_MODE.Length);
            ms.Write(new byte[] { 0x04 }, 0, 1); // Type CODE39
            byte[] barcodeData = Encoding.ASCII.GetBytes(content);
            ms.Write(barcodeData, 0, barcodeData.Length);
            ms.Write(new byte[] { 0x00 }, 0, 1); // NUL terminator
        }

        private void PrintCode128(MemoryStream ms, string content)
        {
            // Code 128 setup - height
            byte[] barcodeHeight = { 0x1D, 0x68, 0x50 }; // Set height to 80 dots
            ms.Write(barcodeHeight, 0, barcodeHeight.Length);

            // Code 128 print
            ms.Write(ESC_BARCODE_MODE, 0, ESC_BARCODE_MODE.Length);
            ms.Write(new byte[] { 0x49 }, 0, 1); // Type CODE128
            byte[] barcodeData = Encoding.ASCII.GetBytes(content);
            ms.Write(barcodeData, 0, barcodeData.Length);
            ms.Write(new byte[] { 0x00 }, 0, 1); // NUL terminator
        }

        private void PrintEAN13(MemoryStream ms, string content)
        {
            // EAN-13 must be exactly 12 digits (13th is checksum)
            if (content.Length != 12 || !long.TryParse(content, out _))
            {
                throw new ArgumentException("EAN-13 requires exactly 12 numeric digits.");
            }

            // EAN-13 setup - height
            byte[] barcodeHeight = { 0x1D, 0x68, 0x50 }; // Set height to 80 dots
            ms.Write(barcodeHeight, 0, barcodeHeight.Length);

            // EAN-13 print
            ms.Write(ESC_BARCODE_MODE, 0, ESC_BARCODE_MODE.Length);
            ms.Write(new byte[] { 0x43 }, 0, 1); // Type EAN13
            byte[] barcodeData = Encoding.ASCII.GetBytes(content);
            ms.Write(barcodeData, 0, barcodeData.Length);
        }

        private void PrintUPCA(MemoryStream ms, string content)
        {
            // UPC-A must be exactly 11 digits (12th is checksum)
            if (content.Length != 11 || !long.TryParse(content, out _))
            {
                throw new ArgumentException("UPC-A requires exactly 11 numeric digits.");
            }

            // UPC-A setup - height
            byte[] barcodeHeight = { 0x1D, 0x68, 0x50 }; // Set height to 80 dots
            ms.Write(barcodeHeight, 0, barcodeHeight.Length);

            // UPC-A print
            ms.Write(ESC_BARCODE_MODE, 0, ESC_BARCODE_MODE.Length);
            ms.Write(new byte[] { 0x41 }, 0, 1); // Type UPC-A
            byte[] barcodeData = Encoding.ASCII.GetBytes(content);
            ms.Write(barcodeData, 0, barcodeData.Length);
        }

        private void CutPaper()
        {
            try
            {
                MemoryStream ms = new MemoryStream();

                // Add line feeds before cutting
                for (int i = 0; i < 5; i++)
                {
                    ms.Write(ESC_LINE_FEED, 0, ESC_LINE_FEED.Length);
                }

                // Cut command
                ms.Write(ESC_CUT_PAPER, 0, ESC_CUT_PAPER.Length);

                // Send to printer
                SendToPrinter(ms.ToArray());
                statusLabel.Text = "Paper feed and cut command sent.";
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Error cutting paper: {ex.Message}";
            }
        }

        private void SendToPrinter(byte[] data)
        {
            if (isUSBConnection)
            {
                // Print via Windows printer driver
                if (string.IsNullOrEmpty(printerName))
                {
                    throw new InvalidOperationException("No printer selected.");
                }

                RawPrinterHelper.SendBytesToPrinter(printerName, data);
            }
            else if (isBluetoothEnabled)
            {
                // Bluetooth printing is more complex and requires additional libraries
                // This is a placeholder for Bluetooth implementation
                throw new NotImplementedException("Bluetooth printing is not implemented yet.");
            }
            else
            {
                // Print via COM port
                using (SerialPort port = new SerialPort(comPort, 9600, Parity.None, 8, StopBits.One))
                {
                    port.Open();
                    port.Write(data, 0, data.Length);
                    port.Close();
                }
            }
        }
    }
}