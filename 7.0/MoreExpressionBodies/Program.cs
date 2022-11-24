using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreExpressionBodies {
  public class Product {
    // Expression body syntax can now be used to declare more elements than 
    // in C# 6.

    // Constructor:
    public Product(string name) => Name = name;
    public string Name { get; }

    // Destructor:
    ~Product() => Console.WriteLine("This product is done");

    // Property getter and setter:
    public decimal CurrentPrice {
      get => GetCurrentPrice();
      set => SetCurrentPrice(value);
    }

    // Also indexed properties
    public ProductPart this[int index] {
      get => GetProductPart(index);
      set => ChangeProductPart(index, value);
    }

    // And this is the "old" thing, method implementations. But beware --
    // implementations like the Console.WriteLine lines can be confusing
    // because they don't really return anything and can be seen as 
    // abuse of the "expressions only" idea. In some peoples' minds,
    // real expressions should not return void.
    decimal GetCurrentPrice() => 4.3m;
    void SetCurrentPrice(decimal p) => Console.WriteLine("New price is ", p);
    ProductPart GetProductPart(int index) => null;
    void ChangeProductPart(int index, ProductPart value) => Console.WriteLine($"Using part {value} for index {index}");
  }

  public class ProductPart { }

  class Program {
    static void Main(string[] args) {
    }
  }
}
