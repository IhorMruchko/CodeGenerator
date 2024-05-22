using CodeGenerator.LIB.Utils.ProgressTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.LIB.Extensions
{
    public static class IEnumeratorExtensions
    {
#if NET6_0_OR_GREATER
        public static IEnumerator<int> GetEnumerator(this Range range)
            => new ProgressTracker<int>(Enumerable.Range(range.Start.Value, range.End.Value)).GetEnumerator();
#endif
    }
}
