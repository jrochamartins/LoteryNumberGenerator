namespace LoteryGenerator
{
    public class ResultChecker(Combination result)
    {
        private readonly Combination _result = result;

        public int Hits(Combination attempt)
        {
            var attemptSet = new SortedSet<int>(attempt);
            attemptSet.IntersectWith(_result);
            return attemptSet.Count;
        }

        public double PercentageOfSucess(Combination attempt) =>
            Hits(attempt) * 100 / _result.Count;
    }
}
