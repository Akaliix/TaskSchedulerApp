namespace TaskSchedulerApp
{
    /// <summary>
    /// A class that represents a task scheduler. It allows scheduling and executing a series of tasks at a specified time.
    /// It follows the Chain of Responsibility pattern to handle and execute tasks sequentially.
    /// </summary>
    public class TaskScheduler
    {
        /// <summary>
        /// The first handler in the task handler chain.
        /// </summary>
        private TaskHandler? _firstHandler;

        /// <summary>
        /// The name of the task scheduler.
        /// </summary>
        private string _name;

        // time
        public int _hour;
        public int _minute;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskScheduler"/> class with the specified name, hour, and minute.
        /// </summary>
        /// <param name="name">The name of the task scheduler.</param>
        /// <param name="hour">The hour when the tasks should be executed.</param>
        /// <param name="minute">The minute when the tasks should be executed.</param>
        public TaskScheduler(string name, int hour, int minute)
        {
            _name = name;
            _hour = hour;
            _minute = minute;
        }

        /// <summary>
        /// Adds a task handler to the task scheduler. The handler is added to the end of the handler chain.
        /// </summary>
        /// <param name="handler">The task handler to be added.</param>
        public void AddTask(TaskHandler handler)
        {
            if (_firstHandler == null)
            {
                _firstHandler = handler;
            }
            else
            {
                // Find the last handler in the chain and append the new handler.
                var current = _firstHandler;
                while (current._nextHandler != null)
                {
                    current = current._nextHandler;
                }
                current.SetNext(handler);
            }
        }

        /// <summary>
        /// Executes all tasks in the task handler chain asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task ExecuteAllAsync()
        {
            if (_firstHandler != null)
            {
                // Start handling tasks from the first handler in the chain.
                await _firstHandler.HandleAsync();
            }
        }

        /// <summary>
        /// Returns a string representation of the task scheduler, including its name, hour, and minute.
        /// </summary>
        /// <returns>A string representing the task scheduler.</returns>
        public override string ToString()
        {
            return _name + " - " + _hour + ":" + _minute;
        }
    }
}
