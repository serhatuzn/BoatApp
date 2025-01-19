﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatApp.Business.DataProtection
{
    public interface IDataProtection
    {
        string Protect(string text);
        string Unprotect(string protectedtext);
    }
}
