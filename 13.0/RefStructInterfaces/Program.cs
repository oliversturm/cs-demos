namespace RefStructInterfaces;

public interface IMovable {
  public int DistanceFromZero { get; set; }
  void Advance();
}

public ref struct Turtle : IMovable {
  public int DistanceFromZero { get; set; }

  public void Advance() {
    // Turtle moves slowly
    DistanceFromZero++;
  }
}

public ref struct Person : IMovable {
  public int DistanceFromZero { get; set; }

  public void Advance() {
    // Person moves much more quickly than a turtle
    DistanceFromZero += 10;
  }
}

public class Program {
  private static void Main(string[] args) {
    Turtle turtle = new();
    Person person = new();

    // It is not possible to directly cast to the interface
    //IMovable[] movables = [turtle, person];

    // Not even in the most basic case
    //IMovable m = turtle;

    Move(ref turtle);
    Move(ref person);

    Output(turtle);
    Output(person);
  }

  // It's not possible to pass the ref structs this method, because
  // they would be boxed during the cast and that's not allowed.
  // private static void Move(IMovable movable) {
  //   movable.Advance();
  // }

  // The only way to take advantage of the interface compatibility implemented
  // for the ref structs here is by way of a generic type argument.
  // Btw, remember that ref structs are not automatically passed by ref(erence)!
  private static void Move<T>(ref T movable) where T : IMovable, allows ref struct {
    movable.Advance();
  }

  private static void Output<T>(T movable) where T : IMovable, allows ref struct {
    Console.WriteLine($"Distance from zero: {movable.DistanceFromZero}");
  }
}