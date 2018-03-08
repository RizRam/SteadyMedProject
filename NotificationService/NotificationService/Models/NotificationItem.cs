using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Models
{
    public class NotificationItem
    {
        //// Constructor
        //public NotificationItem(int recipientID, string messageBody)
        //{
        //    CreatedDate = DateTime.Now;
        //    RecipientID = recipientID;
        //    MessageBody = messageBody;
        //    IsSent = false;
        //}

        // Time stamp of when notification record was created.
        public DateTime CreatedDate { get; set; }

        // The AccountID of message recipient.
        public int RecipientID { get; set; }

        // Body of the message to be sent.
        public string MessageBody { get; set; }

        // Indicates if user has seen this message
        public bool IsSent { get; set; }
    }
}
