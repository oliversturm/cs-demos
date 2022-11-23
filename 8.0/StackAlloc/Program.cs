namespace StackAlloc {
  class Program {
    static void Main(string[] args) {
      // Span with "normal" array
      var ints = new int[] { 1, 2, 3, 4, 5 };
      var span = new Span<int>(ints);
      var three = span[2];
      Console.WriteLine(three);

      // stackalloc array can be assigned to a span -- this does not require `unsafe`
      Span<int> stackInts = stackalloc int[] { 1, 2, 3, 4, 5 };
      var three_ = stackInts[2];
      Console.WriteLine(three_);

      // In an unsafe block, stackalloc can be assigned to a pointer
      unsafe {
        int* ip = stackalloc int[] { 1, 2, 3, 4, 5 };
        int* origIp = ip;

        // The use of stackalloc activates stack overrun protection. Try changing the 
        // max value here from 5 to 200 and you'll see that the loop does not run
        // all the way through. To be fair, it's only a guess that the stack overrun
        // protection causes this behavior. It's a bit weird because all that appears
        // to happen is that the loop is cancelled -- the remaining code, including
        // the lines at the end of the `unsafe` block, is still executed.
        // Documentation promises that the process should be terminated and I'm willing
        // to believe that, but it's obviously not trivial to test.
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/stackalloc#security

        for (int x = 0; x < 5; x++, ip++) {
          Console.WriteLine($"Index {x}, ip content is {*ip}");
          *ip *= *ip; // some fun to confuse those who never use pointers
        }

        var pointerSpan = new Span<int>(origIp, 5);
        Console.WriteLine(pointerSpan[2]);
      }

      Console.WriteLine("Ending program at the end");
    }
  }
}
