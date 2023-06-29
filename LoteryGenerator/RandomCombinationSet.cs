namespace LoteryGenerator
{
    public class RandomCombinationSet
    {
        private readonly int _of;
        private readonly int _from;
        internal readonly SortedDictionary<string, Combination> Combinations;

        public RandomCombinationSet(int of, int from)
        {
            _of = of;
            _from = from;
            Combinations = new();
        }

        public IEnumerable<Combination> Generate(int amount)
        {
            ISet<int> priority = new HashSet<int>();
            for (int i = 0; i < amount; i++)
            {
                var set = new RandomCombination(_of, _from).With(priority).Generate();
                if (Combinations.ContainsKey(set.Key)) continue;
                Combinations.Add(set.Key, set);
                set.Share(out priority);
            }
            return Combinations.Values;
        }
    }
}
