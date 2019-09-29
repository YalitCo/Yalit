
namespace Yalit.Pos
{
    /// <summary>
    /// Class VfdCommand.
    /// </summary>
    public class VfdCommand
    {
        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>The command.</value>
        public byte[] Command { get; private set; }

        /// <summary>
        /// Gets the lenght.
        /// </summary>
        /// <value>The lenght.</value>
        public int Lenght
        {
            get
            {
                return Command.Length;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VfdCommand"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        public VfdCommand(params byte[] command)
        {
            Command = command;
        }


        /// <summary>
        /// Clears the screen.
        /// </summary>
        /// <returns>VfdCommand.</returns>
        public static VfdCommand ClearScreen()
        {
            return new VfdCommand(12);
        }

        /// <summary>
        /// Moves the cursor left.
        /// </summary>
        /// <returns>Yalit.Pos.VfdCommand.</returns>
        public static VfdCommand MoveCursorLeft()
        {
            return new VfdCommand(8);
        }

        /// <summary>
        /// Initizes the display.
        /// </summary>
        /// <returns>VfdCommand.</returns>
        public static VfdCommand InitizeDisplay()
        {
            return new VfdCommand(27, 26);
        }

        /// <summary>
        /// Verticals the scroll mode.
        /// </summary>
        /// <returns>VfdCommand.</returns>
        public static VfdCommand VerticalScrollMode()
        {
            return new VfdCommand(31, 2);
        }

        /// <summary>
        /// Horizontals the scroll mode.
        /// </summary>
        /// <returns>Yalit.Pos.VfdCommand.</returns>
        public static VfdCommand HorizontalScrollMode()
        {
            return new VfdCommand(31, 3);
        }

        /// <summary>
        /// Displays the time counter.
        /// </summary>
        /// <returns>VfdCommand.</returns>
        public static VfdCommand DisplayTimeCounter()
        {
            return new VfdCommand(31, 85);
        }

        /// <summary>
        /// adjustment the Brightnesses.
        /// </summary>
        /// <param name="level">The level of brightness from 1 to 4 </param>
        /// <returns>Yalit.Pos.VfdCommand.</returns>
        public static VfdCommand BrightnessAdjustment(byte level)
        {
            return new VfdCommand(new byte[] { 31, 88, level });
        }

        /// <summary>
        /// Tests this instance.
        /// </summary>
        /// <returns>VfdCommand.</returns>
        public static VfdCommand Test()
        {
            return new VfdCommand(31, 64);
        }








    }
}
