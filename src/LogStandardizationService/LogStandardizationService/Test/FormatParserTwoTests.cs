using LogStandardizationService.Configs;
using LogStandardizationService.Parsers;
using Xunit;

namespace LogStandardizationService.Test
{
    public class FormatParserTwoTests
    {
        private readonly FormatParserTwo _parser =
        new FormatParserTwo(ConfigRegex.Format2Regex);

        [Fact]
        public void TryParseFormat_ValidLine_ReturnsTrueAndFormattedOutput()
        {
            string line = "2024-01-05 12:34:56.123|INFO|42|GetUser|User loaded";

            bool result = _parser.TryParseFormat(line, out string output);

            Assert.True(result);
            Assert.Equal(
                "05-01-2024\t12:34:56.123\tINFO\tGetUser\tUser loaded",
                output);
        }

        [Fact]
        public void TryParseFormat_MethodIsTrimmed()
        {
            string line ="2024-02-01 08:00:00.5|DEBUG|1|   ProcessData   | Done";

            _parser.TryParseFormat(line, out string output);

            string[] parts = output.Split('\t');
            Assert.Equal("ProcessData", parts[3]);
        }

        [Fact]
        public void TryParseFormat_LevelIsNormalized()
        {
            string line ="2024-03-10 09:10:11.999|warn|15|Handle| Something happened";

            _parser.TryParseFormat(line, out string output);

            string[] parts = output.Split('\t');
            Assert.Equal("WARN", parts[2]);
        }

        [Fact]
        public void TryParseFormat_InvalidLine_ReturnsFalseAndNullOutput()
        {
            string line = "this is not a valid log line";

            bool result = _parser.TryParseFormat(line, out string output);

            Assert.False(result);
            Assert.Null(output);
        }

        [Fact]
        public void TryParseFormat_InvalidDate_ThrowsFormatException()
        {
            string line = "2024-13-40 10:00:00.1|INFO|1|Test| Invalid date";

            Assert.Throws<FormatException>(() =>
                _parser.TryParseFormat(line, out _));
        }

        [Fact]
        public void TryParseFormat_MissingPipes_ReturnsFalse()
        {
            string line = "2024-01-05 12:34:56.123 INFO 42 GetUser User loaded";

            bool result = _parser.TryParseFormat(line, out string output);

            Assert.False(result);
            Assert.Null(output);
        }
    }
}