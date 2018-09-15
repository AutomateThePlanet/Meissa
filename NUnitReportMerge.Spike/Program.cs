using System;
using System.Collections.Generic;
using System.IO;
using Meissa.Plugins.Protractor;

namespace NUnitReportMerge.Spike
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var plugin = new NativeTestsRunnerPluginService();
            string file1 = File.ReadAllText(@"C:\protractor-merge-results\results1.xml");
            string file2 = File.ReadAllText(@"C:\protractor-merge-results\results2.xml");
            var deserializedResults = new List<object>();
            deserializedResults.Add(plugin.DeserializeTestResults(file1));
            deserializedResults.Add(plugin.DeserializeTestResults(file2));
            string mergedContent = plugin.MergeTestResults(deserializedResults);

            Console.WriteLine(mergedContent);
            ////string filePath1 = File.ReadAllText(@"C:\Users\aangelov\Downloads\Meissa_Fixes\_nunit_reports_\tmpCD7E.tmp");
            ////string filePath2 = File.ReadAllText(@"C:\Users\aangelov\Downloads\Meissa_Fixes\_nunit_reports_\tmpCD8F.tmp");
            ////var passedTests1 = (testrun)plugin.DeserializeTestResults(filePath1);
            ////var passedTests2 = (List<testrunTestsuiteTestsuiteTestsuiteTestcase>)plugin.GetAllPassesTests(filePath2);
        }
    }
}
