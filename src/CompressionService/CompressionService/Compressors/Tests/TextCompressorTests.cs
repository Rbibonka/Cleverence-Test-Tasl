using CompressionService.Services;
using Xunit;

namespace CompressionService.Compressors.Tests
{
    public class TextCompressorTests
    {
        private readonly TextCompressor textCompressor = new();

        [Fact]
        public void Compress_EmptyString_ReturnsEmpty()
        {
            var result = textCompressor.Compress("");
            Assert.Equal("", result);
        }

        [Fact]
        public void Compress_SingleCharacter_ReturnsSameCharacter()
        {
            var result = textCompressor.Compress("a");
            Assert.Equal("a", result);
        }

        [Fact]
        public void Compress_RepeatedCharacters_AddsCount()
        {
            var result = textCompressor.Compress("aaabbcccdde");
            Assert.Equal("a3b2c3d2e", result);
        }
    }
}