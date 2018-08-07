using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitlesLibrary
{
    abstract class Subtitle
    {
        protected List<SubtitleLine> subtitleLines = new List<SubtitleLine>();
        public abstract void Adjust();
    }
}
