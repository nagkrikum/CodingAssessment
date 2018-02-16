using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssessment
{
    class Program
    {
     
        static void Main(string[] args)
        {
            Console.WriteLine("Started processing CSV File.");

            CodingAssessment.CSVProcessor csvProcessor = new CSVProcessor();
            csvProcessor.PrintDuplicateBasedOnHeaderName(Config.CSVFilePath, Config.HeaderName);

            Console.WriteLine("Completed processing CSV File.");

            Console.WriteLine("Started processing CSV File.");

            csvProcessor.PrintDuplicateBasedOnHeaderName(Config.CSVFilePath, "Column2");

            Console.WriteLine("Completed processing CSV File.");

            Console.ReadLine();
        }
    }
}
