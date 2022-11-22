using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingStaticClasses {
  using static System.Console;

  // be sure to declare the class "static" if you'd like to be able
  // to use it with a using statement
  using static Helpers;

  using static System.Linq.Enumerable;

  class Program {

    static void Main(string[] args) {
      WriteLine("output");

      Helpers.DoSomethingToHelp();
      DoSomethingToHelp();
    }

    static void ExtensionMethodDetails() {
      // Range is an ordinary static method on the Enumerable class
      var range = Range(10, 20);

      // Where is an extension method, but is called like a basic static 
      // function here. This call  requires full namespace
      // qualification:
      var oddNumbers = System.Linq.Enumerable.Where(range, x => x % 2 == 1);

      // Using Where as an extension method is possible (the extension
      // is brought into scope by the using statement) 
      var oddNumbers_ = range.Where(x => x % 2 == 1);

    }
  }
}

public static class Helpers {
  public static void DoSomethingToHelp() {
  }
}
