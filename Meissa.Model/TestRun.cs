// <copyright file="TestRun.cs" company="Automate The Planet Ltd.">
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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meissa.Model
{
    public class TestRun
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TestRunId { get; set; }

        public TestRunStatus Status { get; set; }

        [Required]
        public string TestAssemblyName { get; set; }

        [Required]
        public DateTime DateStarted { get; set; }

        public DateTime DateFinished { get; set; }

        public string NativeArguments { get; set; }

        public int RetriesCount { get; set; }

        public double Threshold { get; set; }

        public bool RunInParallel { get; set; }

        public bool IsTimeBasedBalance { get; set; }

        public int MaxParallelProcessesCount { get; set; }

        [Required]
        public string TestTechnology { get; set; }
    }
}
