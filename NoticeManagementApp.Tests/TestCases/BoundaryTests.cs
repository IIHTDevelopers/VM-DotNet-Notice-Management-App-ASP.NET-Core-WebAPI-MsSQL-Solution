
using Moq;
using NoticeManagementApp.BusinessLayer.Interfaces;
using NoticeManagementApp.BusinessLayer.Services.Repository;
using NoticeManagementApp.BusinessLayer.Services;
using NoticeManagementApp.BusinessLayer.ViewModels;
using NoticeManagementApp.DataLayer;
using NoticeManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace NoticeManagementApp.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly NoticeManagementAppDbContext _dbContext;

        private readonly INoticeManagementService  _noticeService;
        public readonly Mock<INoticeManagementRepository> noticeservice = new Mock<INoticeManagementRepository>();

        private readonly Notice _notice;
        private readonly NoticeViewModel _noticeViewModel;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_Notice_Notice_NotEmpty()
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
                var actualLength = _notice.NoticeText.ToString().Length;
                if (result.NoticeText.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_Notice_Rating_NotEmpty()
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
                var actualLength = _notice.Rating.ToString().Length;
                if (result.Rating.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_Notice_Date_NotEmpty()
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
                var actualLength = _notice.SubmissionDate.ToString().Length;
                if (result.SubmissionDate.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_NoticeId_NotEmpty()
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
                var actualLength = _notice.NoticeId.ToString().Length;
                if (result.NoticeId.ToString().Length == actualLength)
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