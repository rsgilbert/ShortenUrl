using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShortenUrl.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
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
