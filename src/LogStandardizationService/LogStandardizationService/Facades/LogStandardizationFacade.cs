using LogStandardizationService.Configs;
using LogStandardizationService.Interfaces;
using LogStandardizationService.Parsers;

namespace LogStandardizationService.Facades
{
    public class LogStandardizationFacade
    {
        private IWriter writer;
        private FormatParserBase[] formatParsers;

        public LogStandardizationFacade(
            IWriter writer,
            params FormatParserBase[] formatParsers)
        {
            this.writer = writer;
            this.formatParsers = formatParsers;
        }

        public void Parse()
        {
            foreach (var line in File.ReadLines(ConfigFiles.InputFile))
            {
                if (!TryParseLine(line, out string result))
                {
                    writer.Write(ConfigFiles.ProblemsFile, line);
                }
                else
                {
                    writer.Write(ConfigFiles.OutputFile, result);
                }
            }
        }

        private bool TryParseLine(string line, out string output)
        {
            output = null;

            foreach (var parser in formatParsers)
            {
                if (parser.TryParseFormat(line, out output))
                {
                    return true;
                }
            }

            return false;
        }
    }
}