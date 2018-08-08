namespace SubtitlesLibrary
{
    class SrtSubtitleLine : SubtitleLine
    {
        public override string ToString()
        {
            string data = $"{LineNumber}\n{StartTime:hh':'mm':'ss','fff} --> {EndTime:hh':'mm':'ss','fff}\n{Text}";
            return data;
        }
    }
}
