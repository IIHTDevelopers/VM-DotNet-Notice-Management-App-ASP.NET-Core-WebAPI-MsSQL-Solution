

using Moq;
using NoticeManagementApp.BusinessLayer.Services.Repository;
using NoticeManagementApp.BusinessLayer.Services;
using NoticeManagementApp.BusinessLayer.ViewModels;
using NoticeManagementApp.DataLayer;
using NoticeManagementApp.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using NoticeManagementApp.BusinessLayer.Interfaces;

namespace NoticeManagementApp.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly NoticeManagementAppDbContext _dbContext;

        private readonly INoticeManagementService  _noticeService;
        public readonly Mock<INoticeManagementRepository> noticeservice = new Mock<INoticeManagementRepository>();

        private readonly Notice _notice;
            
        private readonly NoticeViewModel _noticeViewModel;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
             _noticeService = new NoticeManagementService(noticeservice.Object);

            _output = output;

            _notice = new Notice
            {
                NoticeId = 1,
                NoticeText = "Notice",
                SubmissionDate = DateTime.Now,
                Rating = 2,
                UserId = 1
            };

            _noticeViewModel = new NoticeViewModel
            {
                NoticeId = 1,
                NoticeText = "Notice",
                SubmissionDate = DateTime.Now,
                Rating = 2,
                UserId = 1
            };
        }
    

        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidNoticeIdIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                noticeservice.Setup(repo => repo.CreateNotice(_notice)).ReturnsAsync(_notice);
                var result = await  _noticeService.CreateNotice(_notice);
                if (result != null || result.NoticeId !=0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidNoticeRatingIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                noticeservice.Setup(repo => repo.CreateNotice(_notice)).ReturnsAsync(_notice);
                var result = await _noticeService.CreateNotice(_notice);
                if (result != null || result.Rating != 0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}