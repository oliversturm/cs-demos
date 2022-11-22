namespace AsyncStreams {
  class Program {
    public static IEnumerable<int> GetInts() {
      yield return 10;
      yield return 20;
      yield return 30;
    }

    // Asynchronous iterators are just as easy to implement as
    // synchronous ones -- only they can also await stuff.
    public static async IAsyncEnumerable<int> GetIntsAsync() {
      yield return 10;
      await Task.Delay(1000);
      yield return 20;
      await Task.Delay(1000);
      yield return 30;
    }

    // Signature of the Main method is async to call await directly
    static async Task Main(string[] args) {
      foreach (var i in GetInts()) {
        Console.WriteLine(i);
      }

      // await foreach is needed to deal with IAsyncEnumerable<T>
      await foreach (var i in GetIntsAsync()) {
        Console.WriteLine(i);
      }
    }
  }
}
