﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace LBC.Web.API.Controllers.Auth
{
    /// <summary>
    /// Handles google, facebook and microsoft authentication
    /// </summary>
    [Route("mobileauth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        const string callbackScheme = "xamarinessentials";

        [HttpGet("{scheme}")]
        public async Task Get([FromRoute]string scheme)
        {
            try
            {
                var auth = await Request.HttpContext.AuthenticateAsync(scheme);

                if (!auth.Succeeded
                    || auth?.Principal == null
                    || !auth.Principal.Identities.Any(id => id.IsAuthenticated)
                    || string.IsNullOrEmpty(auth.Properties.GetTokenValue("access_token")))
                {
                    // Not authenticated, challenge
                    await Request.HttpContext.ChallengeAsync(scheme);
                }
                else
                {
                    // Get parameters to send back to the callback
                    var qs = new Dictionary<string, string>
                    {
                        { "name", auth.Principal.Identity.Name ?? string.Empty },
                        { "access_token", auth.Properties.GetTokenValue("access_token") },
                        { "refresh_token", auth.Properties.GetTokenValue("refresh_token") ?? string.Empty },
                        { "expires", (auth.Properties.ExpiresUtc?.ToUnixTimeSeconds() ?? -1).ToString() }
                    };

                    // Build the result url
                    var url = callbackScheme + "://#" + string.Join(
                        "&",
                        qs.Where(kvp => !string.IsNullOrEmpty(kvp.Value) && kvp.Value != "-1")
                        .Select(kvp => $"{WebUtility.UrlEncode(kvp.Key)}={WebUtility.UrlEncode(kvp.Value)}"));

                    // Redirect to final url
                    Request.HttpContext.Response.Redirect(url);
                }
            }
            catch (Exception ex)
            {
                var qs = new Dictionary<string, string>
                    {
                        { "ex", ex.Message ?? string.Empty }
                    };

                // Build the result url
                var url = callbackScheme + "://#" + string.Join(
                    "&",
                    qs.Where(kvp => !string.IsNullOrEmpty(kvp.Value) && kvp.Value != "-1")
                    .Select(kvp => $"{WebUtility.UrlEncode(kvp.Key)}={WebUtility.UrlEncode(kvp.Value)}"));

                // Redirect to final url
                Request.HttpContext.Response.Redirect(url);

              
            }

           
        }
    }
}
