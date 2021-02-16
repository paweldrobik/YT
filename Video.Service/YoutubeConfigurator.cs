using System;
using System.Collections.Generic;
using System.Text;
using Video.Abstract;

namespace Video.Service
{
    public class YoutubeConfigurator : IProviderConfigurator, IServiceDependency
    {
        public int NoVideos => 5;

        public string GetApiUrl()
        {
            return "https://www.googleapis.com/youtube/v3/videos";
        }
    }
}
