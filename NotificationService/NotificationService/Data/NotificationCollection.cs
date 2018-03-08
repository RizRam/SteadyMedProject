using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationService.Models;

namespace NotificationService.Data
{
    /// <summary>
    /// Abstract data type to hold all NotificationItem objects. This implementation 
    /// used for testing only. Actual implementation will utilize persistent data 
    /// storage and maintain log of sent notifications.
    /// </summary>
    public class NotificationCollection
    {
        // Stores all NotificationItems sent through NotificationService
        private Dictionary<int, List<NotificationItem>> _notifications;

        /// <summary>
        /// Constructor
        /// </summary>
        public NotificationCollection()
        {
            _notifications = new Dictionary<int, List<NotificationItem>>();
        }

        /// <summary>
        /// Checks to see if NotificationCollection has 
        /// NotificationItems that need to be sent.
        /// </summary>
        /// <returns>True if yes. False if no.</returns>
        public bool HasNotifications()
        {
            return _notifications.Count() > 0 ? true : false;
        }

        /// <summary>
        /// Add new NotificationItem to NotificationCollection to be sent.
        /// </summary>
        /// <returns>True if successful. False if unsuccessful.</returns>
        public bool AddNotification(NotificationItem notification)
        {
            if (notification == null)
            {
                return false;
            }

            if (!_notifications.ContainsKey(notification.RecipientID))
            {
                _notifications.Add(notification.RecipientID, new List<NotificationItem>());
            }
            _notifications[notification.RecipientID].Add(notification);
            return true;
        }
        //public bool AddNotification(int recipientId, string messageBody)
        //{
        //    if (recipientId < 0 || messageBody == null)
        //    {
        //        return false;
        //    }

        //    if (!_notifications.ContainsKey(recipientId))
        //    {
        //        _notifications.Add(recipientId, new List<NotificationItem>());
        //    }
        //    _notifications[recipientId].Add(new NotificationItem(recipientId, messageBody));
        //    return true;
        //}

        /// <summary>
        /// Check the messages currently waiting in queue to be sent.
        /// </summary>
        /// <returns>List of NotificationItems</returns>
        public List<NotificationItem> GetUnsentNotifications()
        {
            List<NotificationItem> result = new List<NotificationItem>();

            foreach (var current in _notifications.Values)
            {
                var items = (from i in current
                            where i.IsSent == false
                            select i).ToList();

                result.AddRange(items);
            }

            return result;
        }

        /// <summary>
        /// Check the messages currently waiting in queue to be sent
        /// for parameter RecipientId
        /// </summary>
        /// <param name="recipientId">Profile ID for desired messages.</param>
        /// <returns>List of NotificationItems</returns>
        public List<NotificationItem> GetUnsentNotificationsById(int recipientId)
        {
            List<NotificationItem> result = new List<NotificationItem>();

            if (_notifications.ContainsKey(recipientId))
            {
                foreach (var item in _notifications[recipientId])
                {
                    if (!item.IsSent)
                    {
                        result.Add(item);
                        item.IsSent = true;
                    }
                }
            }

            return result;
        }
        
    }
}
