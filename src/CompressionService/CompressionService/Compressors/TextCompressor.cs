using CompressionService.Compressors.Interfaces;
using System.Text;

namespace CompressionService.Services
{
    public class TextCompressor : ICompressor<string, string>
    {
        public string Compress(string input)
        {
            StringBuilder result = new StringBuilder();
            int count = 1;

            for (int i = 1; i <= input.Length; i++)
            {
                if (i < input.Length && input[i] == input[i - 1])
                {
                    count++;
                }
                else
                {
                    result.Append(input[i - 1]);
                    if (count > 1)
                        result.Append(count);
                    count = 1;
                }
            }

            return result.ToString();
        }
    }
}