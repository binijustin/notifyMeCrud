using FluentValidation;
using NotifyMeCRUD.Contracts.NotifyMe;
using NotifyMeCRUD.Validation.CustomValidator;

namespace NotifyMeCRUD.Validation;

public class CreateNotificationRequestValidator : AbstractValidator<CreateNotificationRequest>
{
    public CreateNotificationRequestValidator()
    {
        // RuleFor(m=>m.Name).Length(2,10);
        ////USING CUSTOM VALIDATOR
        // RuleFor(m=>m.StartDateTime).AfterSunrise();
        // RuleForEach(m=>m.AdditionalRequest)
        // .Must(NotBeEmpty)
        // .WithMessage("Additional request should not be empty");

        RuleFor(m=>m.NotificationDetails).SetValidator(new NotificationDetailsValidator());
    }

    private bool NotBeEmpty(string request)
    {
        return !string.IsNullOrWhiteSpace(request);
    }
}