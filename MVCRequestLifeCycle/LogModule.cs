using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCRequestLifeCycle
{
    public class LogModule : IHttpModule
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            //throw new NotImplementedException();
        }
    }
}