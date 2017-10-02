// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Var {
  class Program {
    static void Main(string[] args) {
      var i = 5;
      var s = "Hello";
      var d = 1.5;

      var numbers = new int[] { 1, 2, 3 };
      var orders = new Dictionary<string, Order>( );

      // Invalid uses:
      //var foo;
      //var array = { 1, 2, 3 };
      //var bar = null;
    }

    // Invalid here as well:
    //var x = 10;

    class Order {
      public Order( ) {

      }
    }
  }
}
