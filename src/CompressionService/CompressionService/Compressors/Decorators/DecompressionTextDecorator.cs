using CompressionService.Compressors.Interfaces;

namespace CompressionService.Compressors.Decorators
{
    public class DecompressionTextDecorator : DecompressionDecoratorBase<string, string>
    {
        private IDecompressor<string, string> decompressor;

        public DecompressionTextDecorator(
            IDecompressor<string, string> decompressor)
        {
            this.decompressor = decompressor;
        }

        public override string Decompress(string compressionData)
        {
            if (string.IsNullOrEmpty(compressionData))
            {
                throw new ArgumentNullException(nameof(compressionData));
            }

            return decompressor.Decompress(compressionData);
        }
    }
}