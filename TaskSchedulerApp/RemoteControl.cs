namespace TaskSchedulerApp
{
    public class RemoteControl
    {
        private static RemoteControl? singleton;
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

        private ITaskCommand? command;

        public void setCommand(ITaskCommand command)
        {
            this.command = command;
        }

        public async Task pressButton()
        {
            if (command == null)
            {
                throw new InvalidOperationException("Command not set");
            }
            await command.ExecuteAsync();
        }
    }
}
