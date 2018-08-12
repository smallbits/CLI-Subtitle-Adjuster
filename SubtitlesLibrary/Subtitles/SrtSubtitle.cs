using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SubtitlesLibrary
{
    public class SrtSubtitle : Subtitle
    {
        public SrtSubtitle(string input)
        {
            input = input.Trim();
            string[] textLines = Regex.Split(input, @"\r\n\r\n");
            foreach (var line in textLines)
            {
                SubtitleLine subtitleLine = new SrtSubtitleLine(line);
                subtitleLines.Add(subtitleLine);
            }
        }
        public override string ToString()
        {
            StringBuilder data = new StringBuilder();
            foreach (SubtitleLine line in subtitleLines)
            {
                data.Append(line.ToString());
                data.AppendLine();
                data.AppendLine();
            }
            data.Remove(data.Length - 4, 4);
            return data.ToString();
        }
    }
}
