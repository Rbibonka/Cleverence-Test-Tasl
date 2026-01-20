using CompressionService.Compressors.Interfaces;
using CompressionService.Compressors.Validators;

namespace CompressionService.Compressors.Decorators
{
    public class DecompressionTextDecorator : DecompressionDecoratorBase<string, string>
    {
        private IDecompressor<string, string> decompressor;

        private InputValidator inputValidator;

        public DecompressionTextDecorator(
            IDecompressor<string, string> decompressor)
        {
            this.decompressor = decompressor;

            inputValidator = new();
        }

        public override string Decompress(string compressionData)
        {
            if (string.IsNullOrEmpty(compressionData))
            {
                throw new ArgumentNullException(nameof(compressionData));
            }
            else if (!inputValidator.IsAllLettersLowercase(compressionData))
            {
                throw new ArgumentException($"{nameof(compressionData)} has upper case characters");
            }
            else if (!inputValidator.IsLowercaseLatinOrDigits(compressionData))
            {
                throw new ArgumentException($"{nameof(compressionData)} Ñontains more than just Latin letters and digits.");
            }

            return decompressor.Decompress(compressionData);
        }
    }
}