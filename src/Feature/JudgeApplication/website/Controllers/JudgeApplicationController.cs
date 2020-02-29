
using Hackathon.Foundation.Content.Repositories;
using Sitecore.Mvc.Controllers;
using Sitecore.Services.Infrastructure.Web.Http;
using System.Linq;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Hackathon.Feature.JudgeApplication.Controllers
{
    [Authorize]
    [RoutePrefix("sitecore/api/ssc/judge")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class JudgeApplicationController : ServicesApiController
    {
        private readonly IContextRepository contextRepository;

        private readonly IContentRepository contentRepository;

        public JudgeApplicationController(IContextRepository contextRepository, IContentRepository contentRepository)
        {
            this.contextRepository = contextRepository;
            this.contentRepository = contentRepository;
        }

        [HttpGet]
        [Route("ok")]
        public string Ok(string id, string db)
        {
            return "Ok";
        }
    }
}
