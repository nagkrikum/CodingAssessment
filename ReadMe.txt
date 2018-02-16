Assumption:
·        I assume header will be always be in the first row.
·        I assume data are case sensitive.
·        We just need to print those duplicate record not to save anywhere. 
Design:
·        Created FileUtilities class library which will process CSV file and return duplicate record.
·        Created Console application with CSVFilePath and ColumnName as configurable in app.config to figure out duplicate row.
·        Add CSV file as part of solution
 
Testing :
Test Case 1:
FileName, Column1

Test Case 1:
FileName, Column2