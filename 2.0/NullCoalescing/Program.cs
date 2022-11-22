// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullCoalescing {
  class Program {
    static void Main(string[] args) {
      string hello = "Hello ";
      // Note for current C# versions: project config has Nullable:disable
      // In the C# 2.0 timeframe this was not a concern. 
      string name = null;
      string unknown = "unknown user";

      string message = hello + (name ?? unknown);
      Console.WriteLine(message);
    }
  }
}
