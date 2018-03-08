using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Models;
using NotificationService.Data;

namespace NotificationService.Controllers
{
    [Produces("application/json")]
    [Route("api/notification")]
    public class NotificationController : Controller
    {

        NotificationCollection _notifications;

        // Constructor
        public NotificationController(NotificationCollection _notificationCollection)
        {
            _notifications = _notificationCollection;
        }

        // GET: api/notification
        [HttpGet]
        public IEnumerable<NotificationItem> Get()
        {
            return _notifications.GetUnsentNotifications();
        }

        // GET: api/notification/2
        [HttpGet("{id}")]
        public IEnumerable<NotificationItem> Get(int id)
        {
            return _notifications.GetUnsentNotificationsById(id);
        }

        // POST: api/notification
        [HttpPost]
        public IActionResult Post([FromBody] NotificationItem message)
        {
            if (message == null) return BadRequest();

            if (!_notifications.AddNotification(message)) return BadRequest();
            
            return CreatedAtRoute("notification", new { id = message.RecipientID }, message);
        }
    }
}
