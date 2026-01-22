
using CompressionService.Compressors.Interfaces;

namespace CompressionService.Compressors.Decorators
{
    public abstract class CompressionDecoratorBase<TDecompression, TCompression>
        : ICompressor<TDecompression, TCompression>
    {
        public abstract TCompression Compress(TDecompression compressionData);
    }
}