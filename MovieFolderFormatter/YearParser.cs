using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MovieFolderFormatter
{

    public class YearParser : IYearParser
    {
        public (int year, string matchedValue) Parse(string folderName)
        { 
            var match = TryMatchYear(
                folderName,
                ("\\[", "\\]"),
                ("\\(", "\\)"));

            return match != null 
            ? (
                int.Parse(match.Groups[1].Value),
                match.Value
            )
            : throw new InvalidOperationException(
                @"Folder name does not contain year."
            );

        }

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
