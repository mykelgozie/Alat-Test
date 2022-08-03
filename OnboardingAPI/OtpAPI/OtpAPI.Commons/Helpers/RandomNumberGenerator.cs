using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtpApi.Commons.Helpers
{
    public static class RandomNumberGenerator 
    {
        public static string GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(999999).ToString();
        }
    }


}
