﻿namespace LoteryGenerator
{
    public class RandomCombination(int of, int from) : Combination
    {
        private readonly int _of = of;
        private readonly int _from = from;
        private readonly HashSet<int> _priority = [];

        public RandomCombination With(ISet<int> priority)
        {
            ArgumentNullException.ThrowIfNull(priority);

            if (priority.Any())
                _priority.UnionWith(priority);

            return this;
        }

        public RandomCombination Generate()
        {
            HashSet<int> fromSet = [];
            for (var i = 0; i < _of; i++)
            {
                if (fromSet.Count == 0)
                    fromSet.UnionWith(Enumerable.Range(1, _from));

                if (_priority.Count == 0)
                    _priority.UnionWith(fromSet);

                var index = Random.Shared.Next(_priority.Count);
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
