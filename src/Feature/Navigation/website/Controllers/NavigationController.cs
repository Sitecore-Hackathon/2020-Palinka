using Sitecore.Mvc.Controllers;
using System.Web.Mvc;

namespace Hackathon.Feature.Navigation.Controllers
{
    public class NavigationController : SitecoreController
    {
        public ActionResult TopNavigation()
        {
            return new EmptyResult();
        }

        public ActionResult FooterNavigation()
        {
            return new EmptyResult();
        }
    }
}
