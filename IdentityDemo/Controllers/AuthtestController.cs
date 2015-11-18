using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityDemo.Controllers {
    [Authorize]
    public class AuthtestController : Controller {

        [Authorize(Roles = "KeeperOfSecrets")]
        public ContentResult Secret() {
            return Content("Detta är supersuperhemligt");
        }

        public ContentResult Hidden() {
            return Content("Detta är lite småhemligt");
        }

        [AllowAnonymous]
        public ContentResult Open() {
            return Content("Detta är öppen information");
        }
    }
}