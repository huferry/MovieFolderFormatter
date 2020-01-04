namespace MovieFolderFormatter
{
    public class UnderscoreRemover : ITitleProcessor
    {
        public string Process(string title) 
        => title?.Replace("_", " ");
    }
}