using Microsoft.EntityFrameworkCore;
using OtpAPI.OtpAPI.Data.Repositories.Interfaces;
using OtpAPI.OtpAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OtpAPI.OtpAPI.Data.Repositories.Implementations
{
    public class OtpApiRepository : IOtpApiRepository
    {
        private readonly OtpApiDbContext _context;
        public OtpApiRepository(OtpApiDbContext context)
        {
            _context = context;
        }

        public async Task<OtpUser> GetUser(string id)
        {
            return _context.OtpUsers.Find(id);
        }
        public async Task<Otp> GetOtp(string otpCode)
        {
            return await _context.Otps.Include(y => y.OtpUser)
                                .Where(x => x.OtpCode == otpCode)
                                .FirstOrDefaultAsync();
        }
        public void DeleteOtp(string otpId)
        {
            var model= _context.Otps.First(c => c.Id == otpId);
            _context.Remove(model);
            _context.SaveChanges();            
        }
    }
}
