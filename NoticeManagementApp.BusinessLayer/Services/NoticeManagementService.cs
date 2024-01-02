using NoticeManagementApp.BusinessLayer.Interfaces;
using NoticeManagementApp.BusinessLayer.Services.Repository;
using NoticeManagementApp.BusinessLayer.ViewModels;
using NoticeManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoticeManagementApp.BusinessLayer.Services
{
    public class NoticeManagementService : INoticeManagementService
    {
        private readonly INoticeManagementRepository _repo;

        public NoticeManagementService(INoticeManagementRepository repo)
        {
            _repo = repo;
        }

        public async Task<Notice> CreateNotice(Notice employeeNotice)
        {
            return await _repo.CreateNotice(employeeNotice);
        }

        public async Task<bool> DeleteNoticeById(long id)
        {
            return await _repo.DeleteNoticeById(id);
        }

        public List<Notice> GetAllNotices()
        {
            return  _repo.GetAllNotices();
        }

        public async Task<Notice> GetNoticeById(long id)
        {
            return await _repo.GetNoticeById(id);
        }

        public async Task<Notice> UpdateNotice(NoticeViewModel model)
        {
           return await _repo.UpdateNotice(model);
        }
    }
}
