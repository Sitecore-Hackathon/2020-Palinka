namespace Hackathon.Feature.StandardContent.ViewModels
{
    using Hackathon.Feature.StandardContent.Models;
    using System.Collections.Generic;

    public class SponsorsViewModel
    {
        public IEnumerable<ISponsor> Sponsors { get; set; }
    }
}
