using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsCrawler_WebApi.Models
{
    public class Article
    {
        public Dictionary<string, string> Source { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; }
    }
}