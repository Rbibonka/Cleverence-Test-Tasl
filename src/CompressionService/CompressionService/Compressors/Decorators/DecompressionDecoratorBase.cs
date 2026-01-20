using CompressionService.Compressors.Interfaces;

namespace CompressionService.Compressors.Decorators
{
    public abstract class DecompressionDecoratorBase<TCompression, TDecompression>
        : IDecompressor<TCompression, TDecompression>
    {
        public abstract TDecompression Decompress(TCompression compressionData);
    }
}