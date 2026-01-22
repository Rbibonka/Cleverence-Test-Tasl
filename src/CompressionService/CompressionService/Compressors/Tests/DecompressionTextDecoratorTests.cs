using CompressionService.Compressors.Decorators;
using CompressionService.Compressors.Interfaces;
using Moq;
using Xunit;

namespace CompressionService.Compressors.Tests
{
    public class DecompressionTextDecoratorTests
    {
        private readonly Mock<IDecompressor<string, string>> _decompressorMock;
        private readonly DecompressionTextDecorator _decorator;

        public DecompressionTextDecoratorTests()
        {
            _decompressorMock = new Mock<IDecompressor<string, string>>();
            _decompressorMock
                .Setup(d => d.Decompress(It.IsAny<string>()))
                .Returns((string s) => $"decompressed:{s}");

            _decorator = new DecompressionTextDecorator(_decompressorMock.Object);
        }

        [Fact]
        public void Decompress_NullOrEmpty_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _decorator.Decompress(null));
            Assert.Throws<ArgumentNullException>(() => _decorator.Decompress(""));
        }

        [Fact]
        public void Decompress_WithUppercase_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _decorator.Decompress("Abc123"));
            Assert.Contains("upper case characters", ex.Message);
        }

        [Fact]
        public void Decompress_WithInvalidCharacters_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _decorator.Decompress("abc!123"));
            Assert.Contains("Ñontains more than just Latin letters and digits.", ex.Message);
        }

        [Theory]
        [InlineData("abc123")]
        [InlineData("a1b2c3")]
        [InlineData("xyz999")]
        public void Decompress_ValidInput_CallsInnerDecompressor(string input)
        {
            var result = _decorator.Decompress(input);

            _decompressorMock.Verify(d => d.Decompress(input), Times.Once);

            Assert.Equal($"decompressed:{input}", result);
        }
    }
}