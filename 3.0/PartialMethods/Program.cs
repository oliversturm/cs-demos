// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartialMethods {
  class Program {
    static void Main(string[] args) {
      var generated = new Generated( );
      generated.DoSomething( );
    }
  }

  partial class Generated {
    // If this implementation is commented out, the compiler
    // gets rid of the call to PartialMethod() in the
    // Generated.DoSomething method. You can verify this by
    // looking at Reflector.

    partial void PartialMethod( ) {
      Console.WriteLine("Partial Method executed");
    }
  }

  partial class Generated {
    private int generatedField;

    public void DoSomething( ) {
      generatedField = 10;
      PartialMethod( );
    }

    partial void PartialMethod( );
  }
}
