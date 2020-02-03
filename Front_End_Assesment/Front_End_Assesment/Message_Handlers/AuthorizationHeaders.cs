using Front_End_Assesment.Utilities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace Front_End_Assesment.Message_Handlers
{
    public class AuthorizationHeaders
    {
        public class AuthorizationHeader : System.Web.Http.Filters.ActionFilterAttribute
        {
            //  private readonly IHttpContextAccessor _httpContextAccessor;
            private IConfiguration _config { get; set; }
            private IDistributedCache _cache { get; set; }
            // StringValues requestHeaders;

            public override void OnActionExecuting(HttpActionContext actionContext)

            {
                // _config = actionContext.HttpContext.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration;
                _config = actionContext.Request.GetDependencyScope().GetService(typeof(IConfiguration)) as IConfiguration;
                _cache = actionContext.Request.GetDependencyScope().GetService(typeof(IDistributedCache)) as IDistributedCache;
                //  _httpContextAccessor = actionContext.HttpContext.RequestServices.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
                // _config = actionContext.Request.GetDependencyScope().GetService(typeof(IConfiguration)) as IConfiguration;
                if (actionContext.Request.Headers.Authorization.Scheme != "Basic")
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Please Use Basic authorization scheme");
                }
                else if (actionContext.Request.Headers.Authorization == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "No valid Basic Authorization header");
                }

                else
                {
                    var decodedauth = Encryptor.base64Decode(actionContext.Request.Headers.Authorization.Parameter.ToString());

                    string username = decodedauth.Substring(0, decodedauth.IndexOf(":"));
                    var usercheck = _cache.GetString(username);
                    if (!string.IsNullOrEmpty(usercheck))
                    {
                        if (usercheck != actionContext.Request.Headers.Authorization.Parameter.ToString())
                            actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Invalid authorization header");
                        else
                        {
                            var identity = new ClaimsIdentity();
                            identity.AddClaim(new Claim(ClaimTypes.Name, username));
                            Thread.CurrentPrincipal = new ClaimsPrincipal(identity);
                            actionContext.Response.StatusCode = HttpStatusCode.OK;
                        }
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "User has not log in or invalid authorization header");
                    }
                    string password = decodedauth.Substring(decodedauth.IndexOf(":") + 1);
                }
                base.OnActionExecuting(actionContext);
            }
        }
    }
}
