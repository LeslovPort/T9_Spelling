namespace T9ConverterApp
{
    public interface ITextToKeypadConverter
    {
        string ConvertTextToKeypad(ReadOnlySpan<char> text);
    }
}