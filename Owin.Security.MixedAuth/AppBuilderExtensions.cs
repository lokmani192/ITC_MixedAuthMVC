/// <copyright file="AppBuilderExtensions.cs" auther="Lokmani Kumar">
/// Released under the MIT license
/// http://opensource.org/licenses/MIT
///
/// </copyright>

using System;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security.Cookies;
using Owin.Security.MixedAuth;

namespace Owin
{
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Adds a mixed-authentication middleware to your web application pipeline.
        /// </summary>
        /// <param name="app">The IAppBuilder passed to your configuration method</param>
        /// <param name="options">An options class that controls the middleware behavior</param>
        /// <param name="cookieOptions">An options class that controls the middleware behavior</param>
        /// <returns>The original app parameter</returns>
        public static IAppBuilder UseMixedAuth(this IAppBuilder app,
            MixedAuthOptions options,
            CookieAuthenticationOptions cookieOptions)
        {
            if (app == null)
                throw new ArgumentNullException("app");
            if (options == null)
                throw new ArgumentNullException("options");
            if (cookieOptions == null)
                throw new ArgumentNullException("cookieOptions");

            options.CookieOptions = cookieOptions;

            app.Use(typeof(MixedAuthMiddleware), app, options);

            app.UseStageMarker(PipelineStage.PostAuthenticate);

            return app;
        }

        /// <summary>
        /// Adds a mixed-authentication middleware to your web application pipeline.
        /// </summary>
        /// <param name="app">The IAppBuilder passed to your configuration method</param>
        /// <param name="cookieOptions">An options class that controls the middleware behavior</param>
        /// <returns>The original app parameter</returns>
        public static IAppBuilder UseMixedAuth(this IAppBuilder app, CookieAuthenticationOptions cookieOptions)
        {
            return app.UseMixedAuth(new MixedAuthOptions(), cookieOptions);
        }

    }
}
