// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OptionalNamedParameters {
  class Program {
    static void Main(string[] args) {
      // Using the name vs not doesn't make a difference as long as 
      // the order is the "natural" one.
      // Both of these calls go to the one-param DoSomething, even 
      // though this one would also fit: void DoSomething(int x, int y = 20)
      DoSomething(5);
      DoSomething(x: 42);

      DoSomething(5, 3);

      // Of course the order can be different when using names.
      DoSomething(y: 100, x: 13);

      // Calls to functions that return parameter values are evaluated 
      // from left to right, which may not be expected. Better not 
      // to rely on (this kind of) call sequence.
      DoSomething(y: GetY(), x: GetX());

      // Named and optional parameters in combination allow skipping.
      DoSomethingElse(z: 33);

      var man = new Man();
      var human = (Human)man;

      // As expected, resolution according to OO
      human.Walk();
      man.Walk();

      // And still - man hides human implementation, params don't come into it.
      human.Calculate(x: 10, y: 20);
      man.Calculate(x: 10, y: 20);
    }

    static void DoSomething(int x) {
      Console.WriteLine("One param DoSomething: x={0}", x);
    }

    static void DoSomething(int x, int y = 20) {
      Console.WriteLine("Two param DoSomething: x={0}, y={1}", x, y);
    }

    static int GetX() {
      Console.WriteLine("Getting X");
      return 10;
    }

    static int GetY() {
      Console.WriteLine("Getting Y");
      return 20;
    }

    static void DoSomethingElse(int x = 10, int y = 20, int z = 30) {
      Console.WriteLine("DoSomethingElse: x={0}, y={1}, z={2}", x, y, z);
    }
  }

  public class Human {
    public virtual void Walk() {
      Console.WriteLine("Human walking");
    }

    public void Calculate(int x = 20, int y = 30) {
      Console.WriteLine("Human calculating");
    }
  }

  public class Man : Human {
    public override void Walk() {
      Console.WriteLine("Man walking");
    }

    public void Calculate(int y = 20, int x = 30) {
      Console.WriteLine("Man calculating");
    }
  }
}
