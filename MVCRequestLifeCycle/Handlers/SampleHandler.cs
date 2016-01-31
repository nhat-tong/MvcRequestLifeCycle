using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCRequestLifeCycle.Handlers
{
    public class SampleHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("<p> Sample hanlder </p>");
        }
    }
}