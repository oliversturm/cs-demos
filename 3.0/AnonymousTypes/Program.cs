// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousTypes {
  class Program {
    static void Main(string[] args) {
      var person = new {
        Name = "Willy",
        Age = 33
      };
      var person2 = new {
        Age = 42,
        Name = "Harry"
      };

      // This doesn't work - it's a different type
      //person = person2;
    }
  }
}
