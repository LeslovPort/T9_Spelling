using T9ConverterApp;

var converter = new TextToKeypadConverter();
while (true)
{
    Console.WriteLine("Provide an input text to be converted to the telephone keypad format");
    var text = Console.ReadLine();
    var converted = converter.ConvertTextToKeypad(text);
    Console.WriteLine(converted);
}
