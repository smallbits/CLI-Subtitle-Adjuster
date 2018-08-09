using System;
using System.Text;

namespace SubtitlesLibrary
{
    public class SrtSubtitle : Subtitle
    {
        public SrtSubtitle(string input)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            StringBuilder data = new StringBuilder();
            foreach (SubtitleLine line in subtitleLines)
            {
                data.Append(line.ToString());
            }

            return data.ToString();
        }
    }
}
