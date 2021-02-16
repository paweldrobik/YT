using System;
using System.Collections.Generic;
using System.Text;

namespace Video.Abstract
{
    public interface IProviderConfigurator
    {
        int NoVideos { get; }
        string GetApiUrl();
    }
}
