namespace Unions;

class Program {
  // This is an early example published by Microsoft
  //
  // Existing types as union cases
  public record Cat(string Name);
  public record Dog(string Name);
  public record Bird(string Name);

  public union Pet(Cat, Dog, Bird);

  public record Circle(double Radius);
  public record Square(double Side);
  public record Triangle(double Base, double Height);

  // Can also use structs...
  // public record struct Circle(double Radius);
  // public record struct Square(double Side);
  // public record struct Triangle(double Base, double Height);

  // The union itself is a struct
  public union Shape(Circle, Square, Triangle);

  static double Area(Shape s) => s switch {
    Circle c => Math.PI * c.Radius * c.Radius,
    Square sq => sq.Side * sq.Side,
    Triangle t => 0.5 * t.Base * t.Height,
    // No default needed — compiler verifies **case** exhaustiveness
    // Try removing one arm and the compiler will complain about the missing case.

    // However - to prevent the compiler from complaining entirely, we need
    // to handle the null case... what null case, you ask?
    // The union *struct* has a value field of type `object?`
    // -- check it out with
    // `ilspycmd bin/Debug/net11.0/unions.dll` after building
    // in the devcontainer.
    null => throw new ArgumentNullException(nameof(s)),
  };

  static void Main(string[] args) {
    Pet pet = new Cat("Whiskers");
    Console.WriteLine(pet switch {
      Cat c => $"Cat: {c.Name}",
      Dog d => $"Dog: {d.Name}",
      Bird b => $"Bird: {b.Name}",
    });

    Console.WriteLine($"Circle area: {Area(new Circle(2.0)):F2}");
    Console.WriteLine($"Square area: {Area(new Square(3.0)):F2}");
  }
}