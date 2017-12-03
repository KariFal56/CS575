using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using DefectReporting.iOS;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(DatabasePath))] 
namespace DefectReporting.iOS
{
    public class DatabasePath : IDatabasePath 
    {
        public string GetDatabasePath(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            //Check if directory exists, if not create it
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, fileName);
        }
    }
}