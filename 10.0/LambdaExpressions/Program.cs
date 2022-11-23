namespace LambdaExpressions {
  public abstract record Thing(string Name);
  public record SingingThing(string Name, string Song) : Thing(Name);
  public record DancingThing(string Name, string Rhythm) : Thing(Name);

  class Program {
    static void Main(string[] args) {
      // C# 10 can finally infer the types ("natural type") of some 
      // lambda expressions.
      // This is a Func<string,int>.
      var countChars = (string s) => s.Length;

      Console.WriteLine(countChars("Supercalifragilisticexpialidocious"));

      // It works with multiple parameters
      var mult = (int x, int y) => x * y;

      // Unfortunately it is still sometimes very dumb
      // This does not work.
      //var square = x => mult(x, x);

      // On other occasions it does clever things and saves ten chars
      var add = (int x) => (int y) => x + y;
      Func<int, Func<int, int>> add_ = x => y => x + y;

      // It's possible to also specify the return type
      var mult_ = int (int x, int y) => x * y;

      // The return type seems to be required in cases like this -- for
      // some reason the compiler can't figure out a common base type
      // for the result.
      var getThing = Thing (bool condition) =>
        condition ?
          new SingingThing("Rod Stewart", "I am sailing") :
          new DancingThing("Angus Young", "Rumpelstiltskin");
    }
  }
}
