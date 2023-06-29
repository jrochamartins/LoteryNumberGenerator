namespace LoteryGenerator
{
    public static class RandomCombinationSetGenerator
    {
        public static IEnumerable<Combination> Generate(int amount, int of, int from)
        {
            ISet<int> prioritySet = new HashSet<int>();
            var combinations = new SortedDictionary<string, Combination>();

            for (int i = 0; i < amount; i++)
            {
                var combination = new RandomCombination(of, from, prioritySet);
                if (combinations.ContainsKey(combination.Key)) continue;
                combinations.Add(combination.Key, combination);
                combination.Share(out prioritySet);
            }

            return combinations.Values;
        }
    }
}
