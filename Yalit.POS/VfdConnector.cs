using System;
using System.IO.Ports;

namespace Yalit.Pos
{
    /// <summary>
    /// A class to help you interact with VFD (Variable-frequency Drive) displays on POS-PC
    /// </summary>
    public class VfdConnector
    {
        private SerialPort _sp;

        /// <summary>
        /// Initializes a new instance of the <see cref="VfdConnector"/> class with default values on COM1 port
        /// </summary>
        private VfdConnector() : this("COM1")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VfdConnector" /> class.
        /// </summary>
        /// <param name="portName">Name of the port.</param>
        /// <param name="baudRate">The baud rate.</param>
        /// <param name="parity">The parity.</param>
        /// <param name="dataBit">The data bit.</param>
        /// <param name="stopBits">The stop bits.</param>
        public VfdConnector(string portName, int baudRate = 9600,
            Parity parity = Parity.None, int dataBit = 8,
            StopBits stopBits = StopBits.One)
        {
            _sp = new SerialPort(portName, baudRate, parity, dataBit, stopBits);
        }

        /// <summary>
        /// Gets or sets the name of the port.
        /// </summary>
        /// <value>The name of the port.</value>
        public string PortName
        {
            get
            {
                return _sp.PortName;
            }
            set
            {
                if (value == _sp.PortName)
                    return;
                _sp.PortName = value;
            }
        }

        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void WriteLine(string text)
        {
            _sp.Clear();
            _sp.EnsureIsOpen();

            _sp.WriteLine(text);

            _sp.Close();
        }

        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="line1">The line1.</param>
        /// <param name="line2">The text line2.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void WriteLine(string line1, string line2)
        {
            _sp.Clear();
            _sp.EnsureIsOpen();
            
            _sp.WriteLine(line1 + "\r\n" + line2);

            _sp.Close();
        }

        /// <summary>
        /// Displays the time counter.
        /// </summary>
        public void DisplayTimeCounter()
        {
            _sp.Write(VfdCommand.DisplayTimeCounter());
        }

        /// <summary>
        /// Brighnesses the adjustment.
        /// </summary>
        /// <param name="level">The level.</param>
        public void BrighnessAdjustment(byte level)
        {
            _sp.Write(VfdCommand.BrightnessAdjustment(level));
        }

        /// <summary>
        /// Tests this instance.
        /// </summary>
        public void Test()
        {
            _sp.Write(VfdCommand.Test());
        }
    }
}
