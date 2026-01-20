namespace CompressionService.Compressors.Interfaces
{
    public interface IDecompressor<TCompression, TDecompression>
    {
        TDecompression Decompress(TCompression compressionData);
    }
}