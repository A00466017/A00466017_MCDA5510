Assignment #1
-------------------------------------------------------------------

The goal of the assignment is to simply combine 3 of these programs into a single
program that will recursively read a series of data files in CSV format and enter 
them into a single file.

The program must log the amount of time it takes to read the files in each directory 
and the time it takes to write the files to a file using the logger.

About Code 
-------------------------------------------------------------------
The ProgAssign1 project consists of Final_Csv_Reader which uses the CsvHelper library to read the csv files from multiple directory.
The code checks for missing values and removes the row with missing values. The code also logs the removed rows as well as the valid rows.
It also removes the first rows from each file while read operation in order to remove the redundancy of header rows.
The program is also coded to evaluate the code execution time, code start time and end time.
The code consists of the customerread object model to read the data and customwrite object model to add the date column which is also evaluated 
the directory path.
Finally the code also perform certain exception handling operations

Author - Abhishek Vijayakumar Latha
A# - A00466017

