using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.LIB.Utils.ProgressTracking
{
    public class ProgressTracker<TItem> : IEnumerable<TItem>
    {
        private readonly int _totalAmount;
        
        private TItem _current;

        private int _currentIndex = 0;

        private readonly IEnumerator<TItem> _source;

        public event ProgressMadeDelegate<TItem> ProgressMadeEvent;

        public ProgressTracker(IEnumerable<TItem> source)
        {
            _source = source.GetEnumerator();
            _totalAmount = source.Count();
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            try
            {
                while (_source.MoveNext())
                {
                    ++_currentIndex;
                    _current = _source.Current;
                    ProgressMadeEvent?.Invoke(new ProgressInfo<TItem>()
                    {
                        CurrentIndex = _currentIndex,
                        TotalAmount = _totalAmount,
                        CurrentItem = _current
                    });
                    yield return _current;
                }
            }
            finally
            {
                _source.Dispose();
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
