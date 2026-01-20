using CompressionService.Compressors.Interfaces;
using CompressionService.Compressors.Validators;

namespace CompressionService.Compressors.Decorators
{
    public class CompressionTextDecorator : CompressionDecoratorBase<string, string>
    {
        private ICompressor<string, string> compressor;

        private InputValidator inputValidator;

        public CompressionTextDecorator(
            ICompressor<string, string> compressor)
        {
            this.compressor = compressor;

            inputValidator = new();
        }

        public override string Compress(string decompressionData)
        {
            if (string.IsNullOrEmpty(decompressionData))
            {
                throw new ArgumentNullException(nameof(decompressionData));
            }
            else if (!inputValidator.IsAllLettersLowercase(decompressionData))
            {
                throw new ArgumentException($"{nameof(decompressionData)} has upper case characters");
            }
            else if (!inputValidator.IsAllLatinLetters(decompressionData))
            {
                throw new ArgumentException($"{nameof(decompressionData)} Ñontains more than just Latin letters.");
            }

            return compressor.Compress(decompressionData);
        }
    }
}