namespace Task03.StringCountService
{
    using System;
    using System.Text.RegularExpressions;

    public class StringCounter : IStringCounter
    {
        public int FindWordOccurance(string text, string lookingFor)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException("The input text can not be null or empty string");
            }

            if (string.IsNullOrWhiteSpace(lookingFor))
            {
                throw new ArgumentNullException("The word which are you looking for can not be null or empty string");
            }

            var result = Regex.Matches(text, lookingFor).Count;
            return result;
        }
    }
}
