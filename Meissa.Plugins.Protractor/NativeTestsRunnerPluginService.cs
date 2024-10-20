// <copyright file="NativeTestsRunnerPluginService.cs" company="Automate The Planet Ltd.">
// Copyright 2024 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>
using System;
using System.Collections.Generic;
using System.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Meissa.Core.Model;
using Meissa.Plugins.Contracts;
using Meissa.Plugins.Protractor.Model;
using Meissa.Server.Models;

namespace Meissa.Plugins.Protractor;

[Export(typeof(INativeTestsRunnerPluginService))]
public class NativeTestsRunnerPluginService : INativeTestsRunnerPluginService
{
    private const string JasminNUnitReporter = @"  
framework: 'jasmine',
  
  onPrepare: function() {
    var jasmineReporters = require('jasmine-reporters');
    jasmine.getEnv().addReporter(new jasmineReporters.NUnitXmlReporter({
        consolidateAll: true,
        savePath: '#',
        filePrefix: 'xmloutput'
    }));
  },";
    private const string ItNamePattern = @"(?'before'.*)(?'itBegin'it\(')(?'itName'.*)(?'thirdPart'(',).*)";
    private readonly string _deleteItemsFilePath = Path.Combine(Path.GetTempPath(), "protractorMeissaDeleteItemsPostExecute.txt");

    public string Name => "Protractor";

    // The path to the protractor bat should be specified in the config file.
    public string RunnerFile => "cmd.exe";

    public string ResultsFileExtension => "xml";

    public List<string> RunnerProcessesNamesToKill => new List<string> { "protractor" };

    // libraryName should be the name of the conf file
    // libraryPath should point the folder where the spec files are
    // not sure if we have to use testResultsFilePath
    public string BuildNativeRunnerArguments(string libraryName, string libraryPath, List<TestCase> testCasesToBeExecuted, string testResultsFilePath, string outputFilesDir, string nativeArguments)
    {
        // 1. copy all js files to temp folder
        // 2. edit conf.js and add results logger
        // 3. edit js files and set to focus all present here in the testCases names
        var allJsFiles = Directory.GetFiles(new FileInfo(libraryPath).Directory.FullName, "*.js", SearchOption.AllDirectories);

        // Ignore all files in node_modules folder
        var specFiles = allJsFiles.Where(x => !x.Contains("node_modules"));
        var tempFolderPath = Path.GetTempPath();
        var newTempFolder = Path.Combine(tempFolderPath, Guid.NewGuid().ToString());

        // Write the path of the file that we will later delete.
        File.AppendAllText(_deleteItemsFilePath, newTempFolder + Environment.NewLine);

        Directory.CreateDirectory(newTempFolder);

        // Copy all spec files to a temporary folder so that we can update them.
        foreach (var currentFile in specFiles)
        {
            var fileInfo = new FileInfo(currentFile);
            string newFilePath = Path.Combine(newTempFolder, fileInfo.Name);

            File.Copy(currentFile, newFilePath);
        }

        // Gather the paths to all copied spec files.
        var copiedSpecFiles = Directory.GetFiles(newTempFolder, "*.js", SearchOption.AllDirectories);

        // locate the conf.js file
        var confFile = copiedSpecFiles.FirstOrDefault(x => x.Contains(libraryName));

        // If the mentioned conf file doesn't exist we throw an exception since we cannot proceed.
        if (confFile == null)
        {
            throw new ArgumentException("The specified configuration file doesn't exist.");
        }

        // Read the content of the copied conf file and add the NUnit Jasmine reporter with specified results file path.
        string confFileContent = File.ReadAllText(confFile);

        // if for some reason a temp file exists we delete it, because the jasmine NUnit report cannot create a file but creates a folder.
        if (File.Exists(testResultsFilePath))
        {
            File.Delete(testResultsFilePath);
        }

        testResultsFilePath = testResultsFilePath.Replace("\\", "//");

        confFileContent = confFileContent.Replace("framework: 'jasmine',", JasminNUnitReporter.Replace("#", testResultsFilePath));
        File.WriteAllText(confFile, confFileContent);

        // To execute only the mentioned test cases we edit all spec files and set the 'f' infront of all it functions so that they are filtered.
        foreach (var newSpecFile in copiedSpecFiles)
        {
            string newSpecFileContent = File.ReadAllText(newSpecFile);

            var regex = new Regex(ItNamePattern);
            string focusedContent = ReplaceItNamesWithFocused(newSpecFileContent, regex, "itBegin", "f", testCasesToBeExecuted.Select(x => x.FullName).ToList());

            File.WriteAllText(newSpecFile, focusedContent);
        }

        // Copy jasmin_reporters node_modules folder to temp folder, otherwise the run cannot happen.
        string jasminReportersPluginsFolder = Path.Combine(GetRunningAssemblyPath(), "Plugins\\node_modules_jasmin_reporters");
        string jasminReportersModuleFolder = Path.Combine(newTempFolder, "node_modules");
        Copy(jasminReportersPluginsFolder, jasminReportersModuleFolder);

        var arguments = $" /c {Path.Combine(GetRunningAssemblyPath(), "Plugins\\node_modules\\.bin\\protractor")} {confFile} {nativeArguments}";

        return arguments;
    }

    public object DeserializeTestResults(string originalRunTestResults) => Deserialize<Testresults>(originalRunTestResults);

    public string SerializeTestResults(object testResults) => Serialize((Testresults)testResults);

    public object GetAllPassesTests(object testRunContent)
    {
        var testResults = Deserialize<Testresults>((string)testRunContent);
        var passedTestCases = GetAllNativePassedTestCases(testResults.Testsuite, true);

        return passedTestCases;
    }

    public object GetAllPassesTests(string testRunContent)
    {
        var results = GetAllPassesTests(testRunContent as object);
        return results;
    }

    public int GetAllPassesTestsCount(object testRunObj)
    {
        var testResults = (Testresults)testRunObj;
        var passedTestCases = GetAllNativePassedTestCases(testResults.Testsuite, true);

        return passedTestCases.Count;
    }

    public int GetAllNotPassesTestsCount(object testRunObj)
    {
        var testResults = (Testresults)testRunObj;
        var passedTestCases = GetAllNativePassedTestCases(testResults.Testsuite, false);

        return passedTestCases.Count;
    }

    public string MergeTestResults(object testResultsToBeMergedObj)
    {
        var result = string.Empty;
        Testresults mergedTestResults = null;
        var testResultsToBeMerged = (List<object>)testResultsToBeMergedObj;
        if (testResultsToBeMerged.Any())
        {
            mergedTestResults = (Testresults)testResultsToBeMerged.First();

            for (int i = 0; i < testResultsToBeMerged.Count; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                var currentTestResults = (Testresults)testResultsToBeMerged[i];

                MergeTestSuites(mergedTestResults.Testsuite, currentTestResults.Testsuite);

                var passedTestCases = GetAllNativePassedTestCases(currentTestResults.Testsuite, true);
                UpdateNativePassedTestCases(mergedTestResults.Testsuite, passedTestCases);
                UpdateNativePassedTestCasesSummary(mergedTestResults.Testsuite);
            }
        }

        if (mergedTestResults != null)
        {
            result = Serialize(mergedTestResults);
        }

        return result;
    }

    public void UpdatePassedTests(object passedTests, object testRun)
    {
        var testResults = (Testresults)testRun;

        UpdateNativePassedTestCases(testResults.Testsuite, (List<Testcase>)passedTests);
    }

    public void UpdateResultsSummary(object testRunObj)
    {
        var testresults = (Testresults)testRunObj;
        UpdateNativePassedTestCasesSummary(testresults.Testsuite);
    }

    public List<TestCaseRun> UpdateTestCasesHistory(object testRunContent, string libraryName)
    {
        var testResults = Deserialize<Testresults>((string)testRunContent);
        var allPassedTestsTestRun = GetAllPassesTests(testRunContent);
        var testCaseRuns = new List<TestCaseRun>();
        foreach (var currentNUnitTestCase in (List<Testcase>)allPassedTestsTestRun)
        {
            var duration = TimeSpan.FromSeconds(double.Parse(currentNUnitTestCase.Time));
            var unitTestLibraryName = testResults.Name;
            var fullName = currentNUnitTestCase.Name;
            if (unitTestLibraryName != null && unitTestLibraryName.ToLower().Contains(libraryName.ToLower()))
            {
                testCaseRuns.Add(new TestCaseRun(fullName, duration));
            }
        }

        return testCaseRuns;
    }

    public List<List<TestCase>> SplitTestCases(int availableCores, bool sameMachineByClass, List<TestCase> testCasesToBeDistributed)
    {
        if (availableCores <= 0)
        {
            throw new ArgumentException("Test Agents Count Must be Greater Than 0.");
        }

        var orderedByClassTestCases = testCasesToBeDistributed.OrderBy(x => x.ClassName).ToList();
        int numberOfTestsPerList = (int)Math.Ceiling(orderedByClassTestCases.Count / (double)availableCores);

        List<List<TestCase>> distributedTestCases = new List<List<TestCase>>();
        if (numberOfTestsPerList > 0)
        {
            int distributedIndex = 0;
            int tempDistributedTestsCount = numberOfTestsPerList;
            string previousClass = null;
            for (int i = 0; i < orderedByClassTestCases.Count; i++)
            {
                bool shouldResetTestsPerList = ShouldResetTestsPerList(sameMachineByClass, orderedByClassTestCases[i].ClassName, previousClass);
                if (tempDistributedTestsCount <= 0 && shouldResetTestsPerList)
                {
                    tempDistributedTestsCount = numberOfTestsPerList;
                    distributedIndex++;
                }

                if (tempDistributedTestsCount == numberOfTestsPerList)
                {
                    distributedTestCases.Add(new List<TestCase>());
                }

                distributedTestCases[distributedIndex].Add(orderedByClassTestCases[i]);
                previousClass = orderedByClassTestCases[i].ClassName;

                tempDistributedTestsCount--;
            }
        }
        else
        {
            distributedTestCases.Add(testCasesToBeDistributed);
        }

        return distributedTestCases;
    }

    public List<TestCase> GetAllNotPassedTests(string testResultsFileContent)
    {
        var testResults = Deserialize<Testresults>(testResultsFileContent);
        var nativeNotPassedTestCases = GetAllNativePassedTestCases(testResults.Testsuite, false);
        var notPassedTestCases = new List<TestCase>();
        foreach (var nativeTestCase in nativeNotPassedTestCases)
        {
            notPassedTestCases.Add(new TestCase(nativeTestCase.Name, nativeTestCase.Name));
        }

        return notPassedTestCases;
    }

    public List<TestCase> GetAllPassesTestCases(string testResultsFileContent)
    {
        var testResults = Deserialize<Testresults>(testResultsFileContent);
        var nativeNotPassedTestCases = GetAllNativePassedTestCases(testResults.Testsuite, true);
        var notPassedTestCases = new List<TestCase>();
        foreach (var nativeTestCase in nativeNotPassedTestCases)
        {
            notPassedTestCases.Add(new TestCase(nativeTestCase.Name, nativeTestCase.Name));
        }

        return notPassedTestCases;
    }

    public object GetRetriedTestResultsForTestRun(List<TestAgentRunDto> testAgentRuns)
    {
        var testRuns = new List<object>();
        if (testAgentRuns.Any())
        {
            foreach (var testAgentRun in testAgentRuns)
            {
                if (!string.IsNullOrEmpty(testAgentRun.TestAgentRetriedRunResults))
                {
                    var msTestTestRun = Deserialize<Testresults>(testAgentRun.TestAgentRetriedRunResults);
                    testRuns.Add(msTestTestRun);
                }
            }
        }

        return testRuns;
    }

    public object GetTestResultsForTestRun(List<TestAgentRunDto> testAgentRuns)
    {
        var testRuns = new List<object>();
        if (testAgentRuns.Any())
        {
            foreach (var testAgentRun in testAgentRuns)
            {
                if (!string.IsNullOrEmpty(testAgentRun.TestAgentOriginalRunResults))
                {
                    var testRun = Deserialize<Testresults>(testAgentRun.TestAgentOriginalRunResults);
                    testRuns.Add(testRun);
                }
            }
        }

        return testRuns;
    }

    private bool ShouldResetTestsPerList(bool sameMachineByClass, string currentClass, string previousClass)
        => sameMachineByClass ? previousClass != currentClass : true;

    private void MergeTestSuites(List<Testsuite> mergedTestSuites, List<Testsuite> testSuites)
    {
        foreach (var testSuite in testSuites)
        {
            if (mergedTestSuites != null && !mergedTestSuites.Any(x => x.Name.Equals(testSuite.Name)))
            {
                mergedTestSuites.Add(testSuite);
            }
            else if (mergedTestSuites == null)
            {
                mergedTestSuites = new List<Testsuite> { testSuite };
            }
        }

        foreach (var testSuite in testSuites)
        {
            foreach (var currentTestCase in testSuite.Results.Testcase)
            {
                var currentSuiteMergedTestCases = mergedTestSuites.First(x => x.Name.Equals(testSuite.Name)).Results.Testcase;
                if (currentSuiteMergedTestCases != null && !currentSuiteMergedTestCases.Any(x => x.Name.Equals(currentTestCase.Name)))
                {
                    currentSuiteMergedTestCases.Add(currentTestCase);
                }
                else if (currentSuiteMergedTestCases == null)
                {
                    currentSuiteMergedTestCases = new List<Testcase> { currentTestCase };
                }
            }

            if (testSuite.Results.Testsuite != null)
            {
                MergeTestSuites(mergedTestSuites.First(x => x.Name.Equals(testSuite.Name)).Results.Testsuite, testSuite.Results.Testsuite);
            }
        }
    }

    private TEntity Deserialize<TEntity>(string content)
    {
        var serializer = new XmlSerializer(typeof(TEntity));
        var reader = new StringReader(content);
        var testRun = (TEntity)serializer.Deserialize(reader);
        reader.Close();

        return testRun;
    }

    private string Serialize<TEntity>(TEntity entityToBeSerialized)
    {
        var settings = new XmlWriterSettings
        {
            Encoding = new UnicodeEncoding(false, false),
            Indent = false,
            OmitXmlDeclaration = false,
        };
        var xmlSerializer = new XmlSerializer(typeof(TEntity));
        string result;

        using (var stringWriter = new StringWriter())
        {
            using var writer = XmlWriter.Create(stringWriter, settings);
            xmlSerializer.Serialize(writer, entityToBeSerialized);
            result = stringWriter.ToString();
        }

        result = result.Replace("xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", string.Empty);
        result = result.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", string.Empty);

        return result;
    }

    public string ReplaceItNamesWithFocused(string input, Regex regex, string groupName, string replacement, List<string> testNamesToBeChanged)
    {
        return regex.Replace(input, m => ReplaceNamedGroupItName(groupName, replacement, m, testNamesToBeChanged));
    }

    // ReSharper disable once UnusedParameter.Local
    private List<Testcase> GetAllNativePassedTestCases(List<Testsuite> testSuites, bool shouldBePassed)
    {
        var passedTestCases = new List<Testcase>();

        foreach (var testSuite in testSuites)
        {
            if (testSuite != null && testSuite.Results != null && testSuite.Results.Testcase != null)
            {
                passedTestCases.AddRange(testSuite.Results.Testcase.Where(x => !x.Failure.Any()).ToList());

                if (testSuite.Results.Testsuite != null)
                {
                    passedTestCases.AddRange(GetAllNativePassedTestCases(testSuite.Results.Testsuite, shouldBePassed));
                }
            }
        }

        return passedTestCases;
    }

    private void UpdateNativePassedTestCasesSummary(List<Testsuite> testSuites)
    {
        foreach (var testSuite in testSuites)
        {
            if (testSuite != null && testSuite.Results != null && testSuite.Results.Testcase != null)
            {
                if (testSuite.Results.Testcase.Count(x => x.Success.Equals("true")) == testSuite.Results.Testcase.Count)
                {
                    testSuite.Success = "true";
                }

                if (testSuite.Results.Testsuite != null)
                {
                    UpdateNativePassedTestCasesSummary(testSuite.Results.Testsuite);
                }
            }
        }
    }

    private void UpdateNativePassedTestCases(List<Testsuite> testSuites, List<Testcase> passedTestCases)
    {
        foreach (var testSuite in testSuites)
        {
            if (testSuite != null && testSuite.Results != null && testSuite.Results.Testcase != null)
            {
                foreach (var currentTestCase in testSuite.Results.Testcase)
                {
                    if (passedTestCases.Any(x => x.Name.Equals(currentTestCase.Name)))
                    {
                        currentTestCase.Success = "true";
                        currentTestCase.Failure = new List<Failure>();
                    }
                }

                if (testSuite.Results.Testsuite != null)
                {
                    UpdateNativePassedTestCases(testSuite.Results.Testsuite, passedTestCases);
                }
            }
        }
    }

    private string ReplaceNamedGroupItName(string groupName, string replacement, Match m, List<string> testNamesToBeChanged)
    {
        string capture = m.Value;
        if (!string.IsNullOrEmpty(m.Groups["itName"]?.Value) && testNamesToBeChanged.Contains(m.Groups["itName"]?.Value))
        {
            capture = capture.Remove(m.Groups[groupName].Index - m.Index, m.Groups[groupName].Length);
            capture = capture.Insert(m.Groups[groupName].Index - m.Index, replacement + m.Groups[groupName]);
        }

        return capture;
    }

    private void Copy(string sourceDirectory, string targetDirectory)
    {
        var diSource = new DirectoryInfo(sourceDirectory);
        var diTarget = new DirectoryInfo(targetDirectory);

        CopyAll(diSource, diTarget);
    }

    private void CopyAll(DirectoryInfo source, DirectoryInfo target)
    {
        Directory.CreateDirectory(target.FullName);

        // Copy each file into the new directory.
        foreach (FileInfo fi in source.GetFiles())
        {
            Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
            fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
        }

        // Copy each subdirectory using recursion.
        foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
        {
            DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
            CopyAll(diSourceSubDir, nextTargetSubDir);
        }
    }

    private string GetRunningAssemblyPath() => Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

    public void ExecutePostRunActions()
    {
        if (File.Exists(_deleteItemsFilePath))
        {
            var fileLines = File.ReadAllLines(_deleteItemsFilePath);
            foreach (var fileLine in fileLines)
            {
                if (Directory.Exists(fileLine))
                {
                    try
                    {
                        Directory.Delete(fileLine, true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"There was a problem with deleting temp protractor folder- {fileLine}");
                        Console.WriteLine(ex);
                    }
                }
            }

            try
            {
                File.Delete(_deleteItemsFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was a problem with deleting temp protractor file- {_deleteItemsFilePath}");
                Console.WriteLine(ex);
            }
        }
    }
}