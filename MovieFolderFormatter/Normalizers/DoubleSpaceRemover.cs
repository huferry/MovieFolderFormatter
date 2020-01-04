namespace MovieFolderFormatter
{
    public class DoubleSpaceRemover : ITitleProcessor
    {
        public string Process(string title) 
        {
            var processed = title.Replace("  ", " ");
            return processed == title
            ? title
            : Process(processed);
        }
    }
}