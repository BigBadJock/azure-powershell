﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------


using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.WindowsAzure.Commands.Common;

using System;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Security;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Aks.Utils
{
    public sealed class ValidateSecureString: ValidateEnumeratedArgumentsAttribute
    {
        public string RegularExpression { get; set; }

        protected override void ValidateElement(object element)
        {
            SecureString secureString = element as SecureString;
            string content = secureString.ConvertToString();
            Regex regex = new Regex(RegularExpression);
            if (!regex.IsMatch(content))
            {
                throw new ArgumentException(string.Format(Resources.SecureStringNotValid, RegularExpression));
            }
        }
    }
}
