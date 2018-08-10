/// <copyright file="MixedAuthConstants.cs" auther="Lokmani Kumar">
/// Copyright 2018 Lokmani Kumar. 
/// https://github.com/lokmani192/ITC_Cover4Pm
/// 
/// Released under the MIT license
/// http://opensource.org/licenses/MIT
///
/// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owin.Security.MixedAuth
{
    /// <summary>
    /// Default values related to mixe-authentication middleware
    /// </summary>
    public class MixedAuthConstants
    {
        /// <summary>
        /// The default value used for MixedAuthOptions.AuthenticationType
        /// </summary>
        public const string DefaultAuthenticationType = "Windows";

        /// <summary>
        /// The name used for the temporary authentication cookie.
        /// </summary>
        public const string TempCookieName = ".MixedAuth";

        /// <summary>
        /// The fake status code used to skip any handler or module dealing with the real status code 401.
        /// </summary>
        public const int FakeStatusCode = 418;
        
    }
}
