namespace MovieFolderFormatter
{
    public interface ITitleProcessor
    {
        string Process(string title);

        int Priority { get; }
    }
}