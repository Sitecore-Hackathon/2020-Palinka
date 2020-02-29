using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Hackathon.Feature.Teams.Repositories;
using Sitecore.DependencyInjection;
using Sitecore.ExperienceForms.Mvc.Models.Fields;
using Sitecore.ExperienceForms.Mvc.Models.Validation;

namespace Hackathon.Feature.Teams.Forms
{
    public class TeamSubmitValidation : ValidationElement<string>
    {
        public TeamSubmitValidation(ValidationDataModel validationItem) : base(validationItem)
        {
        }

        public override IEnumerable<ModelClientValidationRule> ClientValidationRules
        {
            get
            {
                return new ModelClientValidationRule[0];
            }
        }

        public string Title { get; set; }

        public override ValidationResult Validate(object value)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var stringValue = (string)value;
            if (!string.IsNullOrWhiteSpace(stringValue))
            {
                var repository = ServiceLocator.ServiceProvider.GetService(typeof(ITeamsRepository)) as ITeamsRepository;
                var settings = repository.GetSubmitionSettings();
                if (settings == null || settings.TargetFolder == null)
                {
                    return ValidationResult.Success;
                }

                if (repository.Exists(settings.TargetFolder.Id, stringValue))
                {
                    return new ValidationResult(FormatMessage(Title));
                }
            }

            return ValidationResult.Success;
        }

        public override void Initialize(object validationModel)
        {
            base.Initialize(validationModel);

            var obj = validationModel as StringInputViewModel;
            if (obj != null)
            {
                Title = obj.Title;
            }
        }
    }
}
