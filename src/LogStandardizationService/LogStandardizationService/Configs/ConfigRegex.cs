using System.Text.RegularExpressions;

namespace LogStandardizationService.Configs
{
    public static class ConfigRegex
    {
        public static Regex Format1Regex = new Regex(
            @"^(?<date>\d{2}\.\d{2}\.\d{4})\s+(?<time>\d{2}:\d{2}:\d{2}\.\d+)\s+(?<level>\w+)\s+(?<message>.+)$",
            RegexOptions.Compiled);

        public static Regex Format2Regex = new Regex(
            @"^(?<date>\d{4}-\d{2}-\d{2})\s+(?<time>\d{2}:\d{2}:\d{2}\.\d+)\|\s*(?<level>\w+)\|\d+\|(?<method>[^|]+)\|\s*(?<message>.+)$",
            RegexOptions.Compiled);
    }
}