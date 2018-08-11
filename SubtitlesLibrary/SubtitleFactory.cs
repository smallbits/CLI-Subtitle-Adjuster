using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitlesLibrary
{
    public static class SubtitleFactory
    {
        public static Subtitle Create(string extension, string input)
        {
            switch (extension.ToLower())
            {
                case ".srt":
                    return new SrtSubtitle(input);
                default:
                    throw new ArgumentException($"File extension not recognized: {extension}");
            }
        }
    }
}
