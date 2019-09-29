using System.IO.Ports;

namespace Yalit.Pos
{
    static class Extensions
    {
        public static void EnsureIsOpen(this SerialPort port)
        {
            if (!port.IsOpen)
            {
                port.Open();
            }
        }

        public static void Clear(this SerialPort port)
        {
            if (!port.IsOpen)
            {
                port.Open();
            }
            var command = VfdCommand.ClearScreen();
            port.Write(command.Command, 0, command.Lenght);
            port.Close();
        }

        public static void Write(this SerialPort port, VfdCommand command)
        {
            port.EnsureIsOpen();
            port.Write(command.Command, 0, command.Lenght);
            port.Close();
        }
    }
}
