using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShortenUrl.Models;

namespace ShortenUrl.Data
{
    public class ShortenContext : DbContext
    {
        public ShortenContext (DbContextOptions<ShortenContext> options)
            : base(options)
        {
        }

        public DbSet<ShortenUrl.Models.ShortenedUrl> ShortenedUrl { get; set; } = default!;
    }
}
