using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ATT_Shape3.Controllers
{
    public class SiteController : BaseController
    {
        protected string _entityId = null;

        public override string EntityId
        {
            get
            {
                return _entityId;
            }
        }
    }
}
