using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DefectReporting.Droid;
using Xamarin.Forms;
using System.IO;

namespace DefectReporting.Droid
{
    class DatabasePath : IDatabasePath
    {
        public string GetDatabasePath(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }

    }
}