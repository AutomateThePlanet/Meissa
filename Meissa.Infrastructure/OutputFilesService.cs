// <copyright file="OutputFilesService.cs" company="Automate The Planet Ltd.">
// Copyright 2018 Automate The Planet Ltd.
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
using System.IO;
using Meissa.Core.Contracts;

namespace Meissa.Infrastructure
{
    public class OutputFilesService : IOutputFilesService
    {
        private const string TestRunIdNullEmptyExceptionMessage = @"The test run ID cannot be empty or null.";
        private const string SharedOutputFilesEmptyNullExceptionMessage = @"The shared output files location cannot be empty or null.";
        private const string OriginalOutputFilesEmptyNullExceptionMessage = @"The original output files location cannot be empty or null.";
        private const string SharedOutputFilesLocationNotExistExceptionMessage = @"The shared output files location does not exist.";
        private const string WorkingDirectoryNotExistExceptionMessage = @"The working directory does not exist.";
        private const string OriginalOutputFilesLocationNotExistExceptionMessage = @"The original output files location does not exist.";
        private const string TestListNullExceptionMessage = @"The test list cannot be empty or null.";
        private readonly IFileProvider _fileProvider;
        private readonly IDirectoryProvider _directoryProvider;
        private readonly IPathProvider _pathProvider;

        public OutputFilesService(IFileProvider fileProvider, IDirectoryProvider directoryProvider, IPathProvider pathProvider)
        {
            _fileProvider = fileProvider;
            _directoryProvider = directoryProvider;
            _pathProvider = pathProvider;
        }

        public string CreateLocalTestListFileAsync(string testList)
        {
            if (string.IsNullOrEmpty(testList))
            {
                throw new ArgumentNullException(TestListNullExceptionMessage);
            }

            var testListContent = testList;
            var testListFilePath = _pathProvider.GetTempFileName();
            _fileProvider.WriteAllText(testListFilePath, testListContent);

            return testListFilePath;
        }

        public void CopyOutputFilesToSharedLocation(Guid testRunId, string sharedOutputFilesLocation, string originalOutputFilesLocation)
        {
            ValidateCopyOutputFilesToSharedLocationsParameters(testRunId, sharedOutputFilesLocation, originalOutputFilesLocation);
            var newTestRunDirectoryPath = BuildTestRunIdFolderPath(testRunId, sharedOutputFilesLocation);
            AssureTestRunIdFolderCreated(newTestRunDirectoryPath);
            CopyOutputFilesToNewTestRunFolder(newTestRunDirectoryPath, originalOutputFilesLocation);
        }

        public void CopyResultsOutputFilesToResultsOutputLocation(string workingDirectory, string resultsOutputLocation)
        {
            if (resultsOutputLocation != null)
            {
                if (!_directoryProvider.DoesDirectoryExists(workingDirectory))
                {
                    throw new ArgumentNullException(WorkingDirectoryNotExistExceptionMessage);
                }

                CopyAll(workingDirectory, resultsOutputLocation);
            }
        }

        private void ValidateCopyOutputFilesToSharedLocationsParameters(Guid testRunId, string sharedOutputFilesLocation, string originalOutputFilesLocation)
        {
            if (testRunId.Equals(Guid.Empty))
            {
                throw new ArgumentNullException(TestRunIdNullEmptyExceptionMessage);
            }

            if (string.IsNullOrEmpty(sharedOutputFilesLocation))
            {
                throw new ArgumentNullException(SharedOutputFilesEmptyNullExceptionMessage);
            }

            if (string.IsNullOrEmpty(originalOutputFilesLocation))
            {
                throw new ArgumentNullException(OriginalOutputFilesEmptyNullExceptionMessage);
            }

            if (!_directoryProvider.DoesDirectoryExists(sharedOutputFilesLocation))
            {
                throw new ArgumentNullException(SharedOutputFilesLocationNotExistExceptionMessage);
            }

            if (!_directoryProvider.DoesDirectoryExists(originalOutputFilesLocation))
            {
                throw new ArgumentNullException(OriginalOutputFilesLocationNotExistExceptionMessage);
            }
        }

        private string BuildTestRunIdFolderPath(Guid testRunId, string sharedOutputFilesLocation)
        {
            var newTestRunDirectoryPath = _pathProvider.Combine(sharedOutputFilesLocation, testRunId.ToString());
            return newTestRunDirectoryPath;
        }

        private void AssureTestRunIdFolderCreated(string newTestRunDirectoryPath)
        {
            if (!_directoryProvider.DoesDirectoryExists(newTestRunDirectoryPath))
            {
                _directoryProvider.CreateDirectory(newTestRunDirectoryPath);
            }
        }

        private void CopyOutputFilesToNewTestRunFolder(string newTestRunDirectoryPath, string originalOutputFilesLocation)
            => CopyAll(originalOutputFilesLocation, newTestRunDirectoryPath);

        private void CopyAll(string sourceDirectory, string targetDirectory)
        {
            var dirInfoSource = new DirectoryInfo(sourceDirectory);
            var dirInfoTarget = new DirectoryInfo(targetDirectory);

            CopyAll(dirInfoSource, dirInfoTarget);
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (var fileInfo in source.GetFiles())
            {
                fileInfo.CopyTo(Path.Combine(target.FullName, fileInfo.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (var dirInfoSourceSubDir in source.GetDirectories())
            {
                var nextTargetSubDir =
                    target.CreateSubdirectory(dirInfoSourceSubDir.Name);
                CopyAll(dirInfoSourceSubDir, nextTargetSubDir);
            }
        }
    }
}