using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
public struct SheetCell
{
    public int StartRow;
    public int EndRow;
    public int StartCell;
    public int EndCell;
}

/// <summary>
///NPOIHelper 的摘要说明
/// </summary>
public class NPOIHelper
{
	public NPOIHelper()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 读取Excel数据
    /// </summary>
    /// <param name="fileName">文件地址</param>
    /// <param name="ExceptSheet">排除页面，例如（统计信息$）</param>
    /// <returns></returns>
    public static DataTable ReadExcelAsTableNPOI(string fileName,string ExceptSheet)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.Open))
        {
            HSSFWorkbook wb = new HSSFWorkbook(fs);
            int SheetCount = wb.NumberOfSheets;
            int Sheeti = 0;
            DataTable table = new DataTable();
            for (Sheeti = 0; Sheeti < SheetCount; Sheeti++)
            {
                ISheet sheet = wb.GetSheetAt(Sheeti);
                string SheetName = sheet.SheetName;
                if (ExceptSheet.IndexOf(SheetName+"$") != -1)
                {
                    continue;
                }
                IRow headerRow = sheet.GetRow(0);
                if (headerRow==null)
                {
                    continue;
                }
                int cellCount = headerRow.LastCellNum;
                if (table.Columns.Count == 0)
                {
                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                    {
                        string ColumnName = headerRow.GetCell(i).StringCellValue;
                        if (!table.Columns.Contains(ColumnName))
                            table.Columns.Add(new DataColumn(ColumnName));
                    }

                }
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    DataRow dataRow = table.NewRow(); 
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                        if (row.GetCell(j) != null) 
                            dataRow[j] = row.GetCell(j).ToString();
                    table.Rows.Add(dataRow);
                }
            }
            return table;
        }
    }
    public static MemoryStream RenderToExcel(DataTable table)
    {
        MemoryStream ms = new MemoryStream();

        using (table)
        {
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            IRow headerRow = sheet.CreateRow(0);
            ICellStyle style = workbook.CreateCellStyle();
            IFont font = workbook.CreateFont();
            font.FontHeightInPoints = 12;//字号
            font.FontName = "宋体";
            style.SetFont(font);

            // handling header.
            foreach (DataColumn column in table.Columns)
            {
                ICell cell = headerRow.CreateCell(column.Ordinal);//If Caption not set, returns the ColumnName value
                cell.SetCellValue(column.Caption);
                cell.CellStyle = style;
            }
            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in table.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in table.Columns)
                {
                    ICell cell = dataRow.CreateCell(column.Ordinal);
                    cell.SetCellValue(row[column].ToString());
                    cell.CellStyle = style;
                }

                rowIndex++;
            }
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

        }
        return ms;
    }
    public static void SaveToFile(MemoryStream ms, string fileName)
    {

        using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        {
            byte[] data = ms.ToArray();

            fs.Write(data, 0, data.Length);
            fs.Flush();

            data = null;
        }
    }
    public static void RenderToBrowser(MemoryStream ms, string fileName)
    {
        if (HttpContext.Current.Request.Browser.Browser == "IE")
            fileName = HttpUtility.UrlEncode(fileName);
        if (fileName.IndexOf(".xls") == -1)
            fileName += ".xls";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
        HttpContext.Current.Response.BinaryWrite(ms.ToArray());
    }
    public static void RenderToBrowser(MemoryStream ms)
    {
        string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
        if (HttpContext.Current.Request.Browser.Browser == "IE")
            fileName = HttpUtility.UrlEncode(fileName);
        if (fileName.IndexOf(".xls") == -1)
            fileName += ".xls";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
        HttpContext.Current.Response.BinaryWrite(ms.ToArray());
    }
    /// <summary>
    /// 导出Excel
    /// </summary>
    /// <param name="dt"></param>
    public static void ExportToExcel(DataTable dt)
    {
        RenderToBrowser(RenderToExcel(dt));
    }

    /// <summary>
    /// 导出Excel
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="fileName"></param>
    public static void ExportToExcel(DataTable dt, string fileName)
    {
        RenderToBrowser(RenderToExcel(dt), fileName);
    }
    /// <summary>
    /// 导出Excel
    /// </summary>
    /// <param name="dt"></param>
    public static void ExportToExcel(DataTable dt, Dictionary<string, Dictionary<string, SheetCell>> dic_Head)
    {
        RenderToBrowser(RenderToExcel(dt, dic_Head));
    }
    public static MemoryStream RenderToExcel(DataTable table, Dictionary<string, Dictionary<string, SheetCell>> dic_Head)
    {
        MemoryStream ms = new MemoryStream();

        using (table)
        {
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet(); 
            // handling header.
            int ColStart = 0;
            int SonColStart = 2;
            IRow headerRow = sheet.CreateRow(0);
            ICellStyle style = workbook.CreateCellStyle();
            IFont font = workbook.CreateFont();
            font.FontHeightInPoints = 12;//字号
            font.FontName = "宋体";
            style.SetFont(font);
            foreach (string ColumnName in dic_Head.Keys)
            { 
                SheetCell SheetCell = new SheetCell();
                if (dic_Head[ColumnName] == null)
                {
                    SheetCell.StartRow = 0;
                    SheetCell.EndRow = 1;
                    SheetCell.StartCell = ColStart;
                    SheetCell.EndCell = ColStart;
                    SetCellRangeAddress(sheet, SheetCell);
                    ICell cell = headerRow.CreateCell(ColStart);//If Caption not set, returns the ColumnName value 
                    cell.SetCellValue(ColumnName);
                    cell.CellStyle = style;
                    ColStart++;
                }
                else
                {
                    SheetCell.StartRow = 0;
                    SheetCell.EndRow = 0;
                    SheetCell.StartCell = ColStart;
                    SheetCell.EndCell = ColStart + dic_Head[ColumnName].Keys.Count-1; 
                    SetCellRangeAddress(sheet, SheetCell);
                    ICell cell = headerRow.CreateCell(ColStart);//If Caption not set, returns the ColumnName value 
                    cell.SetCellValue(ColumnName);
                    cell.CellStyle = style;
                    ColStart = ColStart + dic_Head[ColumnName].Keys.Count;
                } 
            }
            headerRow = sheet.CreateRow(1);
            foreach (string ColumnName in dic_Head.Keys)
            {
                if (dic_Head[ColumnName] == null)
                    continue;
                foreach (string SonCell in dic_Head[ColumnName].Keys)
                {  
                    SetCellRangeAddress(sheet, dic_Head[ColumnName][SonCell]);
                    ICell cell = headerRow.CreateCell(SonColStart);
                    cell.SetCellValue(SonCell);
                    cell.CellStyle = style;
                    SonColStart++;
                }
            }
            // handling value.
            int rowIndex = 2; 
            foreach (DataRow row in table.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in table.Columns)
                {
                    ICell cell = dataRow.CreateCell(column.Ordinal);
                    cell.SetCellValue(row[column].ToString());
                    cell.CellStyle = style;
                }

                rowIndex++;
            }

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            ms.Close();
        }
        return ms;
    }
    /// <summary>
    /// 合并单元格
    /// </summary>
    /// <param name="sheet">要合并单元格所在的sheet</param>
    /// <param name="rowstart">开始行的索引</param>
    /// <param name="rowend">结束行的索引</param> 
    /// <param name="colstart">开始列的索引</param>
    /// <param name="colend">结束列的索引</param>
    public static void SetCellRangeAddress(ISheet sheet, SheetCell SheetCell)
    {
        CellRangeAddress cellRangeAddress = new CellRangeAddress(SheetCell.StartRow, SheetCell.EndRow, SheetCell.StartCell, SheetCell.EndCell);  
        sheet.AddMergedRegion(cellRangeAddress);
    }
}