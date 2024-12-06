namespace TaskSchedulerApp
{
    public class TaskScheduler
    {
        private TaskHandler? _firstHandler;

        private string _name;
        //time
        public int _hour;
        public int _minute;

        public TaskScheduler(string name, int hour, int minute)
        {
            _name = name;
            _hour = hour;
            _minute = minute;
        }

        public void AddTask(TaskHandler handler)
        {
            if (_firstHandler == null)
            {
                _firstHandler = handler;
            }
            else
            {
                var current = _firstHandler;
                while (current._nextHandler != null)
                {
                    current = current._nextHandler;
                }
                current.SetNext(handler);
            }
        }

        public async Task ExecuteAllAsync()
        {
            if (_firstHandler != null)
            {
                await _firstHandler.HandleAsync();
            }
        }

        public override string ToString()
        {
            return _name + " - " + _hour + ":" + _minute;
        }
    }
}
