using Microsoft.EntityFrameworkCore;
using OtpAPI.OtpAPI.Models;

namespace OtpAPI.OtpAPI.Data
{
    public class OtpApiDbContext : DbContext
    {
        public OtpApiDbContext(DbContextOptions<OtpApiDbContext> options) : base(options) { }

        public DbSet<Otp> Otps { get; set; }
        public DbSet<OtpUser> OtpUsers { get; set; }
    }
}
