namespace Hackathon.Feature.Teams.Forms
{
    using Hackathon.Feature.Teams.Repositories;
    using Sitecore.DependencyInjection;
    using Sitecore.Diagnostics;
    using Sitecore.ExperienceForms.Models;
    using Sitecore.ExperienceForms.Processing;
    using Sitecore.ExperienceForms.Processing.Actions;
    using System;
    using System.Linq;

    /// <summary>
    /// Executes a submit action for logging the form submit status.
    /// </summary>
    /// <seealso cref="Sitecore.ExperienceForms.Processing.Actions.SubmitActionBase{TParametersData}" />
    public class TeamSubmitNotification : SubmitActionBase<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogSubmit"/> class.
        /// </summary>
        /// <param name="submitActionData">The submit action data.</param>
        public TeamSubmitNotification(ISubmitActionData submitActionData) : base(submitActionData)
        {
        }

        /// <summary>
        /// Tries to convert the specified <paramref name="value" /> to an instance of the specified target type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="target">The target object.</param>
        /// <returns>
        /// true if <paramref name="value" /> was converted successfully; otherwise, false.
        /// </returns>
        protected override bool TryParse(string value, out string target)
        {
            target = string.Empty;
            return true;
        }

        /// <summary>
        /// Executes the action with the specified <paramref name="data" />.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="formSubmitContext">The form submit context.</param>
        /// <returns>
        ///   <c>true</c> if the action is executed correctly; otherwise <c>false</c>
        /// </returns>
        protected override bool Execute(string data, FormSubmitContext formSubmitContext)
        {
            Assert.ArgumentNotNull(formSubmitContext, nameof(formSubmitContext));

            if (!formSubmitContext.HasErrors)
            {
                var repository = ServiceLocator.ServiceProvider.GetService(typeof(ITeamsRepository)) as ITeamsRepository;
                var settings = repository.GetSubmitionSettings();
                if (settings != null && settings.EmailNotification)
                {
                    try
                    {
                        Sitecore.MainUtil.SendMail(
                            new System.Net.Mail.MailMessage(
                                settings.EmailFrom,
                                settings.EmailTo,
                                settings.EmailSubject,
                                settings.EmailMessage
                                ));
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Form {formSubmitContext.FormId} email notification failed.", ex, this);
                    }
                }
            }
            else
            {
                Log.Error($"Form {formSubmitContext.FormId} submitted with errors: {string.Join(", ", formSubmitContext.Errors.Select(t => t.ErrorMessage))}.", this);
                return false;
            }

            return true;
        }
    }
}
