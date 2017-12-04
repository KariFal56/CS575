using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace DefectReporting 
{
    public class DefectReportItem
        {
        //Class to contain defect report item and table setup information
        //name of the table is DefectReportItem
        [PrimaryKey, AutoIncrement]
        public int id { get { return id; } set { id = 0; } }  //default id to 0 so we know this is a new defect
        public string workOrderNumber { get; set; } 
        public int count { get { return count; } set { count = 1; } }  //default count to 1, it will never be less then 1 here  
        public string defect { get; set; }   //defect < 40 characters
        public string disposition { get; set; }  //defect resolution  < 40 characters
        public DateTime date { get { return date; } set { date = DateTime.Now; } }  //date defect was created
        public bool useDefect { get { return useDefect; } set { useDefect = true; } }  //if defect should be used to generate quick select list - Default = True
      }
}
