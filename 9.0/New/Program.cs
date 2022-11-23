namespace New {
  public class Thing {
    public Thing GetThing() {
      // Return a new Thing with short new()
      return new();
    }
  }

  class Program {
    static void ReceiveThing(Thing t) { }

    static void Main(string[] args) {
      // These two are now equivalent
      var t = new Thing();
      Thing t2 = new();

      // Get a thing
      var t3 = t2.GetThing();

      // Short syntax new() can be used when passing values
      ReceiveThing(new());
    }
  }
}
