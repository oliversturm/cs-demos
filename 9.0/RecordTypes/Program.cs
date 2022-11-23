namespace RecordTypes {
  // For property names that use standard casing, i.e. begin with 
  // capital letters, these names must be reflected in the positional
  // parameters of the declaration.
  public record Product(string Name, decimal Price);

  // This type is mostly equivalent to the first one, but requires
  // property init syntax on creation.
  // Btw -- the "init only setters" shown here are a new C# 9 feature as well.
  // Properties with `init` can only be set during construction, i.e. from a 
  // constructor or via a property initializer.
  public record Product2 {
    public string Name { get; init; } = default!;
    public decimal Price { get; init; } = default!;
  }

  // Somewhat strange hybrids are also possible
  public record Product3(string Name) {
    public decimal Price { get; init; } = default!;
  }

  // To water down the concept a bit (ahem), changeable properties are allowed
  public record ChangeableProduct {
    public string Name { get; set; } = default!;
    public decimal Price { get; set; } = default!;
  }

  // Just to see some about a deconstruction below
  public record TestThing(string One, int Two) {
    public bool Yeah { get; init; } = default!;
    public void Deconstruct(out string one, out int two, out bool yeah) {
      one = One;
      two = Two;
      yeah = Yeah;
    }
  }

  // Records can derive from other records -- not from classes, and classes not from records
  // Note that Price does not create a new property on this level -- change to "price" or 
  // another name altogether and then it does.
  public record RubberChicken(decimal Price, bool IncludesPulley) : Product("Rubber Chicken", Price) {
    // Records can include methods
    public void TravelWithPulley() {
      if (!IncludesPulley)
        throw new InvalidOperationException("Pulley required to travel");
      Console.WriteLine("Weeeee!!");
    }
  }


  class Program {
    static void Main(string[] args) {
      var p1 = new Product("Rubber Chicken", 13.99m);
      var p2 = new Product2 { Name = "Rubber Chicken", Price = 13.99m };
      var p3 = new Product3("Rubber Chicken") { Price = 13.99m };

      var pc = new ChangeableProduct { Name = "Rubber Chicken", Price = 13.99m };
      pc.Name = "Pulley";
      pc.Price = 1.99m;

      var rubberChicken = new RubberChicken(15.99m, true);
      rubberChicken.TravelWithPulley();

      // Records have automatic rendering, for all syntax variants shown above
      Console.WriteLine(p1);
      Console.WriteLine(p2);
      Console.WriteLine(p3);
      Console.WriteLine(pc);
      Console.WriteLine(rubberChicken);

      // Automatic value equality, like structs but unlike many reference types
      // Value equality checks are compiler generated and therefore much more
      //   performant than the reflection based mechanism used in structs.
      var p1_ = new Product("Rubber Chicken", 13.99m);
      Console.WriteLine($"Reference equals: {Object.ReferenceEquals(p1, p1_)}");
      Console.WriteLine($"Value equality: {p1 == p1_}");

      // Deconstruction is supported...
      var (name1, price1) = p1;
      // ... but only for positional properties. This does not work:
      // var (name3, price3) = p3;

      // As long as there's more than one positional property, a deconstructor
      // is automatically created.
      var tt = new TestThing("one", 2) { Yeah = true };
      var (one, two) = tt;

      // This type has an additional destructor I created manually.
      var (one_, two_, yeah_) = tt;
      Console.WriteLine($"Test thing has one={one_}, two={two_} and yeah={yeah_}");

      // Nondestructive mutation -- i.e. cloning with changes. Supported directly,
      // and very performantly. Definitely the way to go for immutable data patterns.
      var moreExpensiveRubberChickenButNoPulley = rubberChicken with { Price = 18.99m, IncludesPulley = false };
      Console.WriteLine(moreExpensiveRubberChickenButNoPulley);
    }
  }
}
