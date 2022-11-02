using ErrorOr;

namespace NotifyMeCRUD.ServiceErrors;

public partial class Errors
{
    public static class Notification
    {
        public static Error NotFound => Error.NotFound(
            "Notification.NotFound",
            "Notification is not found"
        );

        public static Error InvalidName => Error.Validation(
            "Notification.InvalidName",
            $"Notification name must be at least {Models.Notification.NameMinLength} characters long and at most {Models.Notification.NameMaxLength} characters."
        );

           public static Error InvalidDescription => Error.Validation(
            "Notification.InvalidDescription",
            $"Notification description must be at least {Models.Notification.DescriptionMinLength} characters long and at most {Models.Notification.DescriptionMaxLength} characters."
        );
    }
}