// <copyright file="DirectoryProvider.cs" company="Automate The Planet Ltd.">
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
using System.IO;
using Meissa.Core.Contracts;

namespace Meissa.Infrastructure;

public class DirectoryProvider : IDirectoryProvider
{
    public bool DoesDirectoryExists(string path) => Directory.Exists(path);

    public string[] GetFiles(string path) => Directory.GetFiles(path);

    public string[] GetFiles(string path, string searchPattern) => Directory.GetFiles(path, searchPattern);

    public void CreateDirectory(string path) => Directory.CreateDirectory(path);

    public bool Exists(string path) => Directory.Exists(path);

    public void Delete(string path, bool recursive) => Directory.Delete(path, recursive);
}