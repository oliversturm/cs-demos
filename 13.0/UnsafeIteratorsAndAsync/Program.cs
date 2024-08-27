using System.Runtime.InteropServices;

namespace UnsafeIteratorsAndAsync;

internal class Program {
  private static void Main(string[] args) {
    byte[] array = [1, 2, 3, 4, 5];
    GCHandle handle = GCHandle.Alloc(array, GCHandleType.Pinned);
    IntPtr ptr = handle.AddrOfPinnedObject();

    // This outputs 1, 2, 3, 4, 5 as you would think
    foreach (byte b in ReadMemory(ptr, array.Length)) {
      Console.WriteLine(b);
    }

    handle.Free();
  }

  // This is an iterator, but the same now works in async methods as long
  // as await is not used inside an unsafe block.
  // The use of ref is now allowed in both cases as well.
  public static IEnumerable<byte> ReadMemory(IntPtr startAddress, int length) {
    for (int i = 0; i < length; i++) {
      byte value;
      unsafe {
        byte* valuePtr = (byte*)startAddress + i;
        value = *valuePtr;
      }

      // yield return must be outside the unsafe block
      yield return value;
    }
  }
}