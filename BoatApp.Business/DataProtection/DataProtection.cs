using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoatApp.Business.DataProtection
{
    public class DataProtection : IDataProtection
    {
        private readonly IDataProtector _dataProtector;

        public DataProtection(IDataProtectionProvider provider)
        {
            _dataProtector = provider.CreateProtector("BoatApp");
        }
        public string Protect(string text)
        {
            return _dataProtector.Protect(text);
        }

        public string Unprotect(string protectedtext)
        {
            return _dataProtector.Unprotect(protectedtext);
        }
    }
}
