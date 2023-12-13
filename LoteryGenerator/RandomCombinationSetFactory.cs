namespace LoteryGenerator
{
    public class RandomCombinationSetFactory(int of, int from)
    {
        private readonly int _of = of;
        private readonly int _from = from;

        public IEnumerable<Combination> Generate(int amount)
        {
            var combinations = new SortedDictionary<string, Combination>();
            ISet<int> priority = new HashSet<int>();

            for (var i = 0; i < amount; i++)
            {
                var set = new RandomCombination(_of, _from)
                    .With(priority)
                    .Generate();

                if (combinations.ContainsKey(set.Key))
                    continue;
                combinations.Add(set.Key, set);

                set.Share(out priority);
            }

            return combinations.Values;
        }
    }
}
