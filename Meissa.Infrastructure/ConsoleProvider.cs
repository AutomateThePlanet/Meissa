﻿// <copyright file="ConsoleProvider.cs" company="Automate The Planet Ltd.">
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
using Meissa.Core.Contracts;

namespace Meissa.Infrastructure;

public class ConsoleProvider : IConsoleProvider
{
    public void WriteLine(string format, params object[] arguments)
    {
        if (!string.IsNullOrEmpty(format))
        {
            System.Console.WriteLine(format, arguments);
        }
    }

    public void WriteLine(string message)
    {
        if (!string.IsNullOrEmpty(message))
        {
            System.Console.WriteLine(message);
        }
    }

    public void WriteLine() => System.Console.WriteLine();

    public void Write(string format, params object[] arguments)
    {
        if (!string.IsNullOrEmpty(format))
        {
            System.Console.Write(format, arguments);
        }
    }

    public void Write(string message)
    {
        if (!string.IsNullOrEmpty(message))
        {
            System.Console.Write(message);
        }
    }

    public void Clear() => System.Console.Clear();

    public string ReadLine() => System.Console.ReadLine();
}