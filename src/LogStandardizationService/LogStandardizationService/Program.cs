using LogStandardizationService.Configs;
using LogStandardizationService.Facades;
using LogStandardizationService.Files;
using LogStandardizationService.Interfaces;
using LogStandardizationService.Parsers;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .SetMinimumLevel(LogLevel.Information)
        .AddConsole();
});

ILogger logger = loggerFactory.CreateLogger<FileWriterLogDecorator>();
IWriter writer = new FileWriter();
IWriter fileWriter = new FileWriterLogDecorator(logger, writer);

FormatParserBase formatParserOne = new FormatParserOne(ConfigRegex.Format1Regex);
FormatParserBase formatParserTwo = new FormatParserTwo(ConfigRegex.Format2Regex);

LogStandardizationFacade logStandardizationFacade = new(fileWriter, formatParserOne, formatParserTwo);

logStandardizationFacade.Parse();