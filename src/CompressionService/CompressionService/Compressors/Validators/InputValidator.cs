namespace CompressionService.Compressors.Validators
{
    public class InputValidator
    {
        public bool IsAllLettersLowercase(string value)
        {
            foreach (char c in value)
            {
                if (char.IsLetter(c) && !char.IsLower(c))
                    return false;
            }

            return true;
        }

        public bool IsAllLatinLetters(string value)
        {
            foreach (char c in value)
            {
                if ((c < 'a' || c > 'z'))
                    return false;
            }

            return true;
        }

        public bool IsLowercaseLatinOrDigits(string value)
        {
            foreach (char c in value)
            {
                if ((c < 'a' || c > 'z') && (c < '0' || c > '9'))
                    return false;
            }

            return true;
        }
    }
}