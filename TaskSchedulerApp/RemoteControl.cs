namespace TaskSchedulerApp
{
    /// <summary>
    /// The RemoteControl class implements the Singleton pattern.
    /// It is used to execute a command (ITaskCommand) when the button is pressed.
    /// </summary>
    public class RemoteControl
    {
        /// <summary>
        /// The static singleton instance of the RemoteControl class.
        /// Ensures only one instance of RemoteControl is used across the application.
        /// </summary>
        private static RemoteControl? singleton;

        /// <summary>
        /// Property to get the singleton instance of RemoteControl.
        /// If the instance doesn't exist, it will be created.
        /// </summary>
        public static RemoteControl Singleton
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new RemoteControl();
                }
                return singleton;
            }
        }

        /// <summary>
        /// The command that will be executed when the button is pressed.
        /// It implements the ITaskCommand interface.
        /// </summary>
        private ITaskCommand? command;

        /// <summary>
        /// Sets the command that will be executed by the remote control.
        /// </summary>
        /// <param name="command">The command to be executed.</param>
        public void setCommand(ITaskCommand command)
        {
            this.command = command;
        }

        /// <summary>
        /// Presses the button and executes the set command asynchronously.
        /// If no command is set, an InvalidOperationException is thrown.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown if no command is set when pressing the button.</exception>
        public async Task pressButton()
        {
            if (command == null)
            {
                throw new InvalidOperationException("Command not set");
            }
            // Check if a command has been set
            await command.ExecuteAsync();
        }
    }
}
