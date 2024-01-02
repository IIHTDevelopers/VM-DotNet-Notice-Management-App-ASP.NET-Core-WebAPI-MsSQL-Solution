using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoticeManagementApp.BusinessLayer.Interfaces;
using NoticeManagementApp.BusinessLayer.ViewModels;
using NoticeManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementApp.Entities;

namespace NoticeManagementApp.Controllers
{
    [ApiController]
    public class NoticeManagementController : ControllerBase
    {
        private readonly INoticeManagementService  _noticeService;
        public NoticeManagementController(INoticeManagementService noticeservice)
        {
             _noticeService = noticeservice;
        }

        [HttpPost]
        [Route("create-notice")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateNotice([FromBody] Notice model)
        {
            var NoticeExists = await  _noticeService.GetNoticeById(model.NoticeId);
            if (NoticeExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Notice already exists!" });
            var result = await  _noticeService.CreateNotice(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Notice creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Notice created successfully!" });

        }


        [HttpPut]
        [Route("update-notice")]
        public async Task<IActionResult> UpdateNotice([FromBody] NoticeViewModel model)
        {
            var Notice = await  _noticeService.UpdateNotice(model);
            if (Notice == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Notice With Id = {model.NoticeId} cannot be found" });
            }
            else
            {
                var result = await  _noticeService.UpdateNotice(model);
                return Ok(new Response { Status = "Success", Message = "Notice updated successfully!" });
            }
        }

      
        [HttpDelete]
        [Route("delete-notice")]
        public async Task<IActionResult> DeleteNotice(long id)
        {
            var Notice = await  _noticeService.GetNoticeById(id);
            if (Notice == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Notice With Id = {id} cannot be found" });
            }
            else
            {
                var result = await  _noticeService.DeleteNoticeById(id);
                return Ok(new Response { Status = "Success", Message = "Notice deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-notice-by-id")]
        public async Task<IActionResult> GetNoticeById(long id)
        {
            var Notice = await  _noticeService.GetNoticeById(id);
            if (Notice == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Notice With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(Notice);
            }
        }

        [HttpGet]
        [Route("get-all-notices")]
        public async Task<IEnumerable<Notice>> GetAllNotices()
        {
            return   _noticeService.GetAllNotices();
        }
    }
}
