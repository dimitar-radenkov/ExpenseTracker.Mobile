using System;
using System.IO;
using ExpenseTracker.Mobile.Droid.Storage;
using ExpenseTracker.Mobile.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroindDbPath))]
namespace ExpenseTracker.Mobile.Droid.Storage
{
    public class AndroindDbPath : IDbPath
    {

        public string GetPath(string filename)
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                filename);
        }
    }
}