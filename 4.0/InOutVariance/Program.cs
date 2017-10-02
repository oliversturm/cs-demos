// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InOutVariance {
  class Program {
    static void Main(string[] args) {
      // This didn't work in C# 3.0. Now it does.
      // (Test in 2008 for C# 3.0 - setting VS 2010 to C# 3.0 doesn't show the correct behaviour.)
      var strings = new List<string> { "one", "two" };
    //IList<string>
      IEnumerable<object> objects = strings;
      foreach (object @object in objects)
        Console.WriteLine(@object);

      //objects.Add(42);


      // The reason this never worked is that you could then try to
      // write code like this - obviously not intended to work.
      // This cast results in a runtime exception:
      //IList<object> objectsList = (IList<object>) strings;
      //objectsList.Add(42);

      // So the question is, how do you allow certain types of such casts?
      // The following works in C# 4.0, because my interface ICage uses "out" on the type parameter
      // to specify that it can only be output from the interface. Thereby
      // T becomes covariant.
      // Note that this works only when I use the interface. The same thing
      // wouldn't work with the class type(s), because in/out can only
      // be specified on interfaces and delegates, apparently due to a CLR
      // restriction.
      var birdcage = new Cage<Bird>() as ICage<Bird>;
      var animalcage = (ICage<Animal>) birdcage;

      // This second step becomes possible because I'm using "in" on the 
      // IMyComparer interface. I know that EqualTo can accept an Eagle for a Bird,
      // because an Eagle is a type of bird. But the compiler only understands
      // this with the help of the "in" keyword.
      var eagle = new Eagle( );
      ((IMyComparer<Eagle>) birdcage).EqualTo(eagle);

      // The standard IEnumerable<T> interface uses out with its type parameter.
      //IEnumerable<string> foo;

      // Similarly, some interfaces support contra-variance using
      // the keyword "in" on type parameters. 
      //IComparer<string> comp;
    }
  }

  public interface ICage<out T> {
    T GetValue();
    void AcceptValue(T p);
  }

  public interface IMyComparer<in T> {
    bool EqualTo(T other);
  }

  class Cage<T> : ICage<T>, IMyComparer<T> {
    T value = default(T);

    T ICage<T>.GetValue() {
      return value;
    }

    bool IMyComparer<T>.EqualTo(T other) {
      // no real implementation, obviously
      return true;
    }
  }

  public class Animal {
  }

  public class Bird : Animal {
  }

  public class Eagle : Bird {
  }
}
