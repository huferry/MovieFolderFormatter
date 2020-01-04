using System.Linq;
using System.Text.RegularExpressions;

namespace MovieFolderFormatter
{
    public class YearParser
    {
        public Match Parse(string folderName) 
        => TryMatchYear(
                folderName,
                ("\\[", "\\]"),
                ("\\(", "\\)"));

        private Match GetMatch(
            string folderName,
            string yearOpeningMark,
            string yearClosingMark) 
            => Regex.Match(folderName, $@"{yearOpeningMark}(\d{{4}}){yearClosingMark}");

        private Match TryMatchYear(
            string folderName,
            params (string yearOpeningMark, string yearClosingMark)[] yearMarks) 
            => yearMarks
            .Select(ym => GetMatch(folderName, ym.yearOpeningMark, ym.yearClosingMark))
            .FirstOrDefault(m => m.Success);
    }
}
