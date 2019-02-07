using System;
using System.IO;
using ExpenseTracker.Mobile.iOS.Storage;
using ExpenseTracker.Mobile.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(IosDbPath))]
namespace ExpenseTracker.Mobile.iOS.Storage
{
    public class IosDbPath : IDbPath
    {
        public string GetPath(string sqliteFilename)
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 
                "..", 
                "Library", 
                sqliteFilename);
        }
    }
}