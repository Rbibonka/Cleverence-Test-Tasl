using CompressionService.Compressors.Interfaces;
using System.Text;

namespace CompressionService.Services
{
    public class TextDecompressor : IDecompressor<string, string>
    {
        public string Decompress(string input)
        {
            StringBuilder result = new StringBuilder();
            int i = 0;

            while (i < input.Length)
            {
                char symbol = input[i++];
                int count = 0;

                while (i < input.Length && char.IsDigit(input[i]))
                {
                    count = count * 10 + (input[i] - '0');
                    i++;
                }

                if (count == 0)
                    count = 1;

                result.Append(symbol, count);
            }

            return result.ToString();
        }
    }
}