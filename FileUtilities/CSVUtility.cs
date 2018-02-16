using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUtilities.Model;

namespace FileUtilities
{
    public static class CSVUtility
    {
        public static CSVDataCollection GetDuplicateBasedOnHeaderName(string filename, string headername)
        {
            CSVDataCollection csvDataCollection = new CSVDataCollection();
            List<string> duplicateData = new List<string>();

            try
            {
                using (var reader = new StreamReader(filename))
                {
                    int index = 0;
                    bool isheader = true;
                    var uniqueData = new Dictionary<string, string>();

                    //When header not found in CSV it will retrun index as -1 and we stop processing
                    while (!reader.EndOfStream && index >= 0)
                    {
                        var readLine = reader.ReadLine();

                        // Isheader is for to get first record to find the column name
                        if (isheader)
                        {
                            // Find the header index based on header name passed.
                            index = GetHeaderIndex(readLine, headername);
                            isheader = false;
                        }
                        else
                        {
                            var columnValues = readLine.Split(',');

                            if (index < columnValues.Length)
                            {
                                string columnValue = columnValues[index];

                                if (!string.IsNullOrEmpty(columnValue))
                                {
                                    if (uniqueData.ContainsKey(columnValue))
                                    {
                                        // When we find duplicate record
                                        if (!string.IsNullOrEmpty(uniqueData[columnValue]))
                                        {
                                            // Add first duplicate data from list of uniqueData 
                                            duplicateData.Add(uniqueData[columnValue]);

                                            //Clear uniqueData values because we dont want to process it again
                                            //When more duplicate data found for same column as we already added to duplicate list
                                            uniqueData[columnValue] = string.Empty;
                                        }

                                        duplicateData.Add(readLine);
                                    }
                                    else
                                    {
                                        uniqueData.Add(columnValue, readLine);
                                    }
                                }
                            }
                        }
                    }

                    if (index == -1)
                    {
                        csvDataCollection.HasError = true;
                        csvDataCollection.Message = "Specified header name not found in CSV file.";
                    }
                }
            }
            catch (DirectoryNotFoundException enfEx)
            {
                // If file Path not Found
                csvDataCollection.HasError = true;
                //Currently we are passing back actual exception message but once we decie on 
                //logging and exception handling we can change it to sent user friendly message
                csvDataCollection.Message = enfEx.Message;
            }
            catch (Exception ex)
            {
                // Unhandled exception
                csvDataCollection.HasError = true;
                //Currently we are passing back actual exception message but once we decie on 
                //logging and exception handling we can change it to sent user friendly message
                csvDataCollection.Message = ex.Message;
            }

            csvDataCollection.Result = duplicateData;
            return csvDataCollection;
        }

        private static int GetHeaderIndex(string line, string name)
        {
            var headerNames = line.Split(',');

            for (int i = 0; i < headerNames.Length; i++)
            {
                if (headerNames[i].ToLower() == name.ToLower())
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
