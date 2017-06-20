using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLite.Net.Interop;
using XamarinFirst.Helpers;
using SQLite.Net.Platform.XamarinIOS;
using XamarinFirst.iOS.Helpers;
using Xamarin.Forms;


[assembly: Dependency(typeof(PlatformHelper))]
namespace XamarinFirst.iOS.Helpers
{
    public class PlatformHelper : IPlatformHelper
    {
        public string GetDbPath()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = System.IO.Path.Combine(path,"..", "mycompany.sqlite3");
            return path;
        }
        public ISQLitePlatform GetSQLitePlatform()
        {
            return new SQLitePlatformIOS();
        }
    }
}