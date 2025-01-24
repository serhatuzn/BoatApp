﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatApp.Business.Operations.Settings
{
    public interface ISettingsService
    {
        Task ToggleMaintenence();

        bool GetMaintenenceMode();
    }
}
