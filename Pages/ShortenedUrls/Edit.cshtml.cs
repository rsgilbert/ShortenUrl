using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShortenUrl.Data;
using ShortenUrl.Models;

namespace ShortenUrl.Pages.ShortenedUrls
{
    public class EditModel : PageModel
    {
        private readonly ShortenUrl.Data.ShortenContext _context;

        public EditModel(ShortenUrl.Data.ShortenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShortenedUrl ShortenedUrl { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ShortenedUrl == null)
            {
                return NotFound();
            }

            var shortenedurl =  await _context.ShortenedUrl.FirstOrDefaultAsync(m => m.ID == id);
            if (shortenedurl == null)
            {
                return NotFound();
            }
            ShortenedUrl = shortenedurl;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ShortenedUrl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShortenedUrlExists(ShortenedUrl.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShortenedUrlExists(int id)
        {
          return _context.ShortenedUrl.Any(e => e.ID == id);
        }
    }
}
