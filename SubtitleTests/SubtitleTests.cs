using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;
using SubtitlesLibrary;

namespace SubtitleTests
{
    public class SubtitleTests
    {
        [Fact]
        public void Srt_TextSpliting()
        {
            //Arrange
            string[] expected = new string[]
            {
                @"1708
01:34:46,181 --> 01:34:47,848
Hey!",
@"1709
01:34:52,187 --> 01:34:53,854
What's your name?",
@"1710
01:34:53,938 --> 01:34:55,439
Davis."
            };
            //Act
            string[] actual = Regex.Split(@"1708
01:34:46,181 --> 01:34:47,848
Hey!

1709
01:34:W52,187 --> 01:34:53,854
What's your name?

1710
01:34:53,938 --> 01:34:55,439
Davis.",
@"^\s*$",
RegexOptions.Multiline).Select(s => s.Remove(s.Length-2, 2)).ToArray();
            //Assert
            Assert.Equal(expected[0], actual[0]);
        }
        [Fact]
        public void SrtToString()
        {
            //Arrange
            SrtSubtitle srtSubtitle = new SrtSubtitle(@"1708
01:34:46,181 --> 01:34:47,848
Hey!

1709
01:34:52,187 --> 01:34:53,854
What's your name?

1710
01:34:53,938 --> 01:34:55,439
Davis.");
            string expected = @"1708
01:34:46,181 --> 01:34:47,848
Hey!

1709
01:34:52,187 --> 01:34:53,854
What's your name?

1710
01:34:53,938 --> 01:34:55,439
Davis.";
            //Act
            string actual = srtSubtitle.ToString();
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void SrtCreationTest()
        {
            //Arrange
            SrtSubtitle srtSubtitle = new SrtSubtitle(@"1708
01:34:46,181 --> 01:34:47,848
Hey!

1709
01:34:52,187 --> 01:34:53,854
What's your name?

1710
01:34:53,938 --> 01:34:55,439
Davis.");
            SrtSubtitleLine line = new SrtSubtitleLine(
            @"1708
01:34:46,181 --> 01:34:47,848
Hey!");
            //TimeSpan expectedStartTime = line.StartTime;
            TimeSpan expectedStartTime = new TimeSpan(0, 1, 34, 53, 938);
            string expectedText = "Hey!";
            //Act
            TimeSpan actualStartTme = srtSubtitle.subtitleLines[2].StartTime;
            string actualText = srtSubtitle.subtitleLines[0].Text;
            //Assert
            Assert.Equal(expectedStartTime, actualStartTme);
            Assert.Equal(expectedText, actualText);
        }
    }
}
