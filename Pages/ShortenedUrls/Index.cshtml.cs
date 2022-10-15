using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShortenUrl.Data;
using ShortenUrl.Models;

namespace ShortenUrl.Pages.ShortenedUrls
{
    public class IndexModel : PageModel
    {
        private readonly ShortenUrl.Data.ShortenContext _context;

        public IndexModel(ShortenUrl.Data.ShortenContext context)
        {
            _context = context;
        }

        public IList<ShortenedUrl> ShortenedUrl { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ShortenedUrl != null)
            {
                ShortenedUrl = await _context.ShortenedUrl.ToListAsync();
            }
        }
    }
}
