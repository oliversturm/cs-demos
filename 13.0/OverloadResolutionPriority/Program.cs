namespace OverloadResolutionPriority;

internal class Program {
  private static void Main() {
    int[] values = [1, 2, 3, 4, 5, 6, 7, 8, 9];

    // This call prefers the array handler. The ObsoleteAttribute
    // renders a warning, but overload resolution doesn't care.
    Handle(values);
  }

  // Let's say this was the old API we used, but for flexibility we'd
  // now like to use a different approach
  [Obsolete("Use the Span<int> overload instead")]
  private static void Handle(int[] items) {
    Console.WriteLine("Array Handler");
  }

  // This is the variant we want to prefer now, for performance and flexibility
  // With the attribute we can steer overload resolution in the right direction.
  // The default priority is 0, so anything >0 will do in this case.
  //[OverloadResolutionPriority(1)]
  private static void Handle(Span<int> items) {
    Console.WriteLine("Span<T> Handler");
  }
}