using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using FileUtilities.Model;

namespace CodingAssessment
{
    public class CSVProcessor
    {
        public void PrintDuplicateBasedOnHeaderName(string filePath, string headerName)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("Please configure valid CSV file path in App.config");
            }

            if (string.IsNullOrEmpty(headerName))
            {
                Console.WriteLine("Please configure valid Header name in App.config");
            }

            var duplicateData = FileUtilities.CSVUtility.GetDuplicateBasedOnHeaderName(filePath, headerName);

            if (duplicateData.HasError)
            {
                Console.WriteLine(string.Format("Error occured while processing CSV File.  Error message {0}" , duplicateData.Message));
            }
            else
            {
                Console.WriteLine(string.Format("Total of {0} duplicate record found.",duplicateData.Result.Count));

                foreach (var record in duplicateData.Result)
                {
                    Console.WriteLine(record);
                }
            }
        }
    }
}
