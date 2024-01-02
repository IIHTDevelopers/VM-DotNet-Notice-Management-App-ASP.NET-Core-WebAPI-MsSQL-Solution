using Microsoft.EntityFrameworkCore;
using NoticeManagementApp.BusinessLayer.ViewModels;
using NoticeManagementApp.DataLayer;
using NoticeManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NoticeManagementApp.BusinessLayer.Services.Repository
{
    public class NoticeManagementRepository : INoticeManagementRepository
    {
        private readonly NoticeManagementAppDbContext _dbContext;
        public NoticeManagementRepository(NoticeManagementAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Notice> CreateNotice(Notice NoticeModel)
        {
            try
            {
                var result = await _dbContext.Notices.AddAsync(NoticeModel);
                await _dbContext.SaveChangesAsync();
                return NoticeModel;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteNoticeById(long id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Notices.Single(a => a.NoticeId== id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Notice> GetAllNotices()
        {
            try
            {
                var result = _dbContext.Notices.
                OrderByDescending(x => x.NoticeId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Notice> GetNoticeById(long id)
        {
            try
            {
                return await _dbContext.Notices.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       
        public async Task<Notice> UpdateNotice(NoticeViewModel model)
        {
            var Notice = await _dbContext.Notices.FindAsync(model.NoticeId);
            try
            {

                _dbContext.Notices.Update(Notice);
                await _dbContext.SaveChangesAsync();
                return Notice;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}