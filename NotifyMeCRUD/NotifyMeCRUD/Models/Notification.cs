using NotifyMeCRUD.ServiceErrors;
using ErrorOr;
using NotifyMeCRUD.Contracts.NotifyMe;

namespace NotifyMeCRUD.Models;

public class Notification
{
    public const int NameMinLength = 3;
    public const int NameMaxLength = 50;
    public const int DescriptionMinLength = 50;
    public const int DescriptionMaxLength = 100;

    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> AdditionalRequest { get; }

    public static ErrorOr<Notification> Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        List<string> additionalRequest,
        Guid? id = null)
    {

        List<Error> errors = new();
        //enforce invariants
        if (name.Length is < NameMinLength or > NameMaxLength)
        {
            errors.Add(Errors.Notification.InvalidName);
        }

        if (description.Length is < DescriptionMinLength or > DescriptionMaxLength)
        {
            errors.Add(Errors.Notification.InvalidDescription);
        }

        if (errors.Any())
            return errors;

        return new Notification(
            id ?? Guid.NewGuid(),
            name,
            description,
            startDateTime,
            endDateTime,
            DateTime.UtcNow,
            additionalRequest
        );
    }

     public static ErrorOr<Notification> From(CreateNotificationRequest request)
    {
        return Create(request.Name,
             request.Description,
             request.StartDateTime,
             request.EndDateTime,
             request.AdditionalRequest);
    }

    public static ErrorOr<Notification> From(Guid id, CreateNotificationRequest request)
    {
        return Create(request.Name,
             request.Description,
             request.StartDateTime,
             request.EndDateTime,
             request.AdditionalRequest,
             id);
    }

    private Notification(Guid id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime lastModifiedDateTime,
        List<string> additionalRequest)
    {
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = DateTime.UtcNow;
        AdditionalRequest = additionalRequest;
    }
}