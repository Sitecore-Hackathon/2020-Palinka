namespace Hackathon.Feature.Teams.Forms
{
    using Hackathon.Feature.Teams.Models;
    using Hackathon.Feature.Teams.Repositories;
    using Sitecore.DependencyInjection;
    using Sitecore.Diagnostics;
    using Sitecore.ExperienceForms.Models;
    using Sitecore.ExperienceForms.Processing;
    using Sitecore.ExperienceForms.Processing.Actions;
    using Sitecore.SecurityModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Executes a submit action for logging the form submit status.
    /// </summary>
    /// <seealso cref="Sitecore.ExperienceForms.Processing.Actions.SubmitActionBase{TParametersData}" />
    public class TeamSubmit : SubmitActionBase<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogSubmit"/> class.
        /// </summary>
        /// <param name="submitActionData">The submit action data.</param>
        public TeamSubmit(ISubmitActionData submitActionData) : base(submitActionData)
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
                if (repository != null)
                {
                    var settings = repository.GetSubmitionSettings();
                    if (settings == null || settings.TargetFolder == null)
                    {
                        Log.Warn($"Team submition is not configured.", this);
                        return false;
                    }

                    string name = GetFieldValueByName("TeamName", formSubmitContext.Fields);
                    string country = GetFieldValueByName("Country", formSubmitContext.Fields);
                    string email = GetFieldValueByName("Email", formSubmitContext.Fields);

                    List<TeamMember> teamMembers = new List<TeamMember>(3);
                    for (int i = 1; i <= 3; i++)
                    {
                        var teamMember = LoadTeamMember(formSubmitContext, i);
                        if (teamMember != null)
                        {
                            teamMembers.Add(teamMember);
                        }
                    }

                    using (new SecurityDisabler())
                    {
                        var targetId = settings.TargetFolder.Id;
                        var model = repository.Create(targetId, name, country, email, teamMembers);
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

        private TeamMember LoadTeamMember(FormSubmitContext formSubmitContext, int index)
        {
            string firstName = GetFieldValueByName($"FirstName{index}", formSubmitContext.Fields);
            string lastName = GetFieldValueByName($"LastName{index}", formSubmitContext.Fields);
            string twitter = GetFieldValueByName($"Twitter{index}", formSubmitContext.Fields);
            string linkedIn = GetFieldValueByName($"LinkedIn{index}", formSubmitContext.Fields);

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                return new TeamMember
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Twitter = twitter,
                    LinkedIn = linkedIn
                };
            }

            return null;
        }

        /// <summary>
        /// Gets the field by <paramref name="id" />.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fields">The fields.</param>
        /// <returns>The field with the specified <paramref name="id" />.</returns>
        private static IViewModel GetFieldById(Guid id, IList<IViewModel> fields)
        {
            return fields.FirstOrDefault(f => Guid.Parse(f.ItemId) == id);
        }

        /// <summary>
        /// Gets the field by <paramref name="id" />.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fields">The fields.</param>
        /// <returns>The field with the specified <paramref name="id" />.</returns>
        private static string GetFieldValueByName(Guid id, IList<IViewModel> fields)
        {
            var field = GetFieldById(id, fields);
            if (field != null)
            {
                return GetValue(field);
            }

            return null;
        }

        /// <summary>
        /// Gets the field by <paramref name="id" />.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fields">The fields.</param>
        /// <returns>The field with the specified <paramref name="id" />.</returns>
        private static IViewModel GetFieldByName(string name, IList<IViewModel> fields)
        {
            return fields.FirstOrDefault(f => f.Name == name);
        }

        /// <summary>
        /// Gets the <paramref name="field" /> value.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns>The field value.</returns>
        private static string GetValue(object field)
        {
            return field?.GetType().GetProperty("Value")?.GetValue(field, null)?.ToString() ?? string.Empty;
        }

        /// <summary>
        /// Gets the field by <paramref name="id" />.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fields">The fields.</param>
        /// <returns>The field with the specified <paramref name="id" />.</returns>
        private static string GetFieldValueByName(string name, IList<IViewModel> fields)
        {
            var field = GetFieldByName(name, fields);
            if (field != null)
            {
                return GetValue(field);
            }

            return null;
        }
    }
}
