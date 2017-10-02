// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullCoalescing {
  class Program {
    static void Main(string[] args) {
      string hello = "Hello ";
      string name = null;
      string unknown = "unknown user";

      string message = hello + (name ?? unknown);
      Console.WriteLine(message);
    }
  }
}
