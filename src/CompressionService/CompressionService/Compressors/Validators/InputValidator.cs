namespace CompressionService.Compressors.Validators
{
    public class InputValidator
    {
        public bool ContainsOnlyLowercaseLatin(string value)
        {
            foreach (char c in value)
            {
                if (c < 'a' || c > 'z')
                {
                    return false;
                }
            }

            return true;
        }
    }
}