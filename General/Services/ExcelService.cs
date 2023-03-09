using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniExcelLibs;
using Nager.Date;

namespace PilotDesktop.General.Services
{
    public static class ExcelService
    {
        public static void HideIDColumns(DataGridView tableDataGridView)
        {

            foreach (DataGridViewColumn column in tableDataGridView.Columns)
            {
                if (column.Name.StartsWith("ID"))
                {
                    column.Visible = false;
                }
            }
        }



        public static void ShowSpecificColumns(List<string> columns, DataGridView tableDataGridView)
        {

            foreach (DataGridViewColumn column in tableDataGridView.Columns)
            {
                if (columns.Contains(column.Name))
                {
                    column.Visible = true;
                }
                else
                {
                    column.Visible = false;
                }
            }
        }

        public static void FormatDataGridView(ref DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Width = 100;
                var name = col.Name;
                if (name.Length > 10)
                {
                    var dateString = name.Substring(col.Name.Length - 10, 10);

                    if (DateTime.TryParse(dateString, out var date))
                    {
                        col.Width = 70;

                        if (DateService.IsWoorkDay(date) == false)
                        {
                            col.DefaultCellStyle.BackColor = DateService.NotWorkDayColor();
                        }
                        else
                        {
                            switch (date.DayOfWeek)
                            {
                                case (DayOfWeek.Monday):
                                    col.DefaultCellStyle.BackColor = DateService.WorkDayColor1();
                                    break;
                                case (DayOfWeek.Tuesday):
                                    col.DefaultCellStyle.BackColor = DateService.WorkDayColor2();
                                    break;
                                case (DayOfWeek.Wednesday):
                                    col.DefaultCellStyle.BackColor = DateService.WorkDayColor1();
                                    break;
                                case (DayOfWeek.Thursday):
                                    col.DefaultCellStyle.BackColor = DateService.WorkDayColor2();
                                    break;
                                case (DayOfWeek.Friday):
                                    col.DefaultCellStyle.BackColor = DateService.WorkDayColor1();
                                    break;
                                case (DayOfWeek.Saturday):
                                    col.DefaultCellStyle.BackColor = DateService.WorkDayColor1();
                                    break;
                                case (DayOfWeek.Sunday):
                                    col.DefaultCellStyle.BackColor = DateService.WorkDayColor1();
                                    break;
                            }
                        }
                    }
                }
            }
        }


        //public static void ExportToExcelWorkbook(List<DataTable> tblsData, List<DataTable> tblsFormat, List<string> worksheetNames, string excelFilePath = null)
        //{

        //    // load excel, and create a new workbook
        //    var excelApp = new Excel.Application();
        //    var workbook = excelApp.Workbooks.Add();

        //    for (var i = 0; i < tblsData.Count; i++)
        //    {
        //        var tblData = tblsData[i];
        //        var tblFormat = tblsFormat[i];
        //        var worksheetName = worksheetNames[i];

        //        if (i > 0)
        //        {
        //            workbook.Sheets.Add(After: workbook.Sheets[workbook.Sheets.Count]);
        //        }
        //        GetWorsheet(workbook, tblData, tblFormat, worksheetName);
        //    }

        //    //workbook.Sheets[1].Activate();
        //    excelApp.Visible = true;
        //}

        //public static void GetWorsheet(Excel.Workbook woorkBook, DataTable tblData, DataTable tblFormat, string worksheetName)
        //{

        //    try
        //    {

        //        if (tblData == null || tblData.Columns.Count == 0)
        //            throw new Exception("ExportToExcel: Null or empty input table!\n");


        //        // single worksheet
        //        Excel._Worksheet workSheet = (Excel._Worksheet)woorkBook.ActiveSheet;
        //        workSheet.Name = worksheetName;


        //        // column headings
        //        for (var i = 0; i < tblData.Columns.Count; i++)
        //        {
        //            workSheet.Cells[1, i + 1] = tblData.Columns[i].ColumnName;
        //            //workSheet.Cells[1, i + 1].Font.Bold = true;
        //        }

        //        // rows
        //        for (var i = 0; i < tblData.Rows.Count; i++)
        //        {
        //            // to do: format datetime values before printing
        //            for (var j = 0; j < tblData.Columns.Count; j++)
        //            {
        //                workSheet.Cells[i + 2, j + 1] = tblData.Rows[i][j];
        //                if (!string.IsNullOrEmpty(tblFormat?.Rows[i][j]?.ToString()))
        //                {
        //                    var formats = tblFormat.Rows[i][j].ToString().Split(';');
        //                    foreach (var format in formats)
        //                    {
        //                        if (format == "Bold")
        //                        {
        //                            //workSheet.Cells[i + 2, j + 1].Font.Bold = true;
        //                        }
        //                        if (format == "Number")
        //                        {
        //                            //double tmp;
        //                            //if (!double.TryParse(workSheet.Cells[i + 2, j + 1].Value.ToString(), out tmp))
        //                            //    tmp = 0;
        //                            //workSheet.Cells[i + 2, j + 1] = tmp;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        workSheet.Columns.AutoFit();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("ExportToExcel: \n" + ex.Message);
        //    }

        //}

        //public static void ExportToExcel(List<DataTable> tblsData, List<DataTable> tblsFormat, string excelFilePath = null)
        //{
        //    try
        //    {

        //        var tblData = tblsData.FirstOrDefault();
        //        var tblFormat = tblsFormat.FirstOrDefault();
        //        if (tblData == null || tblData.Columns.Count == 0)
        //            throw new Exception("ExportToExcel: Null or empty input table!\n");

        //        // load excel, and create a new workbook
        //        var excelApp = new Excel.Application();
        //        excelApp.Workbooks.Add();

        //        // single worksheet
        //        Excel._Worksheet workSheet = (Excel._Worksheet)excelApp.ActiveSheet;

        //        // column headings
        //        for (var i = 0; i < tblData.Columns.Count; i++)
        //        {
        //            workSheet.Cells[1, i + 1] = tblData.Columns[i].ColumnName;
        //            //workSheet.Cells[1, i + 1].Font.Bold = true;
        //        }

        //        // rows
        //        for (var i = 0; i < tblData.Rows.Count; i++)
        //        {
        //            // to do: format datetime values before printing
        //            for (var j = 0; j < tblData.Columns.Count; j++)
        //            {
        //                workSheet.Cells[i + 2, j + 1] = tblData.Rows[i][j];
        //                if (!string.IsNullOrEmpty(tblFormat?.Rows[i][j]?.ToString()))
        //                {
        //                    var formats = tblFormat.Rows[i][j].ToString().Split(';');
        //                    foreach (var format in formats)
        //                    {
        //                        if (format == "Bold")
        //                        {
        //                            //workSheet.Cells[i + 2, j + 1].Font.Bold = true;
        //                        }
        //                        if (format == "Number")
        //                        {
        //                            //double tmp;
        //                            //if (!double.TryParse(workSheet.Cells[i + 2, j + 1].Value.ToString(), out tmp))
        //                            //    tmp = 0;
        //                            //workSheet.Cells[i + 2, j + 1] = tmp;
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        // check file path
        //        if (!string.IsNullOrEmpty(excelFilePath))
        //        {
        //            try
        //            {
        //                workSheet.SaveAs(excelFilePath);
        //                excelApp.Quit();
        //                MessageBox.Show("Excel file saved!");
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
        //                                    + ex.Message);
        //            }
        //        }
        //        else
        //        { // no file path is given
        //            excelApp.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("ExportToExcel: \n" + ex.Message);
        //    }
        //}
        //public static void ExportToExcel(this DataTable tbl, string excelFilePath = null)
        //{
        //    try
        //    {
        //        if (tbl == null || tbl.Columns.Count == 0)
        //            throw new Exception("ExportToExcel: Null or empty input table!\n");

        //        // load excel, and create a new workbook
        //        var excelApp = new Excel.Application();
        //        excelApp.Workbooks.Add();

        //        // single worksheet
        //        Excel._Worksheet workSheet = (Excel._Worksheet)excelApp.ActiveSheet;

        //        // column headings
        //        for (var i = 0; i < tbl.Columns.Count; i++)
        //        {
        //            workSheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
        //            //workSheet.Cells[1, i + 1].Font.Bold = true;
        //        }

        //        // rows
        //        for (var i = 0; i < tbl.Rows.Count; i++)
        //        {
        //            // to do: format datetime values before printing
        //            for (var j = 0; j < tbl.Columns.Count; j++)
        //            {

        //                workSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
        //                var test = workSheet.Cells[i + 2, j + 1];
        //            }
        //        }

        //        // check file path
        //        if (!string.IsNullOrEmpty(excelFilePath))
        //        {
        //            try
        //            {
        //                workSheet.SaveAs(excelFilePath);
        //                excelApp.Quit();
        //                MessageBox.Show("Excel file saved!");
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
        //                                    + ex.Message);
        //            }
        //        }
        //        else
        //        { // no file path is given
        //            excelApp.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("ExportToExcel: \n" + ex.Message);
        //    }
        //}
        public static void FastExcelWriteAddRowDemo()
        {
            var path = Path.Combine("c:\\temp", "test.xlsx");
            var table = new DataTable();
            {
                table.Columns.Add("Column1", typeof(string));
                table.Columns.Add("Column2", typeof(decimal));
                table.Rows.Add("MiniExcel", 1);
                table.Rows.Add("Github", 2);
            }

            MiniExcel.SaveAs(path, table);
        }

    }
}
