using System;
using static System.Console;
using Excel = Microsoft.Office.Interop.Excel;

namespace COMInterop
{
    class MainApp
    {
        static void Main()
        {
            string savePath = System.IO.Directory.GetCurrentDirectory();
            string[,] array = new string[,]
            {
                { "뇌를 자극하는 알고리즘", "2009"},
                { "뇌를 자극하는 C# 4.0", "2011"},
                { "뇌를 자극하는 C# 5.0", "2013"},
                { "뇌를 자극하는 파이썬3", "2016"},
                { "이것이 C#이다", "2018"}
            };

            WriteLine("Creating Excel document in new way...");
            ExcelCOM(array, savePath);
            
        }
        public static void ExcelCOM(string[,] data, string savePath)
        {
            Excel.Application excelApp = new Excel.Application(); // Excel App 생성
            Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing); //sheet1 포함된 빈 워크북 생성
            Excel.Worksheet worksheetA = workbook.Worksheets.Item["Sheet1"]; //sheet1 객체 가져오기
            Excel.Worksheet worksheetB = workbook.Worksheets.Add(After: worksheetA); //sheet1 뒤에 새 워크시트 추가
            Excel.Range range = null;


            for (int i = 0; i < data.GetLength(0); i++)
            {
                worksheetA.Cells[i + 1, 1] = data[i, 0]; // Cells[열, 행], data[2차, 1차]
                worksheetA.Cells[i + 1, 2] = data[i, 1];
            }

            range = worksheetB.Cells[1, 1]; //sheet2 | A1
            range.Formula= "Sheet2"; //sheet1 뒤 시트 | A1 기록

            range = worksheetB.Cells[2, 1]; //sheet2 | A2
            range.Formula = "Sheet2"; //sheet1 뒤 시트 | A1 기록


            worksheetA.SaveAs(savePath + "\\shpark-book.xlsx"); // sheep1 저장
            excelApp.Quit(); //Excel App 종료
        }
    }
}
