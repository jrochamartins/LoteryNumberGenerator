namespace LoteryGenerator
{
    public class RandomCombination : Combination
    {
        private static readonly Random _rand = new();

        private readonly HashSet<int> _prioritySet = new();

        public RandomCombination(int of, int from, ISet<int>? prioritySet = null)
        {
            if (from < of)
                throw new ArgumentException("Number of possible numbers cannot be less than the number of items in the combination");

            if (prioritySet?.Any() ?? false)
                _prioritySet.UnionWith(prioritySet);

            HashSet<int> fromSet = new();
            for (int i = 0; i < of; i++)
            {
                if (!fromSet.Any())
                    fromSet.UnionWith(Enumerable.Range(1, from));

                if (!_prioritySet.Any())
                    _prioritySet.UnionWith(fromSet);

                var index = _rand.Next(_prioritySet.Count);
                var value = _prioritySet.ElementAt(index);
                Add(value);

                _prioritySet.Remove(value);
                fromSet.Remove(value);
            }
        }

        internal void Share(out ISet<int> prioritySet) => prioritySet = _prioritySet;
    }
}
