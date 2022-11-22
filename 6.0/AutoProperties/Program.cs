using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProperties {
  class Program {
    static void Main(string[] args) {
    }
  }

  public class Car {
    // Initializing auto-properties
    public string Color { get; set; } = "Red";

    // Auto-properties without setter, initializer required (or ctor init - 
    // see below)
    public int Year { get; }

    public Car() {
      // read-only auto properties can be initialized in the ctor of the type
      Year = 2008;
    }
  }
}
