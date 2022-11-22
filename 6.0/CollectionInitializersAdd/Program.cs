using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInitializersAdd {
  class Program {
    static void Main(string[] args) {
      var collection = new MyCollection { 3, 5, 7 };
    }
  }

  public class MyCollection : IEnumerable<int> {
    // As long as this method is available, all is good - and has 
    // been good as long as collection initializers have been
    // available. I.e. this is not new in C# 6.0.
    public void Add(int val) {
      Console.WriteLine("Adding: " + val);
    }

    IEnumerator<int> IEnumerable<int>.GetEnumerator() {
      yield break;
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return ((IEnumerable<int>)this).GetEnumerator();
    }
  }

  public static class CollectionExtensions {
    // This extension Add method was not previously recognized by 
    // the compiler for use with the collection initializer syntax
    // Now it works though -- this is new in C# 6.0.

    // Comment MyCollection.Add to see this in action.
    public static void Add(this MyCollection collection, int val) {
      Console.WriteLine("Adding in extension method: " + val);
    }
  }
}
