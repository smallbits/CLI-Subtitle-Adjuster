using System;
using System.Collections.Generic;

namespace SubtitlesLibrary
{
    public abstract class Subtitle
    {
        public List<SubtitleLine> subtitleLines = new List<SubtitleLine>();
        public void Adjust(TimeSpan amount) {
            for (int i = 0; i < subtitleLines.Count; i++)
            {
                subtitleLines[i].AdjustTime(amount);
            }
        }
    }
}
