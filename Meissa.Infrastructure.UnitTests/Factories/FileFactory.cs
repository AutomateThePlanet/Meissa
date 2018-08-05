// <copyright file="FileFactory.cs" company="Automate The Planet Ltd.">
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

namespace Meissa.Infrastructure.UnitTests.Factories
{
    public static class FileFactory
    {
        public static string CreateTestFile(string textToWrite = null, string extension = "")
        {
            var destinationFolder = DirectoryFactory.CreateTestDirectory();
            var destinationFile = CreateTestFile(destinationFolder, textToWrite, extension);

            return destinationFile;
        }

        public static string CreateTestFile(string destinationFolder, string textToWrite = null, string extension = "")
        {
            var actualExtension = string.Empty;
            if (!string.IsNullOrEmpty(extension))
            {
                actualExtension = string.Concat(".", extension);
            }

            var destinationFile = Path.Combine(destinationFolder, string.Concat(Guid.NewGuid().ToString(), actualExtension));

            using (var writer = new StreamWriter(destinationFile))
            {
                if (string.IsNullOrEmpty(textToWrite))
                {
                    textToWrite = Guid.NewGuid().ToString();
                }

                writer.Write(textToWrite);
            }

            return destinationFile;
        }
    }
}
