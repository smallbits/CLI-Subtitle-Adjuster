using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitlesLibrary
{
    class SrtSubtitle : Subtitle
    {
        public SrtSubtitle(string input)
        {
            throw new NotImplementedException();
        }

        public override void Adjust()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            StringBuilder data = new StringBuilder();
            foreach (SubtitleLine line in subtitleLines)
            {
                data.Append(GetLineText(line));
            }

            return data.ToString();
        }

        protected override string GetLineText(SubtitleLine line)
        {
            string data = $"{line.LineNumber}\n{line.StartTime:hh':'mm':'ss','fff} --> {line.EndTime:hh':'mm':'ss','fff}\n{line.Text}\n\n";

            return data;
        }
    }
}
