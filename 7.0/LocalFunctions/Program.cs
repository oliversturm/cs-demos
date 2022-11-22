using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunctions {
  class Program {
    static void Main(string[] args) {
      // From VS 15 preview 5, it is possible to call the function before declaring it,
      // as long as it is eventually declared in the local scope.
      GoDoIt();

      void GoDoIt() {
        Console.WriteLine("Doing it right now!");
      }

      GoDoIt();

      // Cool thing: local functions can be iterators - lambdas can't
      //Func<IEnumerable<int>> iteratorLambda = () =>
      //{
      //    yield return 1;
      //    yield return 2;
      //};

      IEnumerable<int> Iterator() {
        yield return 1;
        yield return 2;
      }

      foreach (var i in Iterator())
        Console.WriteLine(i);
    }
  }
}
