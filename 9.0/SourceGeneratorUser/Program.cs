namespace SourceGeneratorUser;

public static class Program {
  static string[] messages = [
    "CREATE_CUSTOMER",
    "UPDATE_CUSTOMER",
    "PLACE_ORDER"
    ];

  static void Main() {
    var myGeneratedClass = new Generated.MyGeneratedClass();
    myGeneratedClass.MyProperty = "Hello, world!";
    Console.WriteLine(myGeneratedClass.MyProperty);
  }
}