using System.Text;

namespace LoteryGenerator
{
    public class Combination : SortedSet<int>
    {
        private const string SEPARATOR = ", ";

        private string? _key;

        /// <summary>
        /// Generate key (hash) of combination.
        /// </summary>
        /// <param name="cached">Uses value stored in cache.</param>
        /// <returns>Key (hash) of combination.</returns>
        internal string Key(bool cached = true)
        {
            if (cached && _key != null)
                return _key;

            var source = Encoding.ASCII.GetBytes(ToString());
            var hash = new Force.Crc32.Crc32Algorithm().ComputeHash(source);
            _key = BitConverter.ToString(hash);

            return _key;
        }

        public override string ToString()
        {
            var formatted = this.Select(_ => _.ToString().PadLeft(2, '0'));
            return string.Join(SEPARATOR, formatted);
        }
    }
}