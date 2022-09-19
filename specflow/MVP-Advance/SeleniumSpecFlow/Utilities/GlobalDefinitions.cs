using ExcelDataReader;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecFlow.Utilities
{
    class GlobalDefinitions
    {
        #region Constant configuration
        public static int Browser = 2;
        public static string excelPath = System.IO.Directory.GetParent(@"../../../").FullName
           + Path.DirectorySeparatorChar + "TestLibrary/TestData/TestData.xlsx";
        public static string AutoScriptPath = System.IO.Directory.GetParent(@"../../../").FullName
           + Path.DirectorySeparatorChar + "TestLibrary/TestData/UploadScript.exe";
        #endregion

        public static string ExcelPath { get => excelPath; set => excelPath = value; }

        #region Excel reader 
        public class ExcelLib
        {
            static List<Datacollection> dataCol = new List<Datacollection>();

            public class Datacollection
            {
                public int rowNumber { get; set; }
                public string colName { get; set; }
                public string colValue { get; set; }
            }

            public static void ClearData()
            {
                dataCol.Clear();
            }

            public static DataTable ExcelToDataTable(string fileName, string SheetName)
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                // Open file and return as Stream
                using (System.IO.FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(stream))
                    {
                        //excelReader.IsFirstRowAsColumnNames = true;

                        //Return as dataset
                        var result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                            {

                                UseHeaderRow = true
                            }
                        });

                        //Get all the tables
                        DataTableCollection table = result.Tables;

                        // store it in data table
                        DataTable resultTable = table[SheetName];

                        // return
                        return resultTable;
                    }
                }
            }

            public static string ReadData(int rowNumber, string columnName)
            {
                try
                {
                    //Retrieving Data using LINQ to reduce much of iterations

                    rowNumber = rowNumber - 1;
                    string data = (from colData in dataCol
                                   where colData.colName == columnName && colData.rowNumber == rowNumber
                                   select colData.colValue).SingleOrDefault();

                    //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;

                    return data.ToString();
                }

                catch (Exception e)
                {
                    //Added by Kumar
                    Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                    return null;
                }
            }

            public static void PopulateInCollection(string fileName, string SheetName)
            {
                ExcelLib.ClearData();
                DataTable table = ExcelToDataTable(fileName, SheetName);

                //Iterate through the rows and columns of the Table
                for (int row = 1; row <= table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        Datacollection dtTable = new Datacollection()
                        {
                            rowNumber = row,
                            colName = table.Columns[col].ColumnName,
                            colValue = table.Rows[row - 1][col].ToString()
                        };

                        //Add all the details for each row
                        dataCol.Add(dtTable);
                    }
                }
            }
        }
        #endregion

        #region screenshot
        public static string GetScreenshot()
        {
            return ((ITakesScreenshot)CommonDriver.driver).GetScreenshot().AsBase64EncodedString;
        }
        #endregion
    }
}
