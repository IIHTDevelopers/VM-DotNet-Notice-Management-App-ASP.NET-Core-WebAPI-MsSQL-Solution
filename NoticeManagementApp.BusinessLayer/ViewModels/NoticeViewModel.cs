using System;
using System.Collections.Generic;
using System.Text;

namespace NoticeManagementApp.BusinessLayer.ViewModels
{
    public class NoticeViewModel
    {
        public int NoticeId { get; set; }
        public int UserId { get; set; }
        public string NoticeText { get; set; }
        public int Rating { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
