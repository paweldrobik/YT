using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Video.Abstract;
using YoutubeClient.Models;

namespace YoutubeClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVideoService _videoService;

        public HomeController(ILogger<HomeController> logger, IVideoService videoService)
        {
            _logger = logger;
            _videoService = videoService;
        }

        [Route("home/videos/{search}")]
        public async Task<IActionResult> Videos(string search)
        {
            var videos = await _videoService.GetVideos(search);

            return View(videos);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
