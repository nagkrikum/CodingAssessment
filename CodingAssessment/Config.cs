using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssessment
{
    public static class Config
    {
        
        private static string headerName = ConfigurationManager.AppSettings["HeaderName"];
        private static string csvFilePath = ConfigurationManager.AppSettings["CSVFilePath"];

        //Get CSVFilePath from app.config
        public static string CSVFilePath { get; set; } = csvFilePath;

        //Get column from app.config
        public static string HeaderName { get; set; } = headerName;
    }
}
