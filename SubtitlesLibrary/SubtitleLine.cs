using System;

namespace SubtitlesLibrary
{
    public abstract class SubtitleLine
    {
        public bool HasLineNumber => LineNumber > 0;
        public int LineNumber { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Text { get; set; }

        public void AdjustTime(TimeSpan amount)
        {
            StartTime = StartTime + amount;
            EndTime = EndTime + amount;
        }
    }
}
