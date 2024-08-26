// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

namespace PartialMethods;

internal class Program {
  private static void Main(string[] args) {
    Generated generated = new Generated();
    generated.DoSomething();
  }
}

internal partial class Generated {
  // If this implementation is commented out, the compiler
  // gets rid of the call to PartialMethod() in the
  // Generated.DoSomething method. You can verify this by
  // looking at Reflector.

  partial void PartialMethod() {
    Console.WriteLine("Partial Method executed");
  }
}

internal partial class Generated {
  private int generatedField;

  public void DoSomething() {
    generatedField = 10;
    PartialMethod();
  }

  partial void PartialMethod();

  // This method is not implemented and it will be removed.
  // Note that it must use the default visibility -- even
  // the use of the "private" keyword will make the compiler complain.
  partial void AnotherPartialMethod();

  //private partial void YetAnotherPartialMethod();
}