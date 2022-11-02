namespace NotifyMeCRUD.Contracts.NotifyMe;

public record CreateNotificationRequest(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> AdditionalRequest);