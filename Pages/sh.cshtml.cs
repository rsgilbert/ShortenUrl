using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShortenUrl.Data;
using ShortenUrl.Models;

namespace ShortenUrl.Pages;

public class ShModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ShortenContext _context;

    public ShModel(ILogger<IndexModel> logger, ShortenContext shortenContext)
    {
        _logger = logger;
        _context = shortenContext;
    }


    [BindProperty]
    public ShortenedUrl ShortenedUrl { get; set; }

    public string FullShortUrl { get; set; }

    public ActionResult OnGet()
    {
        _logger.LogInformation($"url path is {HttpContext.Request.Path}");

        ShortenedUrl = _context.ShortenedUrl
            .Where(s => s.ShortUrl == HttpContext.Request.Path.ToString())
            .FirstOrDefault();
        if (ShortenedUrl != null)
            return Redirect(ShortenedUrl.OriginalUrl);
        return RedirectToPage("./Index");
    }
}


