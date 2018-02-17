// <copyright file="DistributeLogDumpCreator.cs" company="Automate The Planet Ltd.">
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
// <site>https://automatetheplanet.com/</site>
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meissa.API.Models;
using Meissa.Core.Contracts;

namespace Meissa.Infrastructure
{
    public class DistributeLogDumpCreator : IDistributeLogDumpCreator
    {
        private const string UniqueFileNameFormat = @"MM-dd-yyyy-hh-mm-ss-ffff";
        private readonly IServiceClient<LogDto> _logRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IFileProvider _fileProvider;
        private readonly IDirectoryProvider _directoryProvider;
        private readonly IPathProvider _pathProvider;
        private readonly IConsoleProvider _consoleProvider;
        private readonly IReflectionProvider _reflectionProvider;

        public DistributeLogDumpCreator(
            IServiceClient<LogDto> logRepository,
            IDateTimeProvider dateTimeProvider,
            IFileProvider fileProvider,
            IDirectoryProvider directoryProvider,
            IPathProvider pathProvider,
            IConsoleProvider consoleProvider,
            IReflectionProvider reflectionProvider)
        {
            _logRepository = logRepository;
            _dateTimeProvider = dateTimeProvider;
            _fileProvider = fileProvider;
            _directoryProvider = directoryProvider;
            _pathProvider = pathProvider;
            _consoleProvider = consoleProvider;
            _reflectionProvider = reflectionProvider;
        }

        public async Task<string> CreateDumpAsync(string dumpLocation)
        {
            var dumpFileLocation = dumpLocation;
            if (string.IsNullOrEmpty(dumpFileLocation))
            {
                dumpFileLocation = _reflectionProvider.GetRunningAssemblyPath();
            }
            else
            {
                if (!_directoryProvider.DoesDirectoryExists(dumpLocation))
                {
                    try
                    {
                        _directoryProvider.CreateDirectory(dumpLocation);
                        _consoleProvider.WriteLine($"{dumpLocation} doesn't exists.");
                        _consoleProvider.WriteLine($"{dumpLocation} created.");
                    }
                    catch (IOException e)
                    {
                        _consoleProvider.WriteLine(e.ToString());
                        _consoleProvider.WriteLine($"{dumpLocation} cannot be created.");
                        throw;
                    }
                }
            }

            var exceptionLogs = (await _logRepository.GetAllAsync()).ToList();
            var sb = new StringBuilder();
            foreach (var exceptionLog in exceptionLogs)
            {
                sb.AppendLine($"{exceptionLog.Date} {exceptionLog.Message} {exceptionLog.Exception}");
            }

            var uniqueFileName = string.Concat(GenerateUniqueText(), ".txt");
            var filePath = _pathProvider.Combine(dumpFileLocation, uniqueFileName);
            _fileProvider.WriteAllText(filePath, sb.ToString());
            _consoleProvider.WriteLine($"dump file created successfully - {filePath}");

            return filePath;
        }

        public async Task DeleteAllDumpsAsync()
        {
            var exceptionLogs = await _logRepository.GetAllAsync();
            foreach (var exceptionLog in exceptionLogs)
            {
                await _logRepository.DeleteAsync(exceptionLog.Id);
            }
        }

        private string GenerateUniqueText()
        {
            var newTimestamp = _dateTimeProvider.GetCurrentTime().ToString(UniqueFileNameFormat);
            return newTimestamp;
        }
    }
}