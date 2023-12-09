namespace LoteryGenerator
{
    public class ResultChecker
    {
        public int Hits => _hits;
        private readonly int _hits;

        public double PercentageOfSucess => _percentageOfSucess;
        private readonly double _percentageOfSucess;

        public ResultChecker(Combination attempt, Combination result)
        {
            _hits = CalculateHits(attempt, result);
            _percentageOfSucess = CalculatePercentageOfSucess(attempt);
        }

        private static int CalculateHits(Combination attempt, Combination result)
        {
            var attemptSet = new SortedSet<int>(attempt);
            attemptSet.IntersectWith(result);
            return attemptSet.Count;
        }

        public double CalculatePercentageOfSucess(Combination attempt) =>
            _hits * 100 / attempt.Count;
    }
}
