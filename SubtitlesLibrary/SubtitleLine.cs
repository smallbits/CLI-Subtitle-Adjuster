using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitlesLibrary
{
    class SubtitleLine
    {
        public bool HasLineNumber { get; set; }
        public int LineNumber { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Text { get; set; }
        
        public void AdjustTime(TimeSpan amount)
        {
            throw new NotImplementedException();
        }
    }
}
