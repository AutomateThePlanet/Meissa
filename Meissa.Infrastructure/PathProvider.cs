// <copyright file="PathProvider.cs" company="Automate The Planet Ltd.">
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
using System.IO;
using System.Linq;
using Meissa.Core.Contracts;

namespace Meissa.Infrastructure
{
    public class PathProvider : IPathProvider
    {
        public string GetFileName(string file) => Path.GetFileName(file);

        public string Combine(string path1, string path2) => Path.Combine(path1, path2);

        public string Combine(string path1, string path2, string path3) => Path.Combine(path1, path2, path3);

        public string GetTempFileName() => Path.GetTempFileName();

        public string GetTempFolderPath() => Path.GetTempPath();

        public string GetDirectoryName(string filename) => Path.GetDirectoryName(filename);

        public bool IsFilePathValid(string fileName) => Path.GetInvalidPathChars().ToList().Any();
    }
}