using FluentValidation;
using NotifyMeCRUD.Contracts.Notification.Common;

namespace NotifyMeCRUD.Validation;

public class NotificationDetailsValidator : AbstractValidator<NotificationDetails>{
    public NotificationDetailsValidator(){
        RuleFor(m => m.Name).NotEmpty();
        RuleFor(m => m.Description).NotEmpty();
        RuleFor(m => m.StartDateTime).NotEmpty();
        RuleFor(m => m.EndDateTime).NotEmpty();
    }
}