// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Using {
  class Program {
    static void Main(string[] args) {
      using (MyType t = new MyType( )) {
        t.DoSomething( );
      }

      // ... equivalent to this:
      MyType t2 = new MyType();
      try {
        t2.DoSomething( );
      }
      finally {
        IDisposable dispT = t2 as IDisposable;
        if (dispT != null)
          dispT.Dispose( );
      }
    }
  }

  class MyType : IDisposable {
    public void DoSomething( ) {
      Console.WriteLine("Doing something");
    }
    void IDisposable.Dispose( ) {
      Console.WriteLine("Disposing myself");
    }
  }
}
