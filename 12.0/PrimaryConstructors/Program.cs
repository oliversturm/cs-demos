namespace PrimaryConstructors {
  // In classes (and structs), fields created for primary constructor
  // parameters are kept private by default.
  public class Person(string name, int age) {
    // You can create public properties as needed. There is only
    // one backing field, unless you use both the property and
    // the constructor parameter (see below).
    // Properties can be read/write or read-only.
    public string Name { get; set; } = name;

    public override string ToString() {
      // If you accidentally still use the primary constructor field
      // in addition to the property, you get a warning.
      //return $"Person '{name}' is {age} years old";
      return $"Person '{Name}' is {age} years old";
    }
  }

  // Reminder: records create (read-only) public properties by default,
  // which is why the naming of the constructor parameters is typically different.
  public record PersonRecord(string Name, int Age);

  static class Program {
    static void Main(string[] args) {
      var oli = new Person("Oli", 42);
      Console.WriteLine(oli);
      Console.WriteLine($"(From outside) Person {oli.Name} is ...  years old");
      oli.Name = "Formal Oliver";
      Console.WriteLine(oli);

      var oliRecord = new PersonRecord("Oli", 42);
      Console.WriteLine(oliRecord);
      Console.WriteLine($"(From outside) Person {oliRecord.Name} is {oliRecord.Age} years old");
    }
  }
}