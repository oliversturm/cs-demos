namespace PartialConstructorsAndEvents;

class Program {
  static void Main(string[] args) {
    // Partial constructors and events extend the partial member concept
    // that was introduced for methods (C# 3.0) and properties (C# 13).

    var widget = new Widget("Test Widget");
    Console.WriteLine($"Created: {widget.Name}, ID: {widget.Id}");

    widget.StatusChanged += (sender, status) =>
      Console.WriteLine($"  Status changed to: {status}");
    widget.Activate();
    widget.Deactivate();
  }
}

// Partial constructors work like partial methods and properties:
// one *defining* declaration and one *implementing* declaration.
// This is useful for source generator scenarios where generated
// code provides the boilerplate and hand-written code adds logic.

// Defining declaration - could be in a source-generated file
partial class Widget {
  public string Name { get; }
  public string Id { get; }

  // Defining declaration of the constructor
  public partial Widget(string name);

  // Defining declaration of the event (field-like)
  public partial event EventHandler<string>? StatusChanged;
}

// Implementing declaration - hand-written code
partial class Widget {
  // Only the implementing declaration can include a constructor
  // initializer (`: this()` or `: base()`).
  public partial Widget(string name) {
    Name = name;
    Id = Guid.NewGuid().ToString()[..8];
    Console.WriteLine($"  (Constructor ran for '{name}')");
  }

  // The implementing declaration must include add and remove accessors.
  private EventHandler<string>? statusChanged;
  public partial event EventHandler<string>? StatusChanged {
    add {
      Console.WriteLine("  (Event handler added)");
      statusChanged += value;
    }
    remove {
      Console.WriteLine("  (Event handler removed)");
      statusChanged -= value;
    }
  }

  public void Activate() => statusChanged?.Invoke(this, "Active");
  public void Deactivate() => statusChanged?.Invoke(this, "Inactive");
}