namespace LoteryGenerator
{
    public class Combination : SortedSet<int>
    {
        internal string Key => string.Join('.', this);
    }
}