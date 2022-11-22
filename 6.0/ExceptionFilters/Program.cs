using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionFilters {
  class Program {
    static void Main(string[] args) {
      try {
        CallMethod();
      }
      // The docs call this abuse of the exception filter feature 
      // "common and accepted". Fair enough.
      catch (Exception e) when (Log(e)) { }
      // Only if the "if" block evaluates to "true", the catch block will be 
      // executed. So no need to catch, check and rethrow.
      catch (ArgumentException e) when (e.Message == "the end is nigh") {
        Console.WriteLine("Won't catch this exception");
      }
      catch (ArgumentException e) when (e.Message == "message") {
        Console.WriteLine("Caught an exception");
        Console.WriteLine(e.StackTrace);
      }

      // For comparison, the "old way":
      try {
        CallMethod();
      }
      catch (ArgumentException e) {
        if (e.Message == "the end is nigh")
          Console.WriteLine("Won't catch this exception");
        else if (e.Message == "message") {
          Console.WriteLine("Caught an exception");
          Console.WriteLine(e.StackTrace);

          // Docs point out that the stack of an exception remains untouched
          // when using exception filters instead of the old catch/check/rethrow
          // approach, which is relevant if an exception has its stack dumped
          // by a debugger or similar. Note that this does NOT apply to 
          // the stack trace on the exception - the runtime keeps this intact
          // anyway, as long as a clean "throw;" is used like below.
        }
        else
          throw;
      }
    }

    static void CallMethod() {
      try {
        throw new ArgumentException("message");
      }
      catch (ArgumentException e) {
        if (e.Message == "something impossible")
          Console.WriteLine("Won't catch this exception");
        else
          throw;
      }
    }

    static bool Log(Exception e) {
      Console.WriteLine("Exception flew by: " + e.Message);
      return false;
    }
  }
}
