using System.Text;

namespace T9ConverterApp
{
    public class TextToKeypadConverter : ITextToKeypadConverter
    {
        const char Separator = ' ';
        const int MaxMessageLength = 1000;
        readonly Dictionary<char, string> charDigitCodes = new()
        {
            { 'a', "2"},
            { 'b', "22"},
            { 'c', "222"},

            { 'd', "3"},
            { 'e', "33"},
            { 'f', "333"},

            { 'g', "4"},
            { 'h', "44"},
            { 'i', "444"},

            { 'j', "5"},
            { 'k', "55"},
            { 'l', "555"},

            { 'm', "6"},
            { 'n', "66"},
            { 'o', "666"},

            { 'p', "7"},
            { 'q', "77"},
            { 'r', "777"},
            { 's', "7777"},

            { 't', "8"},
            { 'u', "88"},
            { 'v', "888"},

            { 'w', "9"},
            { 'x', "99"},
            { 'y', "999"},
            { 'z', "9999"},

            { ' ', "0"},
        };

        public string ConvertTextToKeypad(ReadOnlySpan<char> text)
        {
            var stringBuilder = new StringBuilder();
            var lastAddedChar = '~';
            foreach (var @char in text)
            {
                if (!charDigitCodes.TryGetValue(@char, out var textToAppend))
                {
                    throw new NotSupportedException($"Character {@char} is not supported");
                }

                if (textToAppend.StartsWith(lastAddedChar))
                {
                    stringBuilder.Append(Separator);
                }
                stringBuilder.Append(textToAppend);
                lastAddedChar = textToAppend.Last();
            }
            var length = Math.Min(stringBuilder.Length, MaxMessageLength);
            return stringBuilder.ToString(0, length);
        }
    }
}