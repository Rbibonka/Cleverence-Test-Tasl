using CompressionService.Services;
using Xunit;

namespace CompressionService.Compressors.Tests
{
    public class TextDecompressorTests
    {
        private readonly TextDecompressor textDecompressor = new();

        [Fact]
        public void Decompress_EmptyString_ReturnsEmpty()
        {
            var result = textDecompressor.Decompress("");
            Assert.Equal("", result);
        }

        [Fact]
        public void Decompress_SingleCharacter_ReturnsSameCharacter()
        {
            var result = textDecompressor.Decompress("a");
            Assert.Equal("a", result);
        }

        [Fact]
        public void Decompress_CharacterWithCount_ReturnsRepeatedCharacters()
        {
            var result = textDecompressor.Decompress("a3b2c3d2e");
            Assert.Equal("aaabbcccdde", result);
        }
    }
}