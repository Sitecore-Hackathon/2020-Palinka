using Hackathon.Foundation.ORM.Models;
using Glass.Mapper.Sc.Fields;
using System.Collections;
using System.Collections.Generic;

namespace Hackathon.Feature.StandardContent.Models
{
    public interface ITestimonialSource : IGlassBase
    {
       IEnumerable<ITestimonial> Testimonials { get; set; }
    }
}
