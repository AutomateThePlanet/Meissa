using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Meissa.Spikes
{
    public static class RegexExtensions
    {
        public static string Replace(this string input, Regex regex, string groupName, string replacement, List<string> testNamesToBeChanged)
        {
            return regex.Replace(input, m => ReplaceNamedGroup(input, groupName, replacement, m, testNamesToBeChanged));
        }

        private static string ReplaceNamedGroup(string input, string groupName, string replacement, Match m, List<string> testNamesToBeChanged)
        {
            string capture = m.Value;
            if (!string.IsNullOrEmpty(m.Groups["itName"]?.Value) && testNamesToBeChanged.Contains(m.Groups["itName"]?.Value))
            {
                capture = capture.Remove(m.Groups[groupName].Index - m.Index, m.Groups[groupName].Length);
                capture = capture.Insert(m.Groups[groupName].Index - m.Index, replacement + m.Groups[groupName]);
            }

            return capture;
        }
    }
}
