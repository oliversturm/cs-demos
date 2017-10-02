// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaticClasses {
  class Program {
    static void Main(string[] args) {
      MyClass.DoIt( );
    }
  }

  public static class MyClass {
    public static void DoIt( ) {
      Console.WriteLine("I'm doing it!");
    }
  }
}
