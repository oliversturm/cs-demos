namespace AllowsRefStruct;

internal class Program {
  private static void Main(string[] args) {
    TakeThis(10);
    TakeThis("hello");

    // The ref struct Span<T> is not normally accepted as a type argument
    //TakeThis(Span<int>.Empty);
  }

  // Add the part "where T: allows ref struct" to allow ref structs. Duh.
  // Be aware that you can't treat ref structs as objects, so the GetType()
  // call for instance doesn't work.
  private static void TakeThis<T>(T thing) /* where T : allows ref struct */ {
    Console.WriteLine("Took a thing, it's type is " + thing.GetType());
  }

  // Microsoft says they already have many library methods that use ref structs,
  // in generic arguments as well. Like this example, where the type is external
  // and the method itself just passes it through.
  // public static string Create<TState>(int length, TState state, SpanAction<char, TState> action)
  //   where TState : allows ref struct;
}