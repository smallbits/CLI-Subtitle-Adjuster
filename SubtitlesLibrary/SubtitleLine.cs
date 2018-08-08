using System;

namespace SubtitlesLibrary
{
    abstract class SubtitleLine
    {
        public bool HasLineNumber { get; set; }
        public int LineNumber { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Text { get; set; }

        public void AdjustTime(TimeSpan amount)
        {
            StartTime += amount;
            EndTime += amount;
        }
    }
}
