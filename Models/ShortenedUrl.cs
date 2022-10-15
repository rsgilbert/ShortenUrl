using System.ComponentModel.DataAnnotations;

namespace ShortenUrl.Models
{
    public class ShortenedUrl
    {
        public int ID { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}