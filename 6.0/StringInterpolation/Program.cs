using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInterpolation {
  class Program {
    static void Main(string[] args) {
      // Include formatted values right in the strings
      int errorCode = 42;
      string error = $"You did it wrong. Code={errorCode}";
      Console.WriteLine(error);

      // Complex expressions also possible
      var order = new { Name = "Bread and butter", Items = 3 };
      string info = $"Your order '{order.Name}' has {order.Items} items.";
      Console.WriteLine(info);

      // Even more complex expressions are also possible.
      // Consider hitting the dev round the head who writes this in 
      // reality ;)
      string betterInfo =
        $"Your order '{order.Name}' has {order.Items} item{(order.Items == 1 ? "" : "s")}.";
      Console.WriteLine(betterInfo);

      // On the other hand, individual format expressions can specify more detail:
      string valueFormat = $"Item count is {order.Items:D4}";
      Console.WriteLine(valueFormat);
    }
  }
}
