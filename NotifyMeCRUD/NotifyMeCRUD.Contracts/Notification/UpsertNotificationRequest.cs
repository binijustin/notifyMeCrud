namespace NotifyMeCRUD.Contracts.NotifyMe;

public record UpsertNotificationRequest(
    Guid id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> AdditionalRequest);