namespace LoteryGenerator
{
    public class ResultChecker(Combination result, int minToWin)
    {
        private readonly Combination _result = result;
        private readonly int _minToWin = minToWin;


		public int Hits(Combination attempt)
        {
            var attemptSet = new SortedSet<int>(attempt);
            attemptSet.IntersectWith(_result);
            return attemptSet.Count;
        }

        public bool IsWinner(Combination attempt) =>
            Hits(attempt) >= _minToWin;
    }
}
