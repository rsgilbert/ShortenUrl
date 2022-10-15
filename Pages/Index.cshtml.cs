using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShortenUrl.Data;

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
    public string OriginalUrl { get; set; } = "";

    public string ShortUrl { get; set; } = "";


    public void OnGet()
    {

    }

    public ActionResult OnPost() 
    {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
        ShortUrl = $"Shortened {OriginalUrl}";
        return Page();
    }
}
