namespace CompressionService.Compressors.Interfaces
{
    public interface ICompressionFacade<TCompression, TDecompression>
        : ICompressor<TDecompression, TCompression>,
        IDecompressor<TCompression, TDecompression> { }
}