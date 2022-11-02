using Microsoft.AspNetCore.Mvc;
using NotifyMeCRUD.Contracts.NotifyMe;
using NotifyMeCRUD.Models;
using NotifyMeCRUD.Services.Notifications;
using NotifyMeCRUD.ServiceErrors;

namespace NotifyMeCRUD.Controllers;


public class NotificationsController : ApiController
{
    private readonly INotificationService _notificationService;

    public NotificationsController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpPost]
    public IActionResult CreateNotification(CreateNotificationRequest request)
    {
        var requestToNotificationResult = Notification.From(request);

        if (requestToNotificationResult.IsError)
        {
            return Problem(requestToNotificationResult.Errors);
        }

        var notification = requestToNotificationResult.Value;
        //TODO: save breakfast to database
        var createNotificationResult = _notificationService.CreateNotification(notification);

        return createNotificationResult.Match(
            create => CreatedAtGetNotification(notification),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetNotification(Guid id)
    {
        var getNotificationResult = _notificationService.GetNotification(id);

        return getNotificationResult.Match(
            notification => Ok(MapNotificationResponse(notification)),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertNotification(Guid id, CreateNotificationRequest request)
    {
        var requestToNotificationResult = Notification.From(id, request);


        if (requestToNotificationResult.IsError)
        {
            return Problem(requestToNotificationResult.Errors);
        }
        var notification = requestToNotificationResult.Value;

        //call service
        var upsertNotificationResult = _notificationService.UpsertNotification(notification);

        return upsertNotificationResult.Match(
          upsert => upsert.isNewlyCreated ? CreatedAtGetNotification(notification) : NoContent(),
          errors => Problem(errors)
      );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteNotification(Guid id)
    {
        var deleteNotificationResult = _notificationService.DeleteNotification(id);
        if (deleteNotificationResult.IsError)
        {
            return Problem(deleteNotificationResult.Errors);
        }

        return deleteNotificationResult.Match(
            delete => NoContent(),
            errors => Problem(errors)
        );
    }

    private static NotificationResponse MapNotificationResponse(Notification notification)
    {
        return new NotificationResponse(notification.Id,
        notification.Name,
        notification.Description,
        notification.StartDateTime,
        notification.EndDateTime,
        notification.LastModifiedDateTime,
        notification.AdditionalRequest);
    }

    private IActionResult CreatedAtGetNotification(Notification notification)
    {
        return CreatedAtAction(
            actionName: nameof(GetNotification),
            routeValues: new { id = notification.Id },
            value: MapNotificationResponse(notification));
    }
}
