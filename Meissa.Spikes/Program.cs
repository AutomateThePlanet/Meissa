using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Meissa.Plugins.Protractor;

namespace Meissa.Spikes
{
    class Program
    {
        static void Main(string[] args)
        {
            var nativeTestsRunnerTestCasesPluginService = new NativeTestsRunnerTestCasesPluginService();

            var testCases = nativeTestsRunnerTestCasesPluginService.ExtractAllTestCasesFromTestLibrary(@"D:\protractor-tests\conf.js");

            ////foreach (var testCase in testCases)
            ////{
            ////    Console.WriteLine(testCase.FullName);
            ////}

            var nativeTestsRunnerPluginService = new NativeTestsRunnerPluginService();
            ////string fileContent = File.ReadAllText(@"D:\protractor-tests\testresults\nunitresults.xml");
            ////var ccc = nativeTestsRunnerPluginService.DeserializeTestResults(fileContent);
            ////Console.WriteLine(ccc.ToString());
            var resultsFilePath = Path.GetTempFileName();
            string args1 = nativeTestsRunnerPluginService.BuildNativeRunnerArguments(
                                                                                    "conf.js",
                                                                                    @"D:\protractor-tests\conf.js",
                                                                                    testCases,
                                                                                    resultsFilePath,
                                                                                    "D:\\protractor-tests",
                                                                                    string.Empty);

            ////Console.WriteLine(args1);
            ////Console.WriteLine(nativeTestsRunnerPluginService.RunnerFile);

            ////string fileContent = File.ReadAllText(@"D:\protractor-tests\example_spec.js");

            ////Regex regexPattern = new Regex(@"(?'before'.*)(?'itBegin'it\(')(?'itName'.*)(?'thirdPart'(',).*)");

            ////var list = Regex.Matches(fileContent, @"(?'before'.*)(?'itBegin'it\(')(?'itName'.*)(?'thirdPart'(',).*)", RegexOptions.IgnoreCase).Where(m => m.Groups.Count > 2 && !string.IsNullOrEmpty(m.Groups[2])).Select(match => match.Groups[2]);
            ////foreach (Match match in Regex.Matches(fileContent, @"it\('(?'itName'.*)(',).*", RegexOptions.IgnoreCase))
            ////{

            ////    Console.WriteLine(match.Groups[2]);
            ////}

            ////var specFiles = Directory.GetFiles(new FileInfo("D:\\protractor-tests\\").Directory.FullName, "*.js", SearchOption.TopDirectoryOnly);

            ////foreach (var specFile in specFiles)
            ////{
            ////    string fileContent = File.ReadAllText(specFile);
            ////    List<string> itNames = Regex.Matches(fileContent, @"(?'before'.*)(?'itBegin'it\(')(?'itName'.*)(?'thirdPart'(',).*)", RegexOptions.IgnoreCase)
            ////        .Cast<Match>()
            ////        .Where(m => m.Groups.Count > 5 && !string.IsNullOrEmpty(m.Groups[4].Value))
            ////        .Select(match => match.Groups[4].Value)
            ////        .ToList();
            ////    foreach (var itName in itNames)
            ////    {
            ////        Console.WriteLine(itName);
            ////    }
            ////}

            ////Console.WriteLine();

            ////List<string> testCasesToBeFiltered = new List<string>() { "should list todos", "should add a todo" };
            ////Regex regex = new Regex(@"(?'before'.*)(?'itBegin'it\(')(?'itName'.*)(?'thirdPart'(',).*)");
            ////string replace = fileContent.Replace(regex, "itBegin", "f", testCasesToBeFiltered);
            ////Console.WriteLine(replace);
        }
    }
}
