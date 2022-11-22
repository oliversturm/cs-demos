using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullConditionalOperators {
  class Program {
    static void Main(string[] args) {
      var values = new[] { 1, 2, 3 };
      //values = null;

      // if values is non-null, output its length - 
      // the ? is short-circuiting and evaluates to null if the 
      // expression on its left is null
      Console.WriteLine(values?.Length);

      // easy to use with nullable types
      int? length = values?.Length;

      // combine with the null coalescing operator for even more fun
      int length_ = values?.Length ?? 0;

      // for clarity, this is basically the old-style expression we're replacing
      // even better, short circuiting means that the ? expression evaluates
      // "values" only once - after all, that expression could be more complex
      // than it is here. The old-style expression evaluates this more than once.
      int length__ = values != null ? values.Length : 0;

      Func<int, int> f = x => x * x;

      // checking delegates for non-null values is possible, but they can't be 
      // called directly - this syntax is obvious, but NOT valid.
      // (The rationale is that there were syntax collisions with the C# ternary
      // operator - at my request, I haven't received any actual example yet from 
      // Mads. He suggested it might be possible to support this after all and 
      // they would look into it in more detail. Update - guess this won't happen
      // at this time...)
      //int? result = f?(10);

      // however, we can invoke the delegate explicitly:
      int? result = f?.Invoke(10);

      // Microsoft points out that this pattern for event invokation is fast 
      // as well as thread-safe, because the implementation takes care
      // to cache the evaluation result of the left hand side.
      //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Property"));
    }
  }
}
