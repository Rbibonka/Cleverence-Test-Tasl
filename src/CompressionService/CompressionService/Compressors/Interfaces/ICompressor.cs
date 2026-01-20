namespace CompressionService.Compressors.Interfaces
{
    public interface ICompressor<TDecompression, TCompression>
    {
        TCompression Compress(TDecompression decompressionData);
    }
}