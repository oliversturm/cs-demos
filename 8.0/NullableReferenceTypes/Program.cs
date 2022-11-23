namespace NullableReferenceTypes {
  public class Thing {
    public Thing(string val) {
      Val = val;
    }
    public string Val { get; }
    public void Show() {
      Console.WriteLine($"Thing with value '{Val}'");
    }
  }

  class Program {
    static void Main(string[] args) {
      Thing withValue = new Thing("value");
      withValue.Show();

      // The following line renders a warning because the type is not 
      // marked to allow nulls. The feature is technically still 
      // off by default, but templates since C# 10 activate it so
      // the default is not off anymore for newly created projects.
      // This is one of the biggest changes ever applied to C# --
      // without <Nullable>enable</Nullable>, ever since C# 1.0,
      // reference types always accepted null values.
      Thing withoutValue = null;

      // The same thing happens when you use the `default` literal, obviously
      // Thing withoutValue = default;

      // This syntax says we know that there may not be a value -- 
      // the warning goes away.
      // Thing? withoutValue = null;

      // This line attempts to dereference the possibly-null value,
      // and again the compiler knows this and warns.
      //Console.WriteLine(withoutValue.Val);

      // We could check for null values -- at least like this:
      Console.WriteLine(withoutValue?.Val);

      // If we think we know better, we can also tell the compiler
      // to assume there is no null value. This is really the chicken
      // way out though, and will probably backfire unless you know
      // very precisely why you're doing it.
      Console.WriteLine(withoutValue!.Val);
    }
  }
}
