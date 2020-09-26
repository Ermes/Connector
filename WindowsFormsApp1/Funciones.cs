using F4SharedMem.Headers;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ErmesConn
{
    public partial class Form1
    {
        void CheckPorts() // scans  available COM ports
        {
            var AvailablePorts = SerialPort.GetPortNames(); // put available ports into variable
            var AvailablePortsFF = SerialPort.GetPortNames();
            cbCOM.DataSource = AvailablePorts; 
            cbCOMff.DataSource = AvailablePortsFF;
        }

        public bool SerialInit(SerialPort arduino, string instrumento)
        /*
        * This functions handles opening and closing of serial connections
        */
        {
            string puerto = "";
            switch (instrumento)
            {
                case "icp":
                    puerto = cbCOM.SelectedValue.ToString();
                    break;
                case "fuel":
                    puerto = cbCOMff.SelectedValue.ToString();
                    break;
                default:
                    tsStrip.Text = "No Device Selected";
                    tsStrip.BackColor = Color.Orange;
                    return false;

            }


            if (arduino.IsOpen) //if serial connection is active
            {
                #region SerialDisconnectLogic
                try
                {
                    isClosing = true; // set "closing flag"
                    Thread.Sleep(200); // wait for all interrupts for finish processing
                    sendLine(arduino, "S", 1);  // envia un Stop
                    arduino.Close(); // close the connection
                    return true;
                }
                catch (InvalidCastException e) // if excetion occurs
                {
                    return false;
                }
                #endregion
            }
            else // abre el puerto y se queda escuchando el handler
            {
                abrePuerto(arduino, puerto);
                return true;
            }
        }

        void abrePuerto(SerialPort arduino, string puerto)
        {
            #region SerialConnectLogic
            try
            { 
                // predeterminado .Stopbit 1, Parity None, Databits 8
                arduino.PortName = puerto;
                arduino.RtsEnable = true; // set RTS flag
                arduino.Handshake = Handshake.None; // Disable handshake ... predeterminado None
                arduino.BaudRate = 57600;
                arduino.DataReceived += new SerialDataReceivedEventHandler(arduino_DataReceived); // Setup serial interrup rutine - that is what will actually do the work
                isClosing = false; // set closing flag to off
                arduino.Open(); // Open Serial connection
                return ;
            }
            catch (InvalidCastException e) //if try fails.
            {
                return ;
            }
            #endregion
        }

        void arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)     
        {
            PowerOn = true; // lo pongo para falsear el estado de Falcon para pruebas

            SerialPort arduino = (SerialPort)sender;
            
            if (!isClosing & PowerOn)// if we are not in a closing state to your thing
            {        
                byte[] s = new byte[1];
                arduino.Read(s,0,1);
                char mode = (char)s[0]; // define "mode" variable
                Debug.Print(mode.ToString());
                // FalconUpdate();
                              
                switch (mode) // Get the party started.
                {
                #region DoWork
                    case 'R': // Recive RDY call from arduino
                        arduino.DiscardInBuffer();
                        arduino.Write('G'.ToString());
                        sendBytes(arduino, blankByte, 1);
                        arduino.DiscardOutBuffer();
                        // Debug.Print("Envio G ");
                        break; // exit the interrupt 
                        
                    case 'M':
                        #region Misc
                        blankByte[0] = (byte)0;
                        arduino.Write('M'.ToString());
                        sendBytes(arduino, MakeMisc(), 1);
                        break;
                        #endregion

                    case 'F':
                        #region FuelFlow
                        arduino.Write('F'.ToString());
                        int ff = (int)BMSdata.fuelFlow / 100 * 100;
                        if (ff/10000 < 1)
                        {
                            arduino.Write("0");
                        }
                        if (ff / 1000 < 1)
                        {
                            arduino.Write("0");
                        }
                        
                        arduino.Write(ff.ToString());
                        break;
                         #endregion

                    case 'P':
                        #region Pulsacion
                        //blankByte[0] = (byte)0;
                        byte[] pulsacion = new byte[2];
                        arduino.Read(pulsacion,0,2);
                        Pulsacion(pulsacion[0]);
                        break;
                        #endregion
                }
                #endregion                
            }                       
        }

        public void Pulsacion(uint pulsaciones)
        {
            uint alt_rel = 0b_01000000;
            uint resultado = pulsaciones & alt_rel;
            if ( resultado > 0 )
            {
                if(ActivateApp("notepad"))
                    SendKeys.SendWait(pulsaciones.ToString());
            }
            
        }

        public void FalconUpdate()
        /*
         * Update sharedmem
         */
        {
            if (BMSreader.IsFalconRunning) //if falcon is running
            {
                PowerOn = true;
                BMSdata = BMSreader.GetCurrentData(); // get the current shared mem
            } else
            {
                PowerOn = false;
            }
        }

        private byte[] MakeMisc()
        {
            BitArray mapping = new BitArray(8, false);
            mapping[0] = CheckLight(LightBits2.EcmPwr); // //RefuelDSC
            mapping[1] = CheckLight(LightBits2.TFR_ENGAGED); //RefuelAR
            mapping[2] = CheckLight(LightBits.TFR_STBY); //RefuelRDY

            byte[] result = new byte[1];
            mapping.CopyTo(result, 0);
            return result;
        }

        private void sendBytes(SerialPort arduino, byte[] sendThis, int length)
        {
            arduino.Write(sendThis, 0, length);
        }

        private void sendLine(SerialPort arduino, string sendThis, int length)
        {
            if (sendThis.Length < length)           
                length = sendThis.Length;
            
            byte[] sendBytes = Encoding.GetEncoding(1252).GetBytes(sendThis);
            arduino.Write(sendBytes, 0, length);
        }

        private bool CheckLight(F4SharedMem.Headers.LightBits datamask)
        {
            return (BMSdata.lightBits & (Int32)datamask) == (Int32)datamask ? true : false;
        }
        private bool CheckLight(F4SharedMem.Headers.LightBits2 datamask)
        {
            return (BMSdata.lightBits2 & (Int32)datamask) == (Int32)datamask ? true : false;

        }


        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        private bool ActivateApp(string processName)
        {
            Process[] todos = Process.GetProcesses();
            Process[] p = Process.GetProcessesByName(processName);
            bool encontrado = false;
            // Activate the first application we find with this name
            if (p.Count() > 0)
            {
                SetForegroundWindow(p[0].MainWindowHandle);
                encontrado = true;
            } else
            {
                encontrado = false;
            }
            return encontrado;   
        }
    }
}