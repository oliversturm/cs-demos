// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullableTypes {
  class Program {
    static void Main(string[] args) {
      int? i = null;
      int? j = 5;

      i = 5;

      if (i == j)
        Console.WriteLine("Values are equal");

      // ... equivalent to this:

      Nullable<int> ni = null;
      Nullable<int> nj = 5;

      ni = 5;

      if (ni == nj)
        Console.WriteLine("Values are equal");
    }
  }
}
