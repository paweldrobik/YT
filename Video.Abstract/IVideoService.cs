using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Video.Model;

namespace Video.Abstract
{
    public interface IVideoService
    {
        //Task<List<Video>> GetVideos(string search);
        Task<List<Video.Model.Video>> GetVideos(string search);
    }
}
