namespace Hackathon.Feature.StandardContent.Models
{
    using Glass.Mapper.Sc.Fields;
    using Hackathon.Foundation.ORM.Models;

    public interface ISponsor : IGlassBase
    {
        string Fullname { get; set; }
        Link Link { get; set; }
        Image SmallImage { get; set; }
        Image LargeImage { get; set; }
    }
}
