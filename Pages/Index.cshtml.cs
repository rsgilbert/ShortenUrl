using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShortenUrl.Data;
using ShortenUrl.Models;

namespace ShortenUrl.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ShortenContext _context;

    public IndexModel(ILogger<IndexModel> logger, ShortenContext shortenContext)
    {
        _logger = logger;
        _context = shortenContext;
    }


    public string ErrorMessage;

    [BindProperty]
    public ShortenedUrl ShortenedUrl { get; set; }

    public string FullShortUrl { get; set; }


    public ActionResult OnPost()
    {
        ShortenedUrl.ShortUrl = randomShortUrl();
        _context.ShortenedUrl.Add(ShortenedUrl);
        _context.SaveChanges();
        FullShortUrl = $"{HttpContext.Request.Host}{ShortenedUrl.ShortUrl}";
        return Page();
    }

    private string randomShortUrl()
    {
        return "/sh/" + Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 5).ToLower();
    }
}

