using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace CodeGenerator.LIB.Utils
{
    public class BackgroundWorker
    {
        private readonly BlockingCollection<Task> _tasksQueue = new();

        private readonly Thread _mainThread;

        private static BackgroundWorker? _instance;

        private static readonly object _lock = new();

        private BackgroundWorker() 
        {
            _mainThread = new Thread(StartExecution)
            {
                IsBackground = true,
            };
            _mainThread.Start();
        }

        public static BackgroundWorker Worker
        {
            get
            {
                if (_instance is null)
                {
                    lock(_lock)
                    {
                        _instance ??= new BackgroundWorker();
                    }
                }
                return _instance;
            }
        }

        public BackgroundWorker AddTask(Task task)
        {
            _tasksQueue.Add(task);
            return this;
        }

        public BackgroundWorker AddTask(Action task)
        {
            _tasksQueue.Add(new Task(task));
            return this;
        }

        public void Stop() => AddTask(() => _mainThread.Join());

        private void StartExecution()
        {
            while (true)
                _tasksQueue.Take().Start();
        }
    }
}
