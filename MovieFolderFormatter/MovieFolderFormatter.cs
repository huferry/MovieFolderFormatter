namespace MovieFolderFormatter
{
    public class MovieFolderFormatter
    {
        private readonly IFolderNameParser folderNameParser;

        public MovieFolderFormatter(
            IFolderNameParser folderNameParser)
        {
            this.folderNameParser = folderNameParser;
        }

        public string Format(string folderName) 
        {
            var movie = folderNameParser.Parse(folderName);
            return $"{movie.Title} [{movie.Year}]";
        }
    }
}
