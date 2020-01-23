using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelExporter
{
    public class ExcelExporter
    {
        using (ExcelEngine excelEngine = new ExcelEngine())
{
    IApplication application = excelEngine.Excel;
    application.DefaultVersion = ExcelVersion.Excel2016;
 
    //Read the data from XML file
    StreamReader reader = new StreamReader(Path.GetFullPath(@"../../Data/Customers.xml"));

    //Assign the data to the customerObjects collection
    IEnumerable customerObjects = GetData(reader.ReadToEnd());

    //Create a new workbook
    IWorkbook workbook = application.Workbooks.Create(1);
    IWorksheet sheet = workbook.Worksheets[0];

    //Import data from customerObjects collection
    sheet.ImportData(customerObjects, 5, 1, false);
        }
    }
}
