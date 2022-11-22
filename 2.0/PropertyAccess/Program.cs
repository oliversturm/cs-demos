// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyAccess {
  class Program {
    static void Main(string[] args) {
    }
  }

  public class MyData {
    private string textVal;
    public string TextVal {
      get { return textVal; }
      protected set {
        textVal = value;
      }
    }

  }
}
