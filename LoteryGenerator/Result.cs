using System.Collections.Generic;

namespace LoteryGenerator
{
    public class Result
    {
        private readonly Combination _result;

        public Result(Combination result)
        {
            _result = result;
        }

        public int Hits(Combination attempt)
        {
            var set = new SortedSet<int>(attempt);
            set.IntersectWith(_result);
            return set.Count;
        }
    }
}
