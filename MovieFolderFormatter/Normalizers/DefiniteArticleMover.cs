using System.Text.RegularExpressions;

namespace MovieFolderFormatter
{
    public class DefiniteArticleMover : ITitleProcessor
    {
        public int Priority => 3000;

        public string Process(string title)
        {
            var match = Regex.Match(title, @"^the\b", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return $"{title.Replace(match.Value, string.Empty)}, The".Trim();
            }

            return title;
        }
    }
}