namespace AliasAnyType {
  // Tuples are one typical example of the use of these new aliases.
  using Circle = (double x, double y, double radius);

  // Another obvious advantage is in the use of generic types. Keep in mind
  // that aliases only save some typing -- they don't exist at runtime.
  using IntList = List<int>;
  using Curry3 = Func<int, Func<int, Func<int, int>>>;
  using Curry8 = Func<int, Func<int, Func<int, Func<int, Func<int, Func<int, Func<int, Func<int, int>>>>>>>>;
  using Curry8String =
    Func<string, Func<string,
      Func<string, Func<string, Func<string, Func<string, Func<string, Func<string, string>>>>>>>>;

  // The aliases can't have their own generic parameters though.
  //using Curry3<T> = Func<T, Func<T, Func<T, T>>>;

  static class Program {
    static void Main(string[] args) {
      // Circle is not use automatically -- this is not F#.
      var c1 = (10, 10, 20);
      Console.WriteLine($"c1 = {c1}, type of c1={c1.GetType()}");

      // This tuple type is compatible with Circle
      var c2 = (10.0, 10.0, 20.0);
      Console.WriteLine($"c2 = {c2}, type of c2={c2.GetType()}");

      // Now we use Circle explicitly to influence the type inference,
      // but the type is still the same as before.
      Circle c3 = (10, 10, 20);
      Console.WriteLine($"c3 = {c3}, type of c3={c3.GetType()}");
    }
  }
}