using System;
using System.Collections.Generic;
using System.IO;
using Meissa.Plugins.MSTest;

namespace NUnitReportMerge.Spike
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var plugin = new NativeTestsRunnerPluginService();
            string file1 = File.ReadAllText(@"C:\meissa-tests-results\corrupted.trx");
            var deserializedResults = plugin.DeserializeTestResults(file1);
            ////string mergedContent = plugin.MergeTestResults(deserializedResults);

            Console.WriteLine(deserializedResults);

            var nativeTestsRunnerTestCasesPluginService = new NativeTestsRunnerTestCasesPluginService();
            var testCases = nativeTestsRunnerTestCasesPluginService.ExtractAllTestCasesFromTestLibrary(@"C:\meissa-tests\SmallMSTestTestProject.dll");

            foreach (var testCase in testCases)
            {
                Console.WriteLine(testCase.FullName);
            }
            ////string filePath1 = File.ReadAllText(@"C:\Users\aangelov\Downloads\Meissa_Fixes\_nunit_reports_\tmpCD7E.tmp");
            ////string filePath2 = File.ReadAllText(@"C:\Users\aangelov\Downloads\Meissa_Fixes\_nunit_reports_\tmpCD8F.tmp");
            ////var passedTests1 = (testrun)plugin.DeserializeTestResults(filePath1);
            ////var passedTests2 = (List<testrunTestsuiteTestsuiteTestsuiteTestcase>)plugin.GetAllPassesTests(filePath2);
        }
    }
}
