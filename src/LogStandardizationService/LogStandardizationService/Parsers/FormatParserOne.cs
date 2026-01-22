using System.Text.RegularExpressions;

namespace LogStandardizationService.Parsers
{
    public class FormatParserOne : FormatParserBase
    {
        public FormatParserOne(Regex formatRegex) : base(formatRegex) { }

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
                "dd.MM.yyyy",
                null);

            string level = NormalizeLevel(match.Groups["level"].Value);

            output = string.Join("\t",
                date.ToString("dd-MM-yyyy"),
                match.Groups["time"].Value,
                level,
                "DEFAULT",
                match.Groups["message"].Value
            );

            return true;
        }
    }
}