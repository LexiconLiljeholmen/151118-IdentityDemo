using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityDemo.Controllers {
    [Authorize(Roles = "KeeperOfSecrets")]
    public class AuthtestController : Controller {

       
        public ContentResult Secret() {
            return Content("Detta är supersuperhemligt");
        }

        //public ContentResult Hidden() {
        //    return Content("Detta är lite småhemligt");
        //}

        [AllowAnonymous]
        public ContentResult Open() {
            return Content("Detta är öppen information");
        }
    }
}