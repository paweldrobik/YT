using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Video.Abstract;
using Video.Service;
using YoutubeClient.Controllers;
using YoutubeClient.Models;

namespace TestYoutubeApp
{
    [TestClass]
    public class TestYoutube
    {
        [TestMethod]
        public void TestControllertReturnListOfTypeVideo()
        {
            var homeConrtoller = new HomeController(null, new YoutubeService());
            var result = homeConrtoller.Videos("trial bike").GetAwaiter().GetResult();
            var vResult = result as ViewResult;
            Assert.IsInstanceOfType(vResult.Model, typeof(List<Video.Model.Video>));
        }

        [TestMethod]
        public void TestControllertReturnFiveVideos()
        {
            var homeConrtoller = new HomeController(null, new YoutubeService());
            var result = homeConrtoller.Videos("trial bike").GetAwaiter().GetResult();
            var vResult = result as ViewResult;

            Assert.IsTrue((vResult.Model as List<Video.Model.Video>).Count > 1);
        }


        [TestMethod]
        public void TestControllertReturnFiveVideosMockVideoService()
        {
            var mockService = new Mock<IVideoService>();
            mockService.Setup(s => s.GetVideos(It.IsAny<string>())).Returns(Task.FromResult(
                new List<Video.Model.Video>
                {
                    new Video.Model.Video(),
                    new Video.Model.Video(),
                    new Video.Model.Video(),
                    new Video.Model.Video(),
                    new Video.Model.Video()
                }));
            var homeConrtoller = new HomeController(null, mockService.Object);
            var result = homeConrtoller.Videos("trial bike").GetAwaiter().GetResult();
            var vResult = result as ViewResult;

            Assert.IsTrue((vResult.Model as List<Video.Model.Video>).Count > 1);
        }

    }
}
