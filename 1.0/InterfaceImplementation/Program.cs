// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceImplementation {
  class Program {
    static void Main(string[] args) {
      ImplicitImplementation impImp = new ImplicitImplementation();
      Console.WriteLine(impImp.GetVal("text"));
      Console.WriteLine(impImp.Date);

      IMyInterface expImp = new ExplicitImplementation();
      Console.WriteLine(expImp.GetVal("text"));
      Console.WriteLine(expImp.Date);
    }
  }

  public interface IMyInterface {
    int GetVal(string p);
    DateTime Date { get; }
  }

  public class ImplicitImplementation : IMyInterface {
    // The class happens to have a set of members that match the interface

    public int GetVal(string p) {
      return 42;
    }

    public DateTime Date {
      get { return DateTime.Today; }
    }
  }

  public class ExplicitImplementation : IMyInterface {
    int IMyInterface.GetVal(string p) {
      return 42;
    }

    DateTime IMyInterface.Date {
      get { return DateTime.Today; }
    }
  }
}
