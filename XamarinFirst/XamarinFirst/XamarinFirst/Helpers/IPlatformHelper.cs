﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;

namespace XamarinFirst.Helpers
{
   public interface IPlatformHelper
    {
        string GetDbPath();
        ISQLitePlatform GetSQLitePlatform();

    }
}
