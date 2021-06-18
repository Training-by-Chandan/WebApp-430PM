using School.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Web.Service
{
    public class NotificationService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Notification> GetUnreadNotification(string userid)
        {
            return db.Notification.Where(p => p.UserId == userid && p.Status == NotificationStatus.Delivered).ToList();
        }

        public bool ReadNotification(Guid notificationId)
        {
            var notification = db.Notification.Find(notificationId);
            notification.Status = NotificationStatus.Read;
            db.Entry(notification).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }
}