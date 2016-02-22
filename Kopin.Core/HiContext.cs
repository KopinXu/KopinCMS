using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Kopin.Core
{
    public sealed class HiContext
    {
        private SiteSettings currentSettings;
        private HttpContext _httpContext;
        private HiContext(HttpContext context)
        {
            this._httpContext = context;
        }

        public HttpContext Context
        {
            get
            {
                return this._httpContext;
            }
        }
        public static HiContext Current
        {
            get
            {
                HttpContext current = HttpContext.Current;
                HiContext context = current.Items["Hishop_ContextStore"] as HiContext;
                if (context == null)
                {
                    if (current == null)
                    {
                        throw new Exception("No HiContext exists in the Current Application. AutoCreate fails since HttpContext.Current is not accessible.");
                    }
                    context = new HiContext(current);
                    SaveContextToStore(context);
                }
                return context;
            }
        }
        private static void SaveContextToStore(HiContext context)
        {
            context.Context.Items["Hishop_ContextStore"] = context;
        }
        public SiteSettings SiteSettings
        {
            get
            {
                if (this.currentSettings == null)
                {
                    this.currentSettings = SettingsManager.GetMasterSettings(true);
                }
                return this.currentSettings;
            }
        }


    }
}
