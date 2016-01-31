using MVCRequestLifeCycle;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: PreApplicationStartMethod(typeof(MvcApplication), "RegisterModules")]

namespace MVCRequestLifeCycle
{
    /// <summary>
    /// Ref: http://www.dotnetcurry.com/aspnet/747/http-request-lifecycle-events-iis-pipeline-aspnet
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterModules()
        {
            HttpApplication.RegisterModule(typeof(LogModule));
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Debug.WriteLine("Application_Start!!!");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // The BeginRequest event signals the creation of any given new request
            Debug.WriteLine("1. Application_BeginRequest");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            /*
            1. ASP.NET has authenticated the current request
            2. We can subscribe to this event to perform custom authentication
            */
            Debug.WriteLine("2. Application_AuthenticateRequest");
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            /*
             1. The event is raised after the AuthenticateRequest event has occurred
             2. All the information available is accessible in the HttpContext.User
            */
            Debug.WriteLine("3. Application_PostAuthenticateRequest");
        }

        protected void Application_AuthorizeRequest(object sender, EventArgs e)
        {
            /*
            1. ASP.NET has authorized the current request
            2. We can subscribe to this event to perform custom authorization
            */
            Debug.WriteLine("4. Application_AuthorizeRequest");
        }

        protected void Application_PostAuthorizeRequest(object sender, EventArgs e)
        {
            // Occurs when the user for the current request has been authorized
            Debug.WriteLine("5. Application_PostAuthorizeRequest");
        }

        protected void Application_ResolveRequestCache(object sender, EventArgs e)
        {
            // let the caching modules serve requests from the cache, bypassing execution of the event handler and calling any EndRequest handlers
            Debug.WriteLine("6. Application_ResolveRequestCache, UrlRoutingModule started.");
        }

        protected void Application_PostResolveRequestCache(object sender, EventArgs e)
        {
            // the request can’t be served from the cache, and thus a HTTP handler is created here
            Debug.WriteLine("7. Application_PostResolveRequestCache");
        }

        protected void Application_MapRequestHandler(object sender, EventArgs e)
        {
            // the event is used by the ASP.NET infrastructure to determine the request handler for the current request
            Debug.WriteLine("8. Application_MapRequestHandler, MvcHandler initialized.");
        }

        protected void Application_PostMapRequestHandler(object sender, EventArgs e)
        {
            // Occurs when ASP.NET has mapped the current request to the appropriate HTTP handler
            Debug.WriteLine("9. Application_PostMapRequestHandler");
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            // Occurs when ASP.NET acquires the current state (for example, session state) that is associated with the current request
            Debug.WriteLine("10. Application_AcquireRequestState");
        }

        protected void Application_PostAcquireRequestState(object sender, EventArgs e)
        {
            // Occurs when the state information(for example, session state or application state) that is associated with the current request has been obtained
            Debug.WriteLine("11. Application_PostAcquireRequestState");
        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            // Occurs just before ASP.NET starts executing an event handler
            Debug.WriteLine("12. Application_PreRequestHandlerExecute");
        }

        protected void Application_ExecuteRequestHandler(object sender, EventArgs e)
        {
            // Event Handler generate response for the request
            Debug.WriteLine("13. Application_ExecuteRequestHandler. MVC generate response for the request");
        }

        protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            // Occurs when the ASP.NET event handler has finished generating the output
            Debug.WriteLine("14. Application_PreRequestHandlerExecute");
        }

        protected void Application_UpdateRequestCache(object sender, EventArgs e)
        {
            // let caching modules store responses that will be reused to serve identical requests from the cache
            Debug.WriteLine("15. Application_UpdateRequestCache");
        }

        protected void Application_PostUpdateRequestCache(object sender, EventArgs e)
        {
            // ASP.NET has completed processing code and the content of the cache is finalized
            Debug.WriteLine("16. Application_PostUpdateRequestCache");
        }

        protected void Application_LogRequest(object sender, EventArgs e)
        {
            /*
            1. Occurs just before ASP.NET performs any logging for the current request
            2. You can provide an event handler for the LogRequest event to provide custom logging for the request
            */
            Debug.WriteLine("17. Application_LogRequest");
        }

        protected void Application_PostLogRequest(object sender, EventArgs e)
        {
            // Occurs when request has been logged
            Debug.WriteLine("18. Application_PostLogRequest");
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            /*
            1. Occurs as the last event in the HTTP pipeline chain of execution when ASP.NET responds to a request. 
            2. In this event, you can compress or encrypt the response
            */
            Debug.WriteLine("19. Application_EndRequest");
        }

        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            /*
            Fired after EndRequest if buffering is turned on (by default). 
            Occurs just before ASP.NET sends HTTP headers to the client
            */
            Debug.WriteLine("20. Application_PreSendRequestHeaders");
        }

        protected void Application_PreSendRequestContent(object sender, EventArgs e)
        {
            // Occurs just before ASP.NET sends content to the client
            Debug.WriteLine("21. Application_PreSendRequestContent");
        }

        protected void Application_End()
        {
            Debug.WriteLine("Application_End!!!");
        }
    }
}
