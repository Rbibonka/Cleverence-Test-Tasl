using System.Text.RegularExpressions;

namespace LogStandardizationService.Parsers
{
    public abstract class FormatParserBase
    {
        protected Regex FormatRegex { private set; get; }

        public FormatParserBase(Regex formatRegex)
        {
            FormatRegex = formatRegex;
        }

        public abstract bool TryParseFormat(string line, out string output);

        protected string NormalizeLevel(string level)
        {
            return level.ToUpper() switch
            {
                "INFORMATION" => "INFO",
                "INFO" => "INFO",
                "WARNING" => "WARN",
                "WARN" => "WARN",
                "ERROR" => "ERROR",
                "DEBUG" => "DEBUG",
                _ => "INFO"
            };
        }
    }
}