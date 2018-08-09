using System;
using System.Collections.Generic;

namespace SubtitlesLibrary
{
    public abstract class Subtitle
    {
        protected List<SubtitleLine> subtitleLines = new List<SubtitleLine>();
        public void Adjust(TimeSpan amount) {
            foreach (SubtitleLine line in subtitleLines)
            {
                line.AdjustTime(amount);
            }
        }
    }
}
