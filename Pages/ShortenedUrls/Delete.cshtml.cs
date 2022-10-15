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
    public class DeleteModel : PageModel
    {
        private readonly ShortenUrl.Data.ShortenContext _context;

        public DeleteModel(ShortenUrl.Data.ShortenContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ShortenedUrl ShortenedUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ShortenedUrl == null)
            {
                return NotFound();
            }

            var shortenedurl = await _context.ShortenedUrl.FirstOrDefaultAsync(m => m.ID == id);

            if (shortenedurl == null)
            {
                return NotFound();
            }
            else 
            {
                ShortenedUrl = shortenedurl;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ShortenedUrl == null)
            {
                return NotFound();
            }
            var shortenedurl = await _context.ShortenedUrl.FindAsync(id);

            if (shortenedurl != null)
            {
                ShortenedUrl = shortenedurl;
                _context.ShortenedUrl.Remove(ShortenedUrl);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
