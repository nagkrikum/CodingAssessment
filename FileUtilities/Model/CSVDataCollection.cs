using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUtilities.Model
{
    public class CSVDataCollection
    {
        public List<string> Result {get; set;}
        public bool HasError { get; set; }
        public string Message { get; set; }

    }
}
