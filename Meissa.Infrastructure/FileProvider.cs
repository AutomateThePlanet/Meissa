// <copyright file="FileProvider.cs" company="Automate The Planet Ltd.">
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
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using Meissa.Core.Contracts;

namespace Meissa.Infrastructure
{
    public class FileProvider : IFileProvider
    {
        public void Copy(string sourceFileName, string destFileName, bool overwrite) => File.Copy(sourceFileName, destFileName, overwrite);

        public void WriteAllText(string path, string contents) => File.WriteAllBytes(path, Encoding.UTF8.GetBytes(contents));

        public string ReadAllText(string path) => File.ReadAllText(path);

        public void Delete(string path) => File.Delete(path);

        public void CreateZip(string sourceDirectoryPath, string zipPath) => ZipFile.CreateFromDirectory(sourceDirectoryPath, zipPath);

        public void ExtractZip(string zipPath, string extractPath) => ZipFile.ExtractToDirectory(zipPath, extractPath);

        public byte[] ReadAllBytes(string filePath) => File.ReadAllBytes(filePath);

        public void WriteAllBytes(string filePath, byte[] fileData) => File.WriteAllBytes(filePath, fileData);

        public bool Exists(string filePath) => File.Exists(filePath);

        public bool IsWithExtension(string filePath, string extension)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file does not exist", filePath);
            }

            var fileInfo = new FileInfo(filePath);
            return fileInfo.Extension.Equals(extension);
        }
    }
}