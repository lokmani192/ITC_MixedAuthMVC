/// <copyright file="MixedAuthExtensions.cs" auther="Lokmani Kumar">
/// Copyright 2018 Lokmani Kumar. 
/// https://github.com/lokmani192/ITC_Cover4Pm
/// 
/// Released under the MIT license
/// http://opensource.org/licenses/MIT
///
/// </copyright>

using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Web;

namespace Owin.Security.MixedAuth
{
    /// <summary>
    /// Extension methods provided by the mixed authentication middleware
    /// </summary>
    public static class MixedAuthExtensions
    {
        /// <summary>
        /// Adds a mixed-authentication middleware support.
        /// </summary>
        /// <remarks>
        /// This is required to enable the modification of the fake status code.
        /// </remarks>
        /// <param name="app">The HttpApplication instance.</param>
        public static void RegisterMixedAuth(this HttpApplication app)
        {
            app.EndRequest += (object sender, EventArgs e) =>
            {
                if (app.Context.Response.StatusCode == MixedAuthConstants.FakeStatusCode)
                {
                    app.Context.Response.StatusCode = 401;
                    app.Context.Response.SubStatusCode = 2;
                }
            };
        }

        /// <summary>
        /// Helper method to convert <see cref="CookieAuthenticationOptions"/> to <see cref="CookieOptions"/>.
        /// </summary>
        /// <param name="cookieOptions">Cookies Authentication middleware options <see cref="CookieAuthenticationOptions"/>.</param>
        /// <param name="expires"> When should the cookie expires</param>
        /// <returns> A new instance of <see cref="CookieOptions"/>.</returns>
        public static CookieOptions ToCookieOptions(this CookieAuthenticationOptions cookieOptions, DateTime expires)
        {
            CookieOptions options = new CookieOptions();
            options.Domain = cookieOptions.CookieDomain;
            options.Expires = expires;
            options.HttpOnly = cookieOptions.CookieHttpOnly;
            options.Path = cookieOptions.CookiePath;
            options.Secure = !options.HttpOnly;
            return options;

        }
    }
}
