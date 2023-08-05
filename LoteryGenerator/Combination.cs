using System.Text;

namespace LoteryGenerator
{
    public class Combination : SortedSet<int>
    {
        internal string Key
        {
            get
            {
                var source = Encoding.ASCII.GetBytes(ToString());
                var hash = new Force.Crc32.Crc32Algorithm().ComputeHash(source);
                return Convert.ToBase64String(hash);
            }
        }

        public override string ToString()
        {
            var formatted = this.Select(_ => _.ToString().PadLeft(2, '0'));
            return string.Join(", ", formatted);
        }
    }
}