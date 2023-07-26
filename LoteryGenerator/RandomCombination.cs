namespace LoteryGenerator
{
    public class RandomCombination : Combination
    {
        private static readonly Random Rand = new();

        private readonly int _of;
        private readonly int _from;
        private readonly ISet<int> _priority;

        public RandomCombination(int of, int from)
        {
            if (from < of)
                throw new ArgumentException("Number of possible numbers cannot be less than the number of items in the combination");

            _of = of;
            _from = from;
            _priority = new HashSet<int>();
        }

        public RandomCombination With(ISet<int> priority)
        {
            if (priority == null) 
                throw new ArgumentNullException(nameof(priority));

            if (priority.Any())
                _priority.UnionWith(priority);

            return this;
        }

        public RandomCombination Generate()
        {
            HashSet<int> fromSet = new();
            for (var i = 0; i < _of; i++)
            {
                if (!fromSet.Any())
                    fromSet.UnionWith(Enumerable.Range(1, _from));

                if (!_priority.Any())
                    _priority.UnionWith(fromSet);

                var index = Rand.Next(_priority.Count);
                var value = _priority.ElementAt(index);
                Add(value);

                _priority.Remove(value);
                fromSet.Remove(value);
            }
            return this;
        }

        internal void Share(out ISet<int> priority) => priority = _priority;
    }
}
