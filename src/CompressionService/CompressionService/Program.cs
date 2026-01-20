using CompressionService.Compressors.Decorators;
using CompressionService.Compressors.Interfaces;
using CompressionService.Facedes;
using CompressionService.Services;

ICompressor<string, string> textCompressor = new TextCompressor();
IDecompressor<string, string> textDecompressor = new TextDecompressor();

ICompressor<string, string> compressionTextDecorator = new CompressionTextDecorator(textCompressor);
IDecompressor<string, string> decompressionTextDecorator = new DecompressionTextDecorator(textDecompressor);

ICompressionFacade<string, string> compressionTextFacade
    = new CompressionFacade<string, string>(compressionTextDecorator, decompressionTextDecorator);

string source = "aaabbcccdde";

string compressed = compressionTextFacade.Compress(source);
string decompressed = compressionTextFacade.Decompress(compressed);

Console.WriteLine($"Source: {source}");
Console.WriteLine($"Compressed: {compressed}");
Console.WriteLine($"Decompressed: {decompressed}");