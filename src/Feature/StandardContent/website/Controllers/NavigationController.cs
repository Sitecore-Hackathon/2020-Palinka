using Sitecore.Mvc.Controllers;
using System.Web.Mvc;

namespace Hackathon.Feature.StandardContent.Controllers
{
    public class StandardContentController : SitecoreController
    {
        public ActionResult Text()
        {
            return new EmptyResult();
        }
    }
}
