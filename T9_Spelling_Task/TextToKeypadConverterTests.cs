using Xunit;

namespace T9ConverterApp
{
    public class TextToKeypadConverterTests
    {
        [Theory]
        [InlineData("hi", "44 444")]
        [InlineData("yes", "999337777")]
        [InlineData("foo  bar", "333666 6660 022 2777")]
        [InlineData("hello world", "4433555 555666096667775553")]
        [InlineData("many    spaces", "62669990 0 0 07777 72 222337777")]
        [InlineData("abcdefghijklmnopqrstuvwxyz", "2 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 9999")]
        public void ConvertTextToT9_ShouldReturnExpected(string input, string expected)
        {
            //Arrange
            var t9Converter = new TextToKeypadConverter();

            //Act
            var actual = t9Converter.ConvertTextToKeypad(input);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertTextToKeypad_NotSupportedCharacter_ThrowsException()
        {
            //Arrange
            var t9Converter = new TextToKeypadConverter();
            var func = () => t9Converter.ConvertTextToKeypad("!@#$%`|");

            //Act & Assert
            Assert.Throws<NotSupportedException>(func);
        }
    }
}