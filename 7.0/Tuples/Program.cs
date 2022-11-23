using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuples {
  class Program {
    // Make sure to add nuget package System.ValueTuple to your project.

    static void Main(string[] args) {
      var name1 = GetName();
      Console.WriteLine($"Name is {name1.Item1} {name1.Item2}");

      var name2 = GetName_();
      Console.WriteLine($"Name is {name2.first} {name2.last}");


      // Deconstructing tuple values
      (var first, var last) = GetName();

      // alternatively, 'var' can be outside the parens
      var (first_, last_) = GetName();

      // Using a static type outside the parens is not allowed. Not sure why not.
      // string (first__, last__) = GetName();

      // Variables may be defined before the deconstruction
      string first__, last__;
      (first__, last__) = GetName();

      // In C# 7, either none or all variables could be defined
      // before deconstruction. From C# 10, it can be a mix.
      (first__, var anotherLast) = GetName();

      Console.WriteLine($"Name is {first} {last}");

      // Deconstructing my own type
      var person = new Person { Name = "Oli", Age = 32 };
      var (name, age) = person;

      Console.WriteLine($"{name} is {age} years old");

      // VS 17 RC build 26127: DO NOT point the mouse at one of the wildcard
      // _ characters, it crashes VS.

      // Wildcards can be used to ignore parts during deconstruction:
      (_, var age_) = person;

      Console.WriteLine($"Age is {age_}");

      (_, _, var three, _) = GetComplex();
      Console.WriteLine($"Three is {three}");
    }

    static (string, string) GetName() {
      return ("Oliver", "Sturm");
    }

    static (string first, string last) GetName_() {
      // note that I'm using the wrong names for the return values
      // this works in preview 4, I expect it shouldn't really work...
      // Update: preview 5 still compiles this, but there's a 
      // warning being shown explaining that the name given 
      // here is ignored because the method signature declares 
      // a different one.
      return (firstName: "Oliver", lastName: "Sturm");
    }

    static (string one, int two, string three, int four) GetComplex() {
      return ("10", 20, "30", 40);
    }
    public class Person {
      public string Name { get; set; }
      public int Age { get; set; }

      public void Deconstruct(out string name, out int age) {
        name = Name;
        age = Age;
      }
    }
  }
}
