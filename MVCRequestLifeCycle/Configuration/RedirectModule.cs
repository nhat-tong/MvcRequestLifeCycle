using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MVCRequestLifeCycle.Configuration
{
    public class RedirectModule : IHttpModule
    {
        private HttpApplication _context;
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            _context = context;
            // Occurs before Application_MapRequestHandler in Global.ascx
            context.MapRequestHandler += RedirectUrl_MapRequestHandler;
        }

        private void RedirectUrl_MapRequestHandler(object sender, EventArgs e)
        {
            RedirectSection section = (RedirectSection)WebConfigurationManager.GetWebApplicationSection("redirects");
            foreach(Redirect redirect in section.Redirects)
            {
                if(redirect.Old == _context.Request.RequestContext.HttpContext.Request.RawUrl)
                {
                    _context.Response.Redirect(redirect.New);
                }
            }
        }
    }
}