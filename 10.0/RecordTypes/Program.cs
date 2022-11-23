namespace RecordTypes {
  // Here's the product again from C# 9
  public record Product(string Name, decimal Price);

  // This is the same thing from C# 10 -- `class` is optional
  public record class Product2(string Name, decimal Price);

  // The new thing is that there are also record structs.
  // For a laugh, positional properties in record structs are
  // mutable by default.
  public record struct ProductStruct(string Name, decimal Price);

  // To make a record struct immutable, `readonly` can be added
  public readonly record struct ProductStructReadonly(string Name, decimal Price) {
    // Adding properties is allowed, but they must also be readonly
    // This does not work
    // public string Extra { get; set; }
  }

  class Program {
    static void Main(string[] args) {
      var p1 = new Product("Rubber Chicken", 13.99m);
      var p2 = new Product2("Rubber Chicken", 13.99m);

      var ps = new ProductStruct("Rubber Chicken", 13.99m);
      ps.Name = "Broken Rubber Chicken";

      var psr = new ProductStructReadonly("Rubber Chicken", 13.99m);
      //psr.Name = "Broken Rubber Chicken";

      // Rendering works as before
      Console.WriteLine(p1);
      Console.WriteLine(p2);
      Console.WriteLine(ps);

      // Equality works the same as with record classes.
      // https://sharplab.io tells me that record structs also have a 
      // compiler-generated equality implementation and do not rely on
      // struct based value equality or reflection.
      var p1_ = new Product("Rubber Chicken", 13.99m);
      Console.WriteLine($"Reference equals: {Object.ReferenceEquals(p1, p1_)}");
      Console.WriteLine($"Value equality: {p1 == p1_}");

    }
  }
}
