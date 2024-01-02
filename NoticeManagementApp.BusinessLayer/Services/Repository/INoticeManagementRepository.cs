using NoticeManagementApp.BusinessLayer.ViewModels;
using NoticeManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoticeManagementApp.BusinessLayer.Services.Repository
{
    public interface INoticeManagementRepository
    {
        List<Notice> GetAllNotices();
        Task<Notice> CreateNotice(Notice notice);
        Task<Notice> GetNoticeById(long id);
        Task<bool> DeleteNoticeById(long id);
        Task<Notice> UpdateNotice(NoticeViewModel model);
    }
}
