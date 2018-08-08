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
            string[] lines = input.Split('\n');

            LineNumber = ParseLineNumber(lines[0]);
            ParseTime(lines[1]);

            StringBuilder textLines = new StringBuilder();
            for (int i = 2; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace("\r", "");
                textLines.AppendLine(lines[i]);
            }
            textLines.Remove(textLines.Length - 2, 2);
            Text = textLines.ToString();
        }
        public override string ToString()
        {
            string data = $"{LineNumber}\n{StartTime:hh':'mm':'ss','fff} --> {EndTime:hh':'mm':'ss','fff}\n{Text}";
            return data;
        }

        protected int ParseLineNumber(string input) => int.Parse(input);
        
        protected void ParseTime(string input)
        {
            MatchCollection matchCollection = Regex.Matches(input, @"\d{2}:\d{2}:\d{2},\d{3}");
            StartTime = TimeSpan.Parse(matchCollection[0].Value);
            EndTime = TimeSpan.Parse(matchCollection[1].Value);
        }
    }
}
