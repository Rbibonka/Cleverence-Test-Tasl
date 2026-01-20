using CompressionService.Compressors.Decorators;
using CompressionService.Compressors.Interfaces;
using Moq;
using Xunit;

namespace CompressionService.Compressors.Tests
{
    public class CompressionTextDecoratorTests
    {
        private readonly Mock<ICompressor<string, string>> _compressorMock;
        private readonly CompressionTextDecorator _decorator;

        public CompressionTextDecoratorTests()
        {
            _compressorMock = new Mock<ICompressor<string, string>>();
            _compressorMock.Setup(c => c.Compress(It.IsAny<string>())).Returns((string s) => $"compressed:{s}");

            _decorator = new CompressionTextDecorator(_compressorMock.Object);
        }

        [Fact]
        public void Compress_NullOrEmpty_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _decorator.Compress(null));
            Assert.Throws<ArgumentNullException>(() => _decorator.Compress(""));
        }

        [Fact]
        public void Compress_WithUppercase_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _decorator.Compress("Abc"));
            Assert.Contains("upper case characters", ex.Message);
        }

        [Fact]
        public void Compress_WithNonLatin_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _decorator.Compress("abcé"));
            Assert.Contains("Ñontains more than just Latin letters.", ex.Message);
        }

        [Fact]
        public void Compress_ValidInput_CallsInnerCompressor()
        {
            var input = "abcdef";
            var result = _decorator.Compress(input);

            _compressorMock.Verify(c => c.Compress(input), Times.Once);

            Assert.Equal($"compressed:{input}", result);
        }
    }
}