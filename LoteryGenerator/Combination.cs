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
                var source = Encoding.ASCII.GetBytes(string.Concat(this));
                var sourceArray = MD5.HashData(source);

                int i;
                var sOutput = new StringBuilder(sourceArray.Length);
                for (i = 0; i < sourceArray.Length - 1; i++)
                    sOutput.Append(sourceArray[i].ToString("X2"));
                return sOutput.ToString();
            }
        }
    }
}