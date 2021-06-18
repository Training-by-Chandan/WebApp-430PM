using School.Web.Models;
using School.Web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using http = System.Web.Http;
using System.Web.Mvc;

namespace School.Web.API
{
    public class NotificationController : http.ApiController
    {
        private NotificationService notification = new NotificationService();

        [http.HttpGet]
        public List<Notification> GetUnreadNotification(string userId)
        {
            return notification.GetUnreadNotification(userId);
        }

        [http.HttpGet]
        public bool ReadNotification(Guid notificationId)
        {
            return notification.ReadNotification(notificationId);
        }
    }
}