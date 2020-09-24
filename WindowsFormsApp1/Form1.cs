using System;
using System.Windows.Forms;
using System.IO.Ports;
using F4SharedMem;
using System.Drawing;
using System.Linq;
using F4SharedMem.Headers;

namespace ErmesConn
{
    public partial class Form1 : Form
    {
        public F4SharedMem.Reader BMSreader = new F4SharedMem.Reader();
        public FlightData BMSdata = new FlightData();

        public SerialPort micro = new SerialPort();
        public SerialPort nano = new SerialPort();

        const int BAUDRATE = 9600;
        const short BAUDRATE_MULTIPLIER = 12;
        public bool isClosing = false;
        public byte[] blankByte = new byte[1];
        public char SerialBuffer;
        public bool PowerOn;

        public Form1()
        {
            InitializeComponent();
            CheckPorts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
          EscribeTStrip(tsStrip, " - ", SystemColors.Control);
          EscribeTStrip(tsStrip2, " - ", SystemColors.Control);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            tsBMS.Text = BMSreader.IsFalconRunning ? "BMS Running" : "BMS Stopped";
            {
                if (micro.IsOpen) 
                {
                    #region DisconnectSerial
                    if (SerialInit(micro,"icp")) 
                    {
                        EscribeTStrip(tsStrip, "Ready", SystemColors.Control);  
                        btnStart.Text = "Start";
                        cbCOM.Enabled = true;                       
                    }
                    else 
                    {
                        EscribeTStrip(tsStrip, "Error", Color.Red);
                    }
                    #endregion
                }
                else if (cbCOM.SelectedValue != null) //if no serial connection is open and the is a COM device selected 
                {
                    if (!micro.IsOpen && SerialPort.GetPortNames().Contains(cbCOM.SelectedValue))
                    {
                        #region ConnectSerial
                        if (SerialInit(micro, "icp")) 
                        { 
                            EscribeTStrip(tsStrip, "Conectado", Color.Green);
                            btnStart.Text = "Stop";
                            cbCOM.Enabled = false;
                        }
                        else
                        { 
                            EscribeTStrip(tsStrip, "Error", Color.Red);
                        }
                        #endregion
                    }
                    else
                    {
                        EscribeTStrip(tsStrip, "Selected COM port not valid", Color.Yellow);
                    }
                }
                else if (cbCOM.SelectedValue == null) 
                {
                    EscribeTStrip(tsStrip, "No Arduino Micro", Color.Yellow);
                }
            }

        }

        private void btnStartFF_Click(object sender, EventArgs e)
        {
            {
                if (nano.IsOpen) //if serial connection is open - close it.
                {
                    #region DisconnectSerial
                    if (SerialInit(nano, "fuel"))
                    {
                        EscribeTStrip(tsStrip2, "Ready Fuel", SystemColors.Control);
                        btnStartFF.Text = "Start";
                        cbCOMff.Enabled = true;
                    }
                    else // if hangup failed
                    {
                        EscribeTStrip(tsStrip2, "Error", Color.Red);
                    }
                    #endregion
                }
                else if (cbCOMff.SelectedValue != null) //if no serial connection is open and the is a COM device selected 
                {
                    if (!nano.IsOpen && SerialPort.GetPortNames().Contains(cbCOMff.SelectedValue))
                    {
                        #region ConnectSerial
                        if (SerialInit(nano, "fuel")) //issue Connect command
                        { //if connection succeded - change button to allow disconnect

                            EscribeTStrip(tsStrip2, "Conectado Fuel", Color.Green);
                            btnStartFF.Text = "Stop";
                            cbCOMff.Enabled = false;
                        }
                        else
                        { //if connection failed
                            EscribeTStrip(tsStrip2, "Error", Color.Red);
                        }
                        #endregion
                    }
                    else
                    {
                        EscribeTStrip(tsStrip2, "Selected COM port not valid", Color.Yellow);
                    }
                }
                else if (cbCOMff.SelectedValue == null) // if no serial connection is selected
                {
                    EscribeTStrip(tsStrip2, "No Arduino Nano", Color.Yellow);
                }
            }
            

        }

        private void EscribeTStrip(ToolStripStatusLabel ts, string mensaje, Color color)
        {
            ts.BackColor = color;
            ts.Text = mensaje;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckPorts();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tsBMS.Text = BMSreader.IsFalconRunning ? "BMS Running" : "BMS Stopped";
            txtStatus.Text = BMSdata.fuelFlow.ToString();
            FalconUpdate();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
