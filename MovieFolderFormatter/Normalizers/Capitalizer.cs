using System.Linq;
using System.Text.RegularExpressions;

namespace MovieFolderFormatter
{
    public class Capitalizer : ITitleProcessor
    {
        public int Priority => 3000;

        public string Process(string title)
        {
            var capitalizedFirsLetters = Regex
                .Matches(title, @"\w{2,}")
                .Cast<Match>()
                .Aggregate(title, (result, match) => 
                    result.Replace(match.Value, CapitalizeFirstLetter(match.Value)));

            return Regex
                .Matches(capitalizedFirsLetters, @"\b[a-z]\.")
                .Cast<Match>()
                .Aggregate(capitalizedFirsLetters, (result, match) => 
                    result.Replace(match.Value, match.Value.ToUpperInvariant()));
        }

        private string CapitalizeFirstLetter(string word) => 
            $"{word.Substring(0, 1).ToUpperInvariant()}{word.Substring(1).ToLowerInvariant()}";
    }
}