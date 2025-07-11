using Microsoft.EntityFrameworkCore;

using ders_notlari_api.Models;
using System.Collections.Generic;

namespace ders_notlari_api.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Note> Notes => Set<Note>();
    }
}
