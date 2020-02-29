namespace Hackathon.Feature.StandardContent.ViewModels
{
    using Hackathon.Feature.StandardContent.Models;
    using System.Collections.Generic;

    public class FaqListViewModel
    {
        public IEnumerable<IFaq> Faqs { get; set; }
    }
}
