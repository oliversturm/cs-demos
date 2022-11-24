using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexInitializers {
  class Program {
    static void Main(string[] args) {
      // Index initializers: the following syntax initializes a type that uses 
      // indexed access to its contents.
      var numberNames = new Dictionary<int, string>
      {
        [1] = "one",
        [2] = "two",
        [3] = "three"
      };

      // No magic: The same thing works as well with a custom container that has a 
      // compatible indexer.
      var myNumberNames = new MyContainer
      {
        [1] = "one",
        [2] = "two",
        [3] = "three"
      };

      // Of course the index can use other types as well
      var colors = new Dictionary<string, string>
      {
        ["red"] = "#ff0000",
        ["green"] = "#00ff00",
        ["blue"] = "#0000ff"
      };
    }
  }

  public class MyContainer {
    Dictionary<int, string> data = new Dictionary<int, string>();
    public string this[int index] {
      get {
        return data[index];
      }
      set {
        data[index] = value;
      }
    }
  }
}
