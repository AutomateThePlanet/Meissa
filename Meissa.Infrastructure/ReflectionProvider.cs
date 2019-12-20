// <copyright file="ReflectionProvider.cs" company="Automate The Planet Ltd.">
// Copyright 2020 Automate The Planet Ltd.
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
using System.IO;
using System.Reflection;
using Meissa.Core.Contracts;

namespace Meissa.Infrastructure
{
    public class ReflectionProvider : IReflectionProvider
    {
        public Assembly GetAssemblyFromFile(string fullFilePath)
        {
            var assembly = Assembly.LoadFrom(fullFilePath);

            return assembly;
        }

        public IEnumerable<Attribute> GetCustomAttributes(MethodInfo method) => method.GetCustomAttributes();

        public IEnumerable<Attribute> GetCustomAttributes(Type type) => type.GetCustomAttributes();

        public IEnumerable<CustomAttributeData> GetCustomAttributesData(Type type) => type.GetCustomAttributesData();

        public string GetMethodName(MethodInfo method) => method.Name;

        public string GetMethodReflectedTypeFullName(MethodInfo method) => method?.ReflectedType?.FullName;

        public MethodInfo[] GetMethods(Type type) => type.GetMethods();

        public string GetTypeFullName(Type type) => type.FullName;

        public Type[] GetTypes(Assembly assembly) => assembly.GetTypes();

        public string GetRunningAssemblyPath()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}