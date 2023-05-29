using CSBLOG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using static System.Net.Mime.MediaTypeNames;

namespace CSBLOG.Data
{
    public class CSDbContext: DbContext
    {
        public CSDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Autoret> Autorets { get; set; }
        public DbSet<Postet> Postets { get; set; }
        public DbSet<Foto> Fotos { get; set; }

    }
}
