// Copyright (C) 2012 Oliver Sturm <oliver@oliversturm.com>. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait {
  class Program {
    static void Main(string[] args) {
      //      PrintWaitPrint();
      LoopFiveTimes();
      while (true) {
        Console.WriteLine("Main program is alive, Task id={0}, Thread id={1}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(100);
      }
    }

    // The method uses await, so it has to be declared async
    async static void LoopFiveTimes() {
      for (int i = 0; i < 5; i++) {
        // We'll run the PrintWaitPrint method in the background, then return
        // to the main program right away. The following code, i.e. the next loop
        // run, is scheduled for execution once PrintAndWait returns.
        await PrintWaitPrint();
      }
    }

    async static Task PrintWaitPrint() {
      // I'll output the thread and task ids on each line. Sometimes it is possible to spot that 
      // different executions are scheduled on different threads (Win8/.NET 4.5). Running in the 
      // debugger seems to make this more likely.
      // Update - this doesn't render any useful information in modern .NET versions.

      try {
        Console.WriteLine("First output from PrintWaitPrint, Task id={0}, Thread id={1}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
        await Task.Delay(1000);
        Console.WriteLine("Second output from PrintWaitPrint, Task id={0}, Thread id={1}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
      }
      finally {
        Console.WriteLine("Done with PrintWaitPrint");
      }
    }
  }
}
