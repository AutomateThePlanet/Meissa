// <copyright file="IReflectionProvider.cs" company="Automate The Planet Ltd.">
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
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Meissa.Core.Contracts
{
    public interface IReflectionProvider
    {
        Assembly GetAssemblyFromFile(string fullFilePath);

        Type[] GetTypes(Assembly assembly);

        MethodInfo[] GetMethods(Type type);

        IEnumerable<Attribute> GetCustomAttributes(Type type);

        IEnumerable<Attribute> GetCustomAttributes(MethodInfo method);

        IEnumerable<CustomAttributeData> GetCustomAttributesData(Type type);

        string GetTypeFullName(Type type);

        string GetMethodReflectedTypeFullName(MethodInfo method);

        string GetMethodName(MethodInfo method);

        string GetRunningAssemblyPath();
    }
}