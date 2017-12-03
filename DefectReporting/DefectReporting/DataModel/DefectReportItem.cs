using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DefectReporting 
{
    public class DefectReportItem
        {
        //Class to contain defect report and table setup information
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string workOrderNumber { get; set; } 
        public int count { get; set; }  
        public string defect { get; set; }   //defect < 40 characters
        public string disposition { get; set; }  //defect resolution  < 40 characters
        public DateTime date { get; set; }  //date defect was created
        public bool useDefect { get; set; }  //if defect should be used to generate quick select list - Default = True
      }
}
