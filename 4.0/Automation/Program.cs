// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

// Purely for illustration purposes. This type of code would still work,
// in the right environment and with the right project setup.
// But for this sample project I'm including it only as a reference.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

namespace Automation {
  class Program {
    static void Main(string[] args) {
      Automation();
    }

    static void Automation() {
      dynamic excel = new Excel.Application();

      dynamic workbook = excel.Workbooks.Add();
      dynamic sheet = excel.ActiveSheet;

      excel.Visible = true;
      // Cells returns a dynamic
      excel.Cells[1, 1] = "Hi from C#!";
      excel.Columns[1].AutoFit();

      excel.Cells[2, 1] = 10;
      excel.Cells[3, 1] = 15;
      excel.Cells[4, 1] = 20;
      excel.Cells[5, 1] = 30;
      excel.Cells[6, 1] = 8;

      dynamic chart = workbook.Charts.Add(After: sheet);
      chart.ChartWizard(Source: sheet.Range("A2", "A6"));
    }
  }
}
