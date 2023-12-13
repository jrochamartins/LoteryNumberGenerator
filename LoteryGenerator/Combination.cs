using System.Security.Cryptography;
using System.Text;

namespace LoteryGenerator
{
    public class Combination : SortedSet<int>
    {
        private static readonly HashAlgorithm _algorithm = new Force.Crc32.Crc32Algorithm();
        
        private string? _key;

        public string Key
        {
            get
            {
                if (_key != null) return _key;                
                _key = GetHash();
                return _key;
            }
        }

        public override string ToString()
        {   
            var formatted = this.Select(_ => _.ToString().PadLeft(2, '0'));
            return string.Join(", ", formatted);
        }

        private string GetHash()
        {
            var source = Encoding.ASCII.GetBytes(ToString());
            var hash = _algorithm.ComputeHash(source);
            return BitConverter.ToString(hash);
        }
    }
}