using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Front_End_Assesment.Models;
using Front_End_Assesment.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Front_End_Assesment.Message_Handlers;

namespace Front_End_Assesment.MessageHandlers
{
    public class JWTAuthHandler : System.Web.Http.Filters.ActionFilterAttribute
    {
        //  private readonly IHttpContextAccessor _httpContextAccessor;
        private IConfiguration _config { get; set; }

        //public JWTAuthHandler(IConfiguration configuration)
        //{
        // //   _httpContextAccessor = httpContextAccessor;
        //    _config = configuration;
        //}
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            bool validKey = false;

            //   IEnumerable<string> requestHeaders;
            _config = actionContext.Request.GetDependencyScope().GetService(typeof(IConfiguration)) as IConfiguration;
            if (actionContext.Request.Headers.Authorization.Scheme != "Bearer")
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Please user User Bearer Scheme before the token");
            }
            else if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "No valid Token in the authorization header");
            }
            else
            {
                //  var tokencheck = actionContext.Request.Headers.TryGetValues("token", out requestHeaders);
                //  var usercheck = actionContext.Request.Headers.TryGetValues("username", out requestHeaders);
                //if (tokencheck && usercheck)
                //{
                // var username = actionContext.Request.Headers.GetValues("username").FirstOrDefault();

                // using (var db = new AuthDBContext(_config))
                // {
                var token = new TokenManager(_config).ValidateToken(actionContext.Request.Headers.Authorization.ToString());
                if (token == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Token Expired or Invalid");
                }
                else
                {

                    //var decodedauth = Encryptor.base64Decode(actionContext.Request.Headers.Authorization.Parameter.ToString());
                    //string username = decodedauth.Substring(0, decodedauth.IndexOf(":"));
                    //string password = decodedauth.Substring(decodedauth.IndexOf(":") + 1);
                    if (token == _config.GetSection("APIKEY").Value.ToString())
                    {

                        if (token != null)
                        {
                            validKey = true;

                            HttpContext a = null;
                            GenericIdentity identity = new GenericIdentity(token.ToString());
                            Thread.CurrentPrincipal = new GenericPrincipal(identity, new string[] { token.ToString() });

                            a.User = new GenericPrincipal(new GenericIdentity(token.ToString()), null);
                            //  actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, "Access Granted");



                        }
                        else
                        {
                            actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Token Expired or Invalid");

                        }
                    }
                }
                //}
                //else
                //{
                //    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, "Invalid Token or Username");

                //}



            }
            base.OnActionExecuting(actionContext);
        }
    }
}