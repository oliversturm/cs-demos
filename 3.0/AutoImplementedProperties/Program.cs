// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoImplementedProperties {
  class Program {
    static void Main(string[] args) {
    }
  }

  public class Person {
    public string Name { get; set; }
    public int Age { get; private set; }
  }
}
