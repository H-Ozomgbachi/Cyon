﻿namespace Cyon.Domain.Models.Announcement
{
    public class AnnouncementModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsActive { get; set; }
    }
}