namespace Loteria.Gen
{
    public class Generator
    {
        private List<int> _priorities = new();

        public int From => _from;
        private readonly int _from = 0;

        public List<int[]> Combinations => _combinations;
        private readonly List<int[]> _combinations = new();

        public Generator(int from) => _from = from;

        public void Generate(int combinations, int of)
        {
            for (int i = 0; i < combinations; i++)
                Generate(of);
        }

        private void Generate(int of)
        {
            var priorities = new List<int>(_priorities);
            List<int>? possibilites = null;

            var combination = new int[of];
            Random rand = new();

            for (int i = 0; i < combination.Length; i++)
            {
                if (!(possibilites?.Any() ?? false))
                    possibilites = new List<int>(Possibilities(_from));
                if (!priorities.Any())
                    priorities = possibilites;

                var choise = priorities[rand.Next(priorities.Count)];
                combination[i] = choise;

                priorities.Remove(combination[i]);
                possibilites.Remove(combination[i]);
            }

            if (Contains(combination))
                return;

            _priorities = priorities;
            _combinations.Add(combination);
        }

        private static IEnumerable<int> Possibilities(int n)
        {
            for (int i = 1; i <= n; i++)
                yield return i;
        }

        private bool Contains(int[] combination)
        {
            Array.Sort(combination);
            foreach (var i in _combinations)
                if (Enumerable.SequenceEqual(i, combination))
                    return true;
            return false;
        }
    }
}
