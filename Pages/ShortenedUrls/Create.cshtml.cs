using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShortenUrl.Data;
using ShortenUrl.Models;

namespace ShortenUrl.Pages.ShortenedUrls
{
    public class CreateModel : PageModel
    {
        private readonly ShortenUrl.Data.ShortenContext _context;

        public CreateModel(ShortenUrl.Data.ShortenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ShortenedUrl ShortenedUrl { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ShortenedUrl.Add(ShortenedUrl);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
