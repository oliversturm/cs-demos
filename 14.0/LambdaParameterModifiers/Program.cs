namespace LambdaParameterModifiers;

delegate bool TryParse<T>(string text, out T result);
delegate void RefAction<T>(ref T value);

class Program {
  static void Main(string[] args) {
    // Before C# 14, adding parameter modifiers to a lambda required
    // specifying the full types for all parameters:
    TryParse<int> parseOldStyle = (string text, out int result) =>
      int.TryParse(text, out result);

    // Now you can use modifiers without explicit types. The compiler
    // infers the types from the delegate.
    TryParse<int> parseNewStyle = (text, out result) =>
      int.TryParse(text, out result);

    Console.WriteLine($"Old style parse '42': {parseOldStyle("42", out var r1)} -> {r1}");
    Console.WriteLine($"New style parse '42': {parseNewStyle("42", out var r2)} -> {r2}");
    Console.WriteLine($"New style parse 'abc': {parseNewStyle("abc", out var r3)} -> {r3}");

    // Works with ref parameters too
    RefAction<int> doubleIt = (ref value) => value *= 2;
    int number = 21;
    doubleIt(ref number);
    Console.WriteLine($"Doubled: {number}");

    // Works with scoped and ref readonly as well.
    // The key benefit is that you no longer need to spell out full type
    // names just to add a modifier, which was especially annoying with
    // long generic type names.

    // Note: `params` still requires an explicitly typed parameter list.
  }
}
