using System.Text;

namespace Extensions;

class Program {
  static void Main(string[] args) {
    Console.WriteLine("Hello, {0}!", string.OlisName);

    Console.WriteLine("Hello, {0}!", "AnybodyElse".MakeOli());

    Console.WriteLine("Hello, {0}!", "Oliver Sturm".RandomCase());

    string source = "This is a string that consists of several words";
    // Now let's wear the glasses of "every second char"
    var everySecondChar = (EverySecondChar)source;
    Console.WriteLine(everySecondChar.Value);

    var set = GetSet();
    Console.WriteLine(set["key1"]);

    // Will it be possible to new this up? No idea right now.
    //var set2 = new MySet<string> { ["key1"] = "value1", ["key2"] = "value2" };
  }

  static MySet<string> GetSet() =>
    new Dictionary<string, string> { ["key1"] = "value1", ["key2"] = "value2" };
}

// Extensions can include properties and methods, maybe more in the future.
// They provide general purpose type augmentation features for C#, and the
// purposes of these techniques are subject to future plans.

// These features do not work in .NET 9 preview 5.

// implicit extensions apply to all string instances as well as the type itself
public implicit extension DefaultStrings for string {
  public static string OlisName { get; } = "Oli";

  public string MakeOli() => "Oli";

  // Access the instance with `this`, as if the code is in the context of the augmented type
  public string RandomCase() {
    var sb = new StringBuilder();
    foreach (var c in this) {
        sb.Append((new Random().Next(2) == 0) ? char.ToUpper(c) : char.ToLower(c));
    }
    return sb.ToString();
  }
}


// explicit extensions do not apply unless the object or type is explicitly cast.
// They can also be used as an advanced alias mechanism.

public explicit extension EverySecondChar for string {
  public string Value {
    get {
      var sb = new StringBuilder();
      for (int i = 0; i < this.Length; i += 2) {
          sb.Append(this[i]);
      }
      return sb.ToString();
    }
  }
}

// Using generics in an explicit extension -- aliases do not support this,
// and they require the full namespace path to the type.
public explicit extension MySet<T> for Dictionary<string, T> where T: class {}
