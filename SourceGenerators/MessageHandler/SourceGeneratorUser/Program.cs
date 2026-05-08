using SourceGenerators;

namespace SourceGeneratorUser;

public static class Program {
  [HandledMessages]
  static string[] messages = [
    "CREATE_CUSTOMER",
    "UPDATE_CUSTOMER",
    "PLACE_ORDER",
    ];

  //[HandledMessages]
  private static string[] extraMessages = [
    "DELETE_CUSTOMER",
    "CANCEL_ORDER",
  ];

  static void Main() {
    var messageHandler = new MessageHandler();
    messageHandler.CreateCustomer += () => Console.WriteLine("CreateCustomer");

    //messageHandler.
  }
}