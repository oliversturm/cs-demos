using System.Diagnostics.CodeAnalysis;

namespace RequiredMembers {
  class Product {
    public string Name { get; init; }
    public decimal Price { get; init; }
  }

  class ProductWithRequiredProperties {
    public ProductWithRequiredProperties() { }

    // It would be possible to set this attribute here, and the 
    // compiler will believe it.
    // [SetsRequiredMembers]
    public ProductWithRequiredProperties(string name) {
      Name = name;
    }

    // This is where the attribute is correctly used
    [SetsRequiredMembers]
    public ProductWithRequiredProperties(string name, decimal price) {
      (Name, Price) = (name, price);
    }

    public required string Name { get; init; }
    public required decimal Price { get; init; }
  }

  class Program {
    static void Main(string[] args) {
      // This leaves Price unset since it cannot be set later
      new Product { Name = "Rubber Chicken" };

      // The same syntax with the properties marked `required` results
      // in a compiler error.
      //new ProductWithRequiredProperties { Name = "Rubber Chicken" };

      // Calling the constructor that sets the properties does not
      // help, unless the constructor uses the SetsRequiredMembers attribute
      new ProductWithRequiredProperties("Rubber Chicken", 13.99m);

      // Perhaps the best way is to use property initialization syntax
      // when properties have been declaced with `required`.
      new ProductWithRequiredProperties
      {
        Name = "Rubber Chicken",
        Price = 13.99m
      };
    }
  }
}
