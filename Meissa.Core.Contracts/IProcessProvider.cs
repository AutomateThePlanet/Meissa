// <copyright file="IProcessProvider.cs" company="Automate The Planet Ltd.">
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
using System.Diagnostics;

namespace Meissa.Core.Contracts
{
    public interface IProcessProvider
    {
        int StartProcessAndWaitToFinish(
            string fileName,
            string workingDir,
            string arguments,
            int timeoutMinutes,
            Action<string> standardOutputCallback = null,
            Action<string> errorOutputCallback = null);

        Process StartProcess(
            string fileName,
            string workingDir,
            string arguments,
            Action<string> standardOutputCallback = null,
            Action<string> errorOutputCallback = null);

        Process InitializeProcess(
         string fileName,
         string workingDir,
         string arguments,
         Action<string> standardOutputCallback = null,
         Action<string> errorOutputCallback = null);

        Process StartProcess(Process process, Action<string> standardOutputCallback = null, Action<string> errorOutputCallback = null);

        void WaitForProcessToFinish(int timeoutMinutes, Process process);

        DateTime GetStartTimeOfCurrentProcess();

        void Start(string fileName, string arguments);

        void CloseProcess(Process process);

        Process GetCurrentProcess();

        string GetEntryProcessApplicationPath();
    }
}