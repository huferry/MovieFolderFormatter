namespace MovieFolderFormatter
{
    using System;
    using System.Linq;

    public class FolderNameParser
    : IFolderNameParser
    {
        private readonly IYearParser yearParser;
        private readonly ITitleNormalizer titleNormalizer;

        public FolderNameParser(
            IYearParser yearParser,
            ITitleNormalizer titleNormalizer
        )
        {
            this.yearParser = yearParser;
            this.titleNormalizer = titleNormalizer;
        }
        public Movie Parse(string folderName)
        {
            var yearMatch = yearParser.Parse(folderName);            
            var rawTitle = folderName
                    .Split(
                        new[]{yearMatch.matchedValue}, 
                        StringSplitOptions.RemoveEmptyEntries
                        ).FirstOrDefault();

            return new Movie 
            {
                Year = yearMatch.year,
                Title = titleNormalizer.Normalize(rawTitle)
            };

            throw new System.NotImplementedException();
        }
    }
}