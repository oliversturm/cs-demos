using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameOf {
  class Program {
    static void Main(string[] args) {
      // nameof can accept a fully qualified type name, but it'll only return
      // the last part of it (here: "ICollection<string>")
      // Update -- late C# versions only say ICollection here
      Console.WriteLine(nameof(System.Collections.Generic.ICollection<string>));

      // we can refer to methods as well:
      Console.WriteLine(nameof(Console.WriteLine));

    }

    // When there's the need to include the names of types or variables in program
    // output, nameof can get hold of that string for us. The point: being able to
    // refactor without breaking string literals of this kind.
    static string Concat(string a, string b) {
      if (string.IsNullOrEmpty(a))
        throw new ArgumentException("String must be given", nameof(a));
      if (string.IsNullOrEmpty(b))
        throw new ArgumentException("String must be given", nameof(b));
      return a + b;
    }
  }
}
