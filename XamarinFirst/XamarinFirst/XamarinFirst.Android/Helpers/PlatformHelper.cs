using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net.Interop;
using XamarinFirst.Helpers;
using SQLite.Net.Platform.XamarinAndroid;
using XamarinFirst.Droid.Helpers;
using Xamarin.Forms;


[assembly: Dependency(typeof(PlatformHelper))]
namespace XamarinFirst.Droid.Helpers 
{
    class PlatformHelper : IPlatformHelper
    {
        public string GetDbPath()
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = System.IO.Path.Combine(path, "mycompany.sqlite3");
            return path;
        }
        public ISQLitePlatform GetSQLitePlatform()
        {
            return new SQLitePlatformAndroid();

        }
    }
}