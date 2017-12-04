using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DefectReporting
{
    public class DataBaseAccess
    {
        readonly SQLiteAsyncConnection database;

        #region Create Connection

        public DataBaseAccess(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<DefectReportItem>().Wait();
        }

        #endregion

        #region Get All

        public Task<List<DefectReportItem>> GetItemsAsync()
        {
            return database.Table<DefectReportItem>().ToListAsync();
        }

        public Task<List<DefectReportItem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<DefectReportItem>("SELECT * FROM [DefectReportItem]");
        }

        #endregion

        #region Get Defect List

        //public Task<List<String>> GetSelectedDefects ()
        //{
        //    return database.QueryAsync<String>("SELECT UNIQUE [defect] FROM [DefectReportItem] WHERE [useDefect] = 1");
        //}

        #endregion

        #region Individual Defect Items

        public Task<DefectReportItem> GetItemAsync(int id)
        {
            //Get specific defect
            return database.Table<DefectReportItem>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(DefectReportItem newDefect)
        {
            //Save new item
            if (newDefect.id != 0)
            {
                return database.UpdateAsync(newDefect);
            }
            else
            {
                return database.InsertAsync(newDefect);
            }
        }

        public Task<int> DeleteItemAsync(DefectReportItem newDefect)
        {
            //Delete item
            return database.DeleteAsync(newDefect);
        }

#endregion
    }
}
