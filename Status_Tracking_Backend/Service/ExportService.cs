using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.OpenApi.Any;
using Status_Tracking_Backend.Models;

namespace Status_Tracking_Backend.Service
{
    public class ExportService
    {
        public byte[] ExportExcel(List<Customers> customers) {
            var workbook = new XLWorkbook();
            var workSheet = workbook.AddWorksheet("Customer Details");
            workSheet.Cell(1, 1).Value = "Date";
            workSheet.Cell(1, 2).Value = "Month";
            workSheet.Cell(1,3).Value  ="Customer Name";
            workSheet.Cell(1, 4).Value = ("Mobile Number");
            workSheet.Cell(1, 5).Value = ("RM Name");
            workSheet.Cell(1, 6).Value = ("TM Name");
            workSheet.Cell(1, 7).Value = ("Status");
            workSheet.Cell(1, 8).Value = ("Value");
            workSheet.Cell(1, 9).Value = ("Remarks");
            workSheet.Cell(1, 10).Value = ("Remarks1");
            workSheet.Cell(1, 11).Value = ("Remarks2");
            int countRow = 2;
            foreach(var customer in customers)
            {
                workSheet.Cell(countRow, 1).Value = customer.Date;
                workSheet.Cell(countRow, 2).Value = customer.Month;
                workSheet.Cell(countRow, 3).Value = customer.Customer_Name;
                workSheet.Cell(countRow, 4).Value = customer.Mobile_Number;
                workSheet.Cell(countRow, 5).Value = customer.RM_Name;
                workSheet.Cell(countRow, 6).Value = customer.TM_Name;
                workSheet.Cell(countRow, 7).Value = customer.Status;
                workSheet.Cell(countRow, 8).Value = customer.Value;
                workSheet.Cell(countRow, 9).Value = customer.Remarks;
                workSheet.Cell(countRow, 10).Value = customer.Remarks1;
                workSheet.Cell(countRow, 11).Value = customer.Remarks2;
                countRow++;
            }
            var workSheet1 = workbook.AddWorksheet("Summary");
            
            workSheet1.Cell(1, 1).Value = "Month";
            workSheet1.Cell(1, 2).Value = "TM Name";
            workSheet1.Cell(1, 3).Value = "RM Name";
            workSheet1.Cell(1, 4).Value = "Not Intrested";
            workSheet1.Cell(1, 5).Value = "Follow up";
            workSheet1.Cell(1, 6).Value = "Invalid";
            workSheet1.Cell(1, 7).Value = "Closed";
            workSheet1.Cell(1, 8).Value = "Without CT";
            workSheet1.Cell(1, 9).Value = "Hot Followup";
            workSheet1.Cell(1, 10).Value = "Old Followup";
            workSheet1.Cell(1, 11).Value = "Total";

            var groupData = customers.GroupBy((x) => new { x.Month,x.TM_Name,x.RM_Name}  );
            var countRow1 = 2;
            foreach(var group in groupData)
            {
                workSheet1.Cell(countRow1, 1).Value = group.Key.Month;
                workSheet1.Cell(countRow1, 2).Value = group.Key.TM_Name;
                workSheet1.Cell(countRow1, 3).Value = group.Key.RM_Name;
                workSheet1.Cell(countRow1, 4).Value = group.Count(x => string.Equals(x.Status,"not intrested",StringComparison.OrdinalIgnoreCase));
                workSheet1.Cell(countRow1, 5).Value = group.Count(x => string.Equals(x.Status, "follow up", StringComparison.OrdinalIgnoreCase));
                workSheet1.Cell(countRow1, 6).Value = group.Count(x => string.Equals(x.Status, "invalid", StringComparison.OrdinalIgnoreCase));
                workSheet1.Cell(countRow1, 7).Value = group.Count(x => string.Equals(x.Status, "closed", StringComparison.OrdinalIgnoreCase));
                workSheet1.Cell(countRow1, 8).Value = group.Count(x => string.Equals(x.Status, "without ct", StringComparison.OrdinalIgnoreCase));
                workSheet1.Cell(countRow1, 9).Value = group.Count(x => string.Equals(x.Status, "hot followup", StringComparison.OrdinalIgnoreCase));
                workSheet1.Cell(countRow1, 10).Value = group.Count(x => string.Equals(x.Status, "old followup", StringComparison.OrdinalIgnoreCase));
                workSheet1.Cell(countRow1, 11).Value = group.Count();
                countRow1++;

            }

            var workSheet2 = workbook.AddWorksheet("Total calls given by TM's");
            workSheet2.Cell(1, 1).Value = "Month";
            workSheet2.Cell(1, 2).Value = "TM Name";
            workSheet2.Cell(1, 3).Value = "Not Intrested";
            workSheet2.Cell(1, 4).Value = "Follow up";
            workSheet2.Cell(1, 5).Value = "Invalid";
            workSheet2.Cell(1, 6).Value = "Closed";
            workSheet2.Cell(1, 7).Value = "Without CT";
            workSheet2.Cell(1, 8).Value = "Hot Followup";
            workSheet2.Cell(1, 9).Value = "Old Followup";
            workSheet2.Cell(1, 10).Value = "Total Calls";


            var tmGroup = customers.GroupBy((x) => new { x.Month,x.TM_Name});

            var countRow2 = 2;
            foreach(var group in tmGroup)
            {
                workSheet2.Cell(countRow2, 1).Value = group.Key.Month;
                workSheet2.Cell(countRow2, 2).Value = group.Key.TM_Name;
                workSheet2.Cell(countRow2, 3).Value = group.Count(x => string.Equals(x.Status, "not intrested", StringComparison.OrdinalIgnoreCase));
                workSheet2.Cell(countRow2, 4).Value = group.Count(x => string.Equals(x.Status, "follow up", StringComparison.OrdinalIgnoreCase));
                workSheet2.Cell(countRow2, 5).Value = group.Count(x => string.Equals(x.Status, "invalid", StringComparison.OrdinalIgnoreCase));
                workSheet2.Cell(countRow2, 6).Value = group.Count(x => string.Equals(x.Status, "closed", StringComparison.OrdinalIgnoreCase));
                workSheet2.Cell(countRow2, 7).Value = group.Count(x => string.Equals(x.Status, "without ct", StringComparison.OrdinalIgnoreCase));
                workSheet2.Cell(countRow2, 8).Value = group.Count(x => string.Equals(x.Status, "hot followup", StringComparison.OrdinalIgnoreCase));
                workSheet2.Cell(countRow2, 9).Value = group.Count(x => string.Equals(x.Status, "old followup", StringComparison.OrdinalIgnoreCase));
                workSheet2.Cell(countRow2, 10).Value = group.Count();
                countRow2++;
            }

            var workSheet3 = workbook.AddWorksheet("TM Wise Values");
            workSheet3.Cell(1, 1).Value = "Month";
            workSheet3.Cell(1, 2).Value = "TM Name";
            workSheet3.Cell(1, 3).Value = "Total Value";

            var tmValueGroup = customers.GroupBy((x) => new { x.Month, x.TM_Name });
            var countRow3 = 2;

            foreach(var group in tmValueGroup)
            {
                workSheet3.Cell(countRow3, 1).Value = group.Key.Month;
                workSheet3.Cell(countRow3, 2).Value = group.Key.TM_Name;
                workSheet3.Cell(countRow3, 3).Value = group.Sum(x=>x.Value);
                countRow3++;

            }
            var workSheet4 = workbook.AddWorksheet("RM Wise Values");
            workSheet4.Cell(1, 1).Value = "Month";
            workSheet4.Cell(1, 2).Value = "RM Name";
            workSheet4.Cell(1, 3).Value = "Total Value";

            var rmValueGroup = customers.GroupBy((x) => new { x.Month, x.RM_Name });
            var countRow4 = 2;

            foreach (var group in rmValueGroup)
            {
                workSheet4.Cell(countRow4, 1).Value = group.Key.Month;
                workSheet4.Cell(countRow4, 2).Value = group.Key.RM_Name;
                workSheet4.Cell(countRow4, 3).Value = group.Sum(x => x.Value);
                countRow4++;

            }





            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();

        }
    }
}
