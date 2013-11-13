using System.Collections.Generic;
using System.Data;

namespace NewsReader.Ultility
{
    /// <summary>
    /// News object class
    /// </summary>
    public class NewsJsonObject
    {
        public uint ID { get; set; }
        public string URL { get; set; }
        public string AbstractContent { get; set; }
        public string CrawlDate { get; set; }
        public List<NewsContentJsonObject> NewsContent { get; set; }
        public string PubDate { get; set; }
        public int SiteID { get; set; }
        public string Title { get; set; }
    }

    public class NewsContentJsonObject
    {
        public string Content { get; set; }
        public List<ImageJsonObject> Images { get; set; }
    }

    public class ImageJsonObject
    {
        public string Link { get; set; }
        public string Descript { get; set; }
    }
}
