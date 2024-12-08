namespace TaskSchedulerApp.CommandVisuals
{
    /// <summary>
    /// Represents a visual component for a command in the task scheduler.
    /// Classes implementing this interface should provide the ability to get the associated task command.
    /// </summary>
    public interface ICommandVisual
    {
        /// <summary>
        /// Gets the associated task command from the visual component.
        /// </summary>
        /// <returns>The task command that the visual component represents.</returns>
        ITaskCommand GetCommand();
    }
}
