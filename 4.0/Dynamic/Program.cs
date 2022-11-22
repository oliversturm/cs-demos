// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;
using System.Dynamic;

namespace Dynamic {
  class Program {
    static void Main(string[] args) {
      dynamic i = 42;
      dynamic s = "Hi there";

      // calling stuff on dynamic instances isn't checked at compile time
      //i.DoSomethingImpossible();

      Console.WriteLine("-------------------------------------");
      PythonScript();

      Console.WriteLine("-------------------------------------");
      DoFall(new Leaf());
      DoFall(new ExchangeRate());

      DoFall(42);

      Console.WriteLine("-------------------------------------");
      foreach (var val in GetStuff())
        Console.WriteLine(val);

      Console.WriteLine("-------------------------------------");
      dynamic myObject = new MyDynamicType();
      myObject.Blurb();
      myObject.Argh();
      myObject.Oops();
      DoFall(myObject);
    }

    private static void PythonScript() {
      Console.WriteLine("Loading script.py...");
      ScriptRuntime python = Python.CreateRuntime();
      dynamic script = python.UseFile("4.0/Dynamic/script.py");
      Console.WriteLine("script.py loaded!");

      script.doSomething();
    }

    static IEnumerable<dynamic> GetStuff() {
      yield return "a string";
      yield return 42;
      yield return true;
    }

    static void DoFall(dynamic thing) {
      try {
        thing.Fall();
      }
      catch {
        Console.WriteLine("Turns out {0} can't fall.", thing);
      }
    }
  }

  public class Leaf {
    public void Fall() {
      Console.WriteLine("Leaf is falling");
    }
  }

  public class ExchangeRate {
    public Action Fall {
      get {
        return () =>
          Console.WriteLine("Exchange rate is falling");
      }
    }
  }

  public class MyDynamicType : DynamicObject {
    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) {
      Console.WriteLine("Invoking member {0}", binder.Name);
      result = null;
      return true;
    }
  }
}
