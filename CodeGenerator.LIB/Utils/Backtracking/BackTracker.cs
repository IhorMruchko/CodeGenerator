using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.LIB.Utils.Backtracking
{
    public class BackTracker
    {
        private readonly Stack<ICancelable> _doneActions = new Stack<ICancelable>();

        private readonly Stack<ICancelable> _undoneActions = new Stack<ICancelable>();

        private readonly BackgroundWorker _worker;

        public BackTracker()
        {
            _worker = BackgroundWorker.Worker;
        }

        public bool ChangesMade => _doneActions.Any();

        public BackTracker Push(ICancelable action)
        {
            _doneActions.Push(action);
            _undoneActions.Clear();
            return this;
        }

        public void Undo(bool useAnotherThread=false)
        {
            if (_doneActions.Any() == false)
                return;
            
            var done = _doneActions.Pop();
            
            if (useAnotherThread)
                _worker.AddTask(done.Undo);
            else
                done.Undo();
            
            _undoneActions.Push(done);
        }

        public void Redo(bool useAnotherThreada=false)
        {
            if (_undoneActions.Any() == false)
                return;
         
            var undone = _undoneActions.Pop();
            
            if (useAnotherThreada)
                _worker.AddTask(undone.Redo);
            else
                undone.Redo();
            
            _doneActions.Push(undone);
        }
    }
}
