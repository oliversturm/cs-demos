// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Closures {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine(Closures()(30));





    }






    static Func<int, int> Closures( ) {
      int baseVal = 10;

      Func<int, int> add = val => baseVal + val;


      Console.WriteLine(add(10));

      baseVal = 50;
      Console.WriteLine(add(10));

      return add;
    }
  }
}
