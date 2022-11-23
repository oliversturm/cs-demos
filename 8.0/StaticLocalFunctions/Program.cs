namespace StaticLocalFunctions {
  class Program {
    static void Main(string[] args) {
      var txt = "Some text";

      void DoStuff() {
        // txt is captured
        Console.WriteLine(txt);
      }

      static void DoMoreStuff() {
        // no capture here -- this does not build
        //Console.WriteLine(txt);

        // Note with C# 9 this is also possible in lambda expressions
        // and anonymous methods.
      }

      DoStuff();
    }
  }
}
