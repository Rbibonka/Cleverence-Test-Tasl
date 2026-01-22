using LogStandardizationService.Interfaces;
using Microsoft.Extensions.Logging;

namespace LogStandardizationService.Files
{
    public class FileWriterLogDecorator : IWriter
    {
        private IWriter fileWriter;
        private ILogger logger;

        public FileWriterLogDecorator(ILogger logger, IWriter fileWriter)
        {
            this.logger = logger;
            this.fileWriter = fileWriter;
        }

        public void Write(string path, string text)
        {
            logger.LogInformation($"Write log to file by path - {path}");
            fileWriter.Write(path, text);
        }
    }
}