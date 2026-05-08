using SourceGenerators;

namespace SourceGeneratorUser;

public static class Program {
  // Basic set of messages get auto-created event handlers
  [HandledMessages]
  static string[] messages = [
    "CREATE_CUSTOMER",
    "UPDATE_CUSTOMER",
    "PLACE_ORDER",
    ];

  // Uncomment this and look at Intellisense below -
  // the extra messages are included immediately
  //[HandledMessages]
  private static string[] extraMessages = [
    "DELETE_CUSTOMER",
    "CANCEL_ORDER",
  ];

  static void Main() {
    var messageHandler = new MessageHandler();

    // Remove comment and check out Intellisense after the .
    //messageHandler.
  }
}