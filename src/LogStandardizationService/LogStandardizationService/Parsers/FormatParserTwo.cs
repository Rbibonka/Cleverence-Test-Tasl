using System.Text.RegularExpressions;

namespace LogStandardizationService.Parsers
{
    public class FormatParserTwo : FormatParserBase
    {
        public FormatParserTwo(Regex formatRegex) : base(formatRegex) { }

        public override bool TryParseFormat(string line, out string output)
        {
            output = null;
            var match = FormatRegex.Match(line);
            if (!match.Success)
            {
                return false;
            }

            DateTime date = DateTime.ParseExact(
                match.Groups["date"].Value,
                "yyyy-MM-dd",
                null);

            string level = NormalizeLevel(match.Groups["level"].Value);

            output = string.Join("\t",
                date.ToString("dd-MM-yyyy"),
                match.Groups["time"].Value,
                level,
                match.Groups["method"].Value.Trim(),
                match.Groups["message"].Value
            );

            return true;
        }
    }
}