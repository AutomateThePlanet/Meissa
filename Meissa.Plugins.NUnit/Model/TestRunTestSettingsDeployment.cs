﻿// <copyright file="TestRunTestSettingsDeployment.cs" company="Automate The Planet Ltd.">
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

// <auto-generated/>
// ReSharper disable All

using System.Xml.Serialization;

namespace Meissa.Plugins.NUnit.Model
{
    
    [XmlType(AnonymousType = true, Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public partial class TestRunTestSettingsDeployment
    {
        private string userDeploymentRootField;

        private bool useDefaultDeploymentRootField;

        private string runDeploymentRootField;

        
        [XmlAttribute()]
        public string userDeploymentRoot
        {
            get
            {
                return this.userDeploymentRootField;
            }
            set
            {
                this.userDeploymentRootField = value;
            }
        }

        
        [XmlAttribute()]
        public bool useDefaultDeploymentRoot
        {
            get
            {
                return this.useDefaultDeploymentRootField;
            }
            set
            {
                this.useDefaultDeploymentRootField = value;
            }
        }

        
        [XmlAttribute()]
        public string runDeploymentRoot
        {
            get
            {
                return this.runDeploymentRootField;
            }
            set
            {
                this.runDeploymentRootField = value;
            }
        }
    }
}
// ReSharper enable all