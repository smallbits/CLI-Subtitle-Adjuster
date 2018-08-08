using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SubtitlesLibrary;

namespace SubtitleTests
{
    public class SubtitleLineTests
    {
        [Fact]
        public void ToString_ShouldReturnCorrectString()
        {
            //Arrange
            string expected = "8\n00:01:23,459 --> 00:01:24,876\nWe did it, Pete.We did it.";
            //Act
            SrtSubtitleLine subtitleLine = new SrtSubtitleLine()
            {
                LineNumber = 8,
                StartTime = new TimeSpan(0, 0, 1, 23, 459),
                EndTime = new TimeSpan(0, 0, 1, 24, 876),
                Text = "We did it, Pete.We did it."
            };
            //Assert
            Assert.Equal(expected, subtitleLine.ToString());
        }
    }
}
