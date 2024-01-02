
using Moq;
using NoticeManagementApp.BusinessLayer.Services;
using NoticeManagementApp.BusinessLayer.Services.Repository;
using NoticeManagementApp.BusinessLayer.ViewModels;
using NoticeManagementApp.DataLayer;
using NoticeManagementApp.Entities;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using NoticeManagementApp.BusinessLayer.Interfaces;

namespace NoticeManagementApp.Tests.TestCases
{
     public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly NoticeManagementAppDbContext _dbContext;

        private readonly INoticeManagementService  _noticeService;
        public readonly Mock<INoticeManagementRepository> noticeservice= new Mock<INoticeManagementRepository >();

        private readonly Notice _notice;
        private readonly NoticeViewModel _noticeViewModel;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
             _noticeService = new NoticeManagementService(noticeservice.Object);
           
            _output = output;

            _notice = new Notice
            {
                NoticeId = 1,
                NoticeText="Notice",
                SubmissionDate=DateTime.Now,
                Rating=2,
                UserId=1
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
        public async Task<bool> Testfor_Create_Notice()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                noticeservice.Setup(repos => repos.CreateNotice(_notice)).ReturnsAsync(_notice);
                var result = await  _noticeService.CreateNotice(_notice);
                //Assertion
                if (result != null)
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
        public async Task<bool> Testfor_Update_Notice()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
           
            //Action
            try
            {
                noticeservice.Setup(repos => repos.UpdateNotice(_noticeViewModel)).ReturnsAsync(_notice); 
                var result = await  _noticeService.UpdateNotice(_noticeViewModel);
                if (result != null)
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
        public async Task<bool> Testfor_GetNoticeById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                noticeservice.Setup(repos => repos.GetNoticeById(id)).ReturnsAsync(_notice);
                var result = await  _noticeService.GetNoticeById(id);
                //Assertion
                if (result != null)
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
        public async Task<bool> Testfor_DeleteNoticeById()
        {
            //Arrange
            var res = false;
            int id = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                noticeservice.Setup(repos => repos.DeleteNoticeById(id)).ReturnsAsync(response);
                var result = await  _noticeService.DeleteNoticeById(id);
                //Assertion
                if (result != null)
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