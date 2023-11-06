namespace InlineArrays {
  static class Program {
    // An inline array must be a struct with a single field
    // (and the attribute). They are expected to perform
    // similarly to unsafe fixed size buffers, but without
    // being unsafe. Microsoft expects them to be used
    // as optimizations in the BCL and other libraries.
    [System.Runtime.CompilerServices.InlineArray(5)]
    struct MyArray {
      // The type of the field determines the type of the array.
      // This is inferred correctly below.
      private bool elementZero;
    }

    // They can be generic, but the length must be a constant.
    [System.Runtime.CompilerServices.InlineArray(5)]
    struct TypedArray<T> {
      private T elementZero;
    }

    static void Main(string[] args) {
      // Working with the inline array is the same as working
      // with any other array.
      var myArray = new MyArray();
      for (int i = 0; i < 5; i++) {
        myArray[i] = i % 2 == 0;
      }

      foreach (var i in myArray) {
        Console.WriteLine(i);
      }

      var typedArray = new TypedArray<int>();
      for (int i = 0; i < 5; i++) {
        typedArray[i] = i;
      }

      foreach (var i in typedArray) {
        Console.WriteLine(i);
      }

      // This looks like it should work, but it does not. Microsoft thinks it should work
      // but they didn't get round to it. Check https://github.com/dotnet/roslyn/issues/69236,
      // https://github.com/dotnet/roslyn/issues/68927 and
      // https://github.com/dotnet/csharplang/blob/main/meetings/2023/LDM-2023-08-14.md#conclusion-4
      // Buffer buffer2 = [true, true, false, true, true];
      //
      // foreach (var i in buffer2) {
      //   Console.WriteLine(i);
      // }
    }
  }
}