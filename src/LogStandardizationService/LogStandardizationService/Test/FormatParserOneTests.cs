using LogStandardizationService.Configs;
using LogStandardizationService.Parsers;
using Xunit;

public class FormatParserOneTests
{
    private readonly FormatParserOne parser =
        new FormatParserOne(ConfigRegex.Format1Regex);

    [Fact]
    public void TryParseFormat_ValidLineWithMilliseconds_ReturnsTrueAndFormattedOutput()
    {
        string line = "05.01.2024 12:34:56.123 INFO Application started";

        bool result = parser.TryParseFormat(line, out string output);

        Assert.True(result);
        Assert.Equal(
            "05-01-2024\t12:34:56.123\tINFO\tDEFAULT\tApplication started",
            output);
    }

    [Fact]
    public void TryParseFormat_ValidLineWithLongFractionalSeconds_ReturnsTrue()
    {
        string line = "05.01.2024 12:34:56.1234567 DEBUG Detailed message";

        bool result = parser.TryParseFormat(line, out string output);

        Assert.True(result);
        Assert.Equal(
            "05-01-2024\t12:34:56.1234567\tDEBUG\tDEFAULT\tDetailed message",
            output);
    }

    [Fact]
    public void TryParseFormat_InvalidLineWithoutMilliseconds_ReturnsFalse()
    {
        string line = "05.01.2024 12:34:56 INFO Missing milliseconds";

        bool result = parser.TryParseFormat(line, out string output);

        Assert.False(result);
        Assert.Null(output);
    }

    [Fact]
    public void TryParseFormat_InvalidLine_ReturnsFalse()
    {
        string line = "this is not a log line";

        bool result = parser.TryParseFormat(line, out string output);

        Assert.False(result);
        Assert.Null(output);
    }

    [Fact]
    public void TryParseFormat_LevelIsNormalized()
    {
        string line = "01.02.2024 08:00:00.5 warn Something happened";

        parser.TryParseFormat(line, out string output);

        string[] parts = output.Split('\t');
        Assert.Equal("WARN", parts[2]);
    }

    [Fact]
    public void TryParseFormat_InvalidDate_ThrowsFormatException()
    {
        string line = "32.01.2024 10:00:00.1 INFO Wrong date";

        Assert.Throws<FormatException>(() =>
            parser.TryParseFormat(line, out _));
    }
}