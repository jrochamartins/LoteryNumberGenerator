using System.Security.Cryptography;
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
                var sourceBytes = MD5.HashData(source);

                int i;
                var output = new StringBuilder(sourceBytes.Length);
                for (i = 0; i < sourceBytes.Length - 1; i++)
                    output.Append(sourceBytes[i].ToString("X2"));
                return output.ToString();
            }
        }

        public override string ToString()
        {
            var formated = this.Select(_ => _.ToString().PadLeft(2, '0'));
            return string.Join(", ", formated);
        }
    }
}