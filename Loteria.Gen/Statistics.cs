namespace Loteria.Gen
{
    public class Statistics
    {
        private readonly Generator _generator;

        public Dictionary<int, int> Counts => _counts;
        private readonly Dictionary<int, int> _counts = new();

        public Statistics(Generator generator) => _generator = generator;


        public void Generate()
        {
            GenerateCounts();
        }

        private void GenerateCounts()
        {
            for (int i = 1; i <= _generator.From; i++)
                _counts.Add(i, 0);

            foreach (var combination in _generator.Combinations)
                foreach (var num in combination)
                    _counts[num]++;
        }
    }
}
