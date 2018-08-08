using System;
using Xunit;
using SubtitlesLibrary;

namespace SubtitleTests
{
    public class SubtitleLineTests
    {
        // Testing if SrtSubtitleLine returns string in expected format based on it's properties.
        [Fact]
        public void ToString_ShouldReturnCorrectString()
        {
            //Arrange
            string expected = "8\n00:01:23,459 --> 00:01:24,876\nWe did it, Pete.We did it.";
            SrtSubtitleLine subtitleLine = new SrtSubtitleLine()
            {
                LineNumber = 8,
                StartTime = new TimeSpan(0, 0, 1, 23, 459),
                EndTime = new TimeSpan(0, 0, 1, 24, 876),
                Text = "We did it, Pete.We did it."
            };
            //Act
            string actual = subtitleLine.ToString();
            //Assert
            Assert.Equal(expected, actual);
        }
        //Testing if SrtSubtitleLine constructor is properly creating instance based on input string
        [Fact]
        public void Test_SrtInstanceCreation_LineNumber()
        {
            //Arrange
            int expectedLineNumber = 50;
            TimeSpan expectedStartTime = new TimeSpan(0, 0, 5, 57, 691);
            TimeSpan expectedEndTime = new TimeSpan(0, 0, 6, 0, 109);
            string expectedText = @"I don't know.
It just never occurred to me.";
            SrtSubtitleLine subtitleLine = new SrtSubtitleLine(@"50
00:05:57,691 --> 00:06:00,109
I don't know.
It just never occurred to me.");
            //Act
            int actualLineNumber = subtitleLine.LineNumber;
            TimeSpan actualStartTime = subtitleLine.StartTime;
            TimeSpan actualEndTime = subtitleLine.EndTime;
            string actualText = subtitleLine.Text;
            //Assert
            Assert.Equal(expectedLineNumber, actualLineNumber);
            Assert.Equal(expectedStartTime, actualStartTime);
            Assert.Equal(expectedEndTime, actualEndTime);
            Assert.Equal(expectedText, actualText);
        }
    }
}
