using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Literals {
  class Program {
    static void Main(string[] args) {

      // separators - can be used wherever you want :)
      var i = 987_65_4_3;
      Console.WriteLine(i);

      var hex = 0xDE_AD_BE_EF;
      Console.WriteLine(hex);

      // binary:

      var b = 0b10101010_01010101;
      Console.WriteLine(b);
    }
  }
}
