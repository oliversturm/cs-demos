namespace FieldKeyword;

class Program {
  static void Main(string[] args) {
    var person = new Person();
    person.Name = "Oli";
    Console.WriteLine($"Name: {person.Name}");

    // The setter validates, so null throws
    try {
      person.Name = null!;
    }
    catch (ArgumentNullException e) {
      Console.WriteLine($"Caught: {e.ParamName}");
    }

    // Lazy initialization -- value is computed on first access
    var calc = new ExpensiveCalculation();
    Console.WriteLine($"Result: {calc.Result}");
    Console.WriteLine($"Result again (cached): {calc.Result}");

    // Clamped value
    var sensor = new Sensor();
    sensor.Temperature = 150;
    Console.WriteLine($"Temperature: {sensor.Temperature}");
    sensor.Temperature = -50;
    Console.WriteLine($"Temperature: {sensor.Temperature}");
  }
}

class Person {
  // Before C# 14, adding validation to a setter required a manual
  // backing field:
  //
  //   private string _name = "Unknown";
  //   public string Name {
  //     get => _name;
  //     set => _name = value ?? throw new ArgumentNullException(nameof(value));
  //   }
  //
  // Now, `field` refers to the compiler-generated backing field directly.
  // You can write a body for one or both accessors.

  public string Name {
    get;
    set => field = value ?? throw new ArgumentNullException(nameof(value));
  } = "Unknown";

  // Note that `field` is only a contextual keyword -- it only has special
  // meaning inside a property accessor. If you have an existing symbol
  // called `field`, you can disambiguate with @field or this.field.
}

class ExpensiveCalculation {
  // Lazy initialization: the getter computes the value on first access.
  // Using a nullable type so that ??= can detect the uninitialized state.
  public string Result {
    get => field ??= ComputeExpensiveResult();
  }

  private string ComputeExpensiveResult() {
    Console.WriteLine("  (computing expensive result...)");
    return $"{Math.PI * Math.E}";
  }
}

class Sensor {
  // Clamping in the setter while keeping a simple getter
  public int Temperature {
    get;
    set => field = Math.Clamp(value, 0, 100);
  }
}
