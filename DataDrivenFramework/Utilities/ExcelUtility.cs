using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;

public class ExcelUtility
{
    private readonly string _filePath;

    public ExcelUtility(string filePath)
    {
        _filePath = filePath;
    }

    public IEnumerable<object[]> ReadExcelData(string sheetName)
    {

        // will store the data from the excel sheet, as a list of object arrays, where each array represents a row of data
        List<object[]> data = new List<object[]>();

        using (FileStream file = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
        {
            IWorkbook workbook = new XSSFWorkbook(file);
            ISheet sheet = workbook.GetSheet(sheetName);
            int rowCount = sheet.PhysicalNumberOfRows;

            for (int i = 1; i < rowCount; i++) // Skip header row
            {
                IRow row = sheet.GetRow(i);
                if (row != null)
                {
                    string firstName = row.GetCell(0)?.ToString();
                    string lastName = row.GetCell(1)?.ToString();
                    string postCode = row.GetCell(2)?.ToString();
                    string address = row.GetCell(3)?.ToString();

                    data.Add(new object[] { firstName, lastName, postCode, address });
                }
            }
        }

        return data;
    }
}
