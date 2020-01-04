using System.Text.RegularExpressions;
using System.Linq;

namespace  MovieFolderFormatter
{
    public class DotsRemover : ITitleProcessor
    {
        public int Priority => 2000;

        public string Process(string title)
        {
            return Regex.Matches(title, @"(\w{3,})\.")
                .Cast<Match>()
                .Aggregate(title, 
                 (result, match) => result.Replace(match.Value, match.Groups[1].Value + " "));
        }
    }
}