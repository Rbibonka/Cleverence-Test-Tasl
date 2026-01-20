using CompressionService.Compressors.Decorators;
using CompressionService.Compressors.Interfaces;

namespace CompressionService.Facedes
{
    public class CompressionFacade<TCompression, TDecompression>
        : ICompressionFacade<TCompression, TDecompression>
    {
        private ICompressor<TDecompression, TCompression> compressionDecoratorBase;
        private IDecompressor<TCompression, TDecompression> decompressionDecoratorBase;

        public CompressionFacade(
            ICompressor<TDecompression, TCompression> compressionDecoratorBase,
            IDecompressor<TCompression, TDecompression> decompressionDecoratorBase)
        {
            this.compressionDecoratorBase = compressionDecoratorBase;
            this.decompressionDecoratorBase = decompressionDecoratorBase;
        }

        public TCompression Compress(TDecompression compressionData)
        {
            return compressionDecoratorBase.Compress(compressionData);
        }

        public TDecompression Decompress(TCompression compressionData)
        {
            return decompressionDecoratorBase.Decompress(compressionData);
        }
    }
}