using System.Runtime.CompilerServices;

namespace CallerArgumentExpressions {
  class Program {

    // The compiler creates the string passed to `messageThat`, in a 
    // form that would be impossible to retrieve at runtime.
    static void Assert(bool that,
      [CallerArgumentExpression("that")] string? messageThat = default) {
      if (!that)
        throw new Exception($"Turns out that's untrue: {messageThat}");
    }

    // Even a somewhat complex parameter can be formatted
    static void Assert(Func<bool> checker,
      [CallerArgumentExpression("checker")] string? messageChecker = default) {
      if (!checker())
        throw new Exception($"Turns out that's untrue: {messageChecker}");
    }

    static void Main(string[] args) {
      Assert(100 == 101);
      //Assert(() => 100 == 101);
    }
  }
}
