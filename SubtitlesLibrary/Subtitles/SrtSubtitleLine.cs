using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SubtitlesLibrary
{
    public class SrtSubtitleLine : SubtitleLine
    {
        public SrtSubtitleLine()
        {

        }
        public SrtSubtitleLine(string input)
        {

            LineNumber = ParseLineNumber(input);
            ParseTime(input);

            StringBuilder textLines = new StringBuilder(Regex.Split(input, @"\d{2}:\d{2}:\d{2},\d{3} --> \d{2}:\d{2}:\d{2},\d{3}\r\n", RegexOptions.Multiline)[1]);
            Text = textLines.ToString();
        }
        public override string ToString()
        {
            string data = $@"{LineNumber}
{StartTime:hh':'mm':'ss','fff} --> {EndTime:hh':'mm':'ss','fff}
{Text}";
            return data;
        }

        protected int ParseLineNumber(string input) => int.Parse(Regex.Match(input, @"\d+").Value);

        protected void ParseTime(string input)
        {
            MatchCollection matchCollection = Regex.Matches(input, @"\d{2}:\d{2}:\d{2},\d{3}");
            StartTime = TimeSpan.Parse(matchCollection[0].Value);
            EndTime = TimeSpan.Parse(matchCollection[1].Value);
        }
    }
}