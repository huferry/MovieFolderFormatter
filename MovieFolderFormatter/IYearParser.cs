using System.Text.RegularExpressions;

namespace MovieFolderFormatter
{
    public interface IYearParser
    {
        (int year, string matchedValue) Parse(string folderName);
    }
}
