using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Video.Abstract;

namespace Video.Service
{
    public class YoutubeService : IVideoService, IProviderConfigurator
    {
        //private IProviderConfigurator _providerConfigurator;

        public int NoVideos => throw new NotImplementedException();

        public string GetApiUrl()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Video.Model.Video>> GetVideos(string search)
        {
            //var url = _providerConfigurator.GetApiUrl() + "?part=snippet&chart=mostPopular&key=AIzaSyA7riltTfgmnBGQvqApESGStVvEODTChh8";
            var url = $"https://www.googleapis.com/youtube/v3/search?part=snippet&maxResults=25&q={search}&key=AIzaSyAofLH2rh3ZLP9-Xd40Kbvizp4gLzljVc4";

            //_providerConfigurator.NoVideos

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var ytStringResponse = await response.Content.ReadAsStringAsync();
                var ytResponse = JsonConvert.DeserializeObject<YtResponse>(ytStringResponse);

                var ytVideos = ytResponse.items.Select(n => new Video.Model.Video
                {
                    Id = n.id.videoId,
                    Title = n.snippet.title,
                    Description = n.snippet.description
                });

                return ytVideos.ToList();
            }

            return null;
        }
    }
}
