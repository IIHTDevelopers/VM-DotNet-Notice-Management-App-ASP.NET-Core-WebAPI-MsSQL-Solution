using Microsoft.EntityFrameworkCore;
using NoticeManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoticeManagementApp.DataLayer
{
    public class NoticeManagementAppDbContext : DbContext
    {
        public NoticeManagementAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Notice> Notices { get; set; }
    }

}