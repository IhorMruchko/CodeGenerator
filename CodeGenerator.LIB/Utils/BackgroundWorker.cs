using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace CodeGenerator.LIB.Utils
{
    public class BackgroundWorker
    {
        private readonly BlockingCollection<Task> _tasksQueue = new BlockingCollection<Task>();

        private readonly Thread _mainThread;
        
        public BackgroundWorker() 
        {
            _mainThread = new Thread(StartExecution)
            {
                IsBackground = true,
            };
            _mainThread.Start();
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
