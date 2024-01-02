using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System;

namespace NoticeManagementApp.Entities
{
    public class Notice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoticeId { get; set; }
        public int UserId { get; set; }
        public string NoticeText { get; set; }
        public int Rating { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
