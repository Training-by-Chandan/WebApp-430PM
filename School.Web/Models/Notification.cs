using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School.Web.Models
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public NotificationType Type { get; set; }
        public string UserId { get; set; }
        public NotificationStatus Status { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }

    public enum NotificationStatus
    {
        Sent,
        Delivered,
        Read
    }

    public enum NotificationType
    {
        Info,
        Warning,
        Danger
    }
}