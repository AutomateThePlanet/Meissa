// <copyright file="ProcessProvider.cs" company="Automate The Planet Ltd.">
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
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Meissa.Core.Contracts;

namespace Meissa.Infrastructure
{
    /// <summary>Starts a process and allows capturing the output (both standard and error).</summary>
    public class ProcessProvider : IProcessProvider
    {
        public DateTime GetStartTimeOfCurrentProcess()
        {
            var process = Process.GetCurrentProcess();
            return process.StartTime;
        }

        public void Start(string fileName, string arguments) => Process.Start(fileName, arguments);

        public void CloseProcess(Process process)
        {
            process.CloseMainWindow();
            process.Close();
            process.Dispose();
        }

        public Process GetCurrentProcess() => Process.GetCurrentProcess();

        public string GetEntryProcessApplicationPath()
        {
            // If we will write tests some day, create separate interfaces for below classes. But I think there is no need.
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        /// <summary>Starts a new process with the specified file name and arguments.</summary>
        /// <param name="fileName">The name of the file to start.</param>
        /// <param name="workingDir">The working directory.</param>
        /// <param name="arguments">The arguments to pass to the started application.</param>
        /// <param name="timeoutMinutes">The time that the program will wait for the process to finish in minutes.</param>
        /// <param name="standardOutputCallback">A callback function that is called when data is written to the standard output.</param>
        /// <param name="errorOutputCallback">A callback function that is called when data is written to the error output.</param>
        /// <returns>The exit code of the process.</returns>
        /// <remarks>Both standardOutputCallback and errorOutputCallback can be null. In that case, the specified data is not captured.
        /// The single argument to both these callback functions is the data that was written to the specified output.</remarks>
        public int StartProcessAndWaitToFinish(
            string fileName,
            string workingDir,
            string arguments,
            int timeoutMinutes,
            Action<string> standardOutputCallback = null,
            Action<string> errorOutputCallback = null)
        {
            var redirectStandard = standardOutputCallback != null;
            var redirectError = errorOutputCallback != null;

            var startInfo = InitializeProcessStartInfo(fileName, workingDir, arguments, redirectStandard, redirectError);

            var process = InitializeProcess(standardOutputCallback, errorOutputCallback, redirectStandard, redirectError, startInfo);

            using (process)
            {
                process.Start();

                ExecutePostProcessStartActions(redirectStandard, redirectError, process);

                WaitForProcessToFinish(timeoutMinutes, process);

                var exitCode = DetermineFinalProcessExitCode(process);

                return exitCode;
            }
        }

        public void WaitForProcessToFinish(int timeoutMinutes, Process process)
        {
            if (timeoutMinutes != 0)
            {
                var timeoutMilliseconds = TimeSpan.FromMinutes(timeoutMinutes).TotalMilliseconds;
                process?.WaitForExit((int)timeoutMilliseconds);
            }
            else
            {
                process?.WaitForExit();
            }
        }

        public Process StartProcess(
            string fileName,
            string workingDir,
            string arguments,
            Action<string> standardOutputCallback = null,
            Action<string> errorOutputCallback = null)
        {
            var redirectStandard = standardOutputCallback != null;
            var redirectError = errorOutputCallback != null;

            var startInfo = InitializeProcessStartInfo(fileName, workingDir, arguments, redirectStandard, redirectError);

            var process = InitializeProcess(standardOutputCallback, errorOutputCallback, redirectStandard, redirectError, startInfo);

            process.Start();

            ExecutePostProcessStartActions(redirectStandard, redirectError, process);

            return process;
        }

        public Process InitializeProcess(
         string fileName,
         string workingDir,
         string arguments,
         Action<string> standardOutputCallback = null,
         Action<string> errorOutputCallback = null)
        {
            var redirectStandard = standardOutputCallback != null;
            var redirectError = errorOutputCallback != null;

            var startInfo = InitializeProcessStartInfo(fileName, workingDir, arguments, redirectStandard, redirectError);

            var process = InitializeProcess(standardOutputCallback, errorOutputCallback, redirectStandard, redirectError, startInfo);

            return process;
        }

        public Process StartProcess(Process process, Action<string> standardOutputCallback = null, Action<string> errorOutputCallback = null)
        {
            var redirectStandard = standardOutputCallback != null;
            var redirectError = errorOutputCallback != null;

            process.Start();

            ExecutePostProcessStartActions(redirectStandard, redirectError, process);

            return process;
        }

        private ProcessStartInfo InitializeProcessStartInfo(string fileName, string workingDir, string arguments, bool redirectStandard, bool redirectError)
        {
            var startInfo = new ProcessStartInfo(fileName, arguments)
                            {
                                UseShellExecute = false,
                                CreateNoWindow = false,
                            };
            //// UseShellExecute has to be false if standard or error output is redirected
            if (!string.IsNullOrEmpty(workingDir))
            {
                startInfo.WorkingDirectory = workingDir;
            }

            if (redirectStandard || redirectError)
            {
                if (redirectStandard)
                {
                    startInfo.RedirectStandardOutput = true;
                }

                if (redirectError)
                {
                    startInfo.RedirectStandardError = true;
                }
            }

            return startInfo;
        }

        private Process InitializeProcess(
            Action<string> standardOutputCallback,
            Action<string> errorOutputCallback,
            bool redirectStandard,
            bool redirectError,
            ProcessStartInfo startInfo)
        {
            var process = new Process
            {
                StartInfo = startInfo,
            };
            if (redirectStandard || redirectError)
            {
                // the events are only raised if this property is set to true
                process.EnableRaisingEvents = true;

                if (redirectStandard)
                {
                    process.OutputDataReceived += (_, e) => standardOutputCallback(e.Data);
                }

                if (redirectError)
                {
                    process.ErrorDataReceived += (_, e) => errorOutputCallback(e.Data);
                }
            }

            return process;
        }

        private void ExecutePostProcessStartActions(bool redirectStandard, bool redirectError, Process process)
        {
            // capturing standard output only starts if you call BeginOutputReadLine
            if (redirectStandard)
            {
                process.BeginOutputReadLine();
            }

            // capturing error output only starts if you call BeginErrorReadLine
            if (redirectError)
            {
                process.BeginErrorReadLine();
            }
        }

        private int DetermineFinalProcessExitCode(Process process)
        {
            int exitCode;
            try
            {
                if (!process.HasExited)
                {
                    exitCode = -2;
                }
                else
                {
                    exitCode = process.ExitCode;
                }
            }
            catch (InvalidOperationException)
            {
                exitCode = -1;
            }

            return exitCode;
        }
    }
}