using LogStandardizationService.Interfaces;

namespace LogStandardizationService.Files
{
    public class FileWriter : IWriter
    {
        public void Write(string path, string text)
        {
            using var writer = new StreamWriter(path);
            writer.WriteLine(text);
        }
    }
}