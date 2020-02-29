namespace Hackathon.Feature.Navigation.Models
{
    using Glass.Mapper.Sc.Fields;

    public interface ISocialLink
    {
        Link Link { get; set; }

        string SocialType { get; set; }
    }
}
