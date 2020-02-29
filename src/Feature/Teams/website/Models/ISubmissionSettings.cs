namespace Hackathon.Feature.Teams.Models
{
    using Hackathon.Foundation.ORM.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The submission settings
    /// </summary>
    public interface ISubmissionSettings : IGlassBase
    {
        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }

        IGlassBase TargetFolder { get; set; }

        DateTime EventDate { get; set; }

        bool EmailNotification { get; set; }

        string EmailFrom { get; set; }

        string EmailTo { get; set; }

        string EmailMessage { get; set; }

        string EmailSubject { get; set; }
    }
}
