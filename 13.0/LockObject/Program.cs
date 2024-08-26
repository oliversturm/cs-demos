namespace LockObject;

internal class Program {
  private static void Main(string[] args) {
    Console.WriteLine("Hello, World!");
  }

  // This object lock generates code like this:

  // bool lockTaken = false;
  // try
  // {
  //     Monitor.Enter(objectLock, ref lockTaken);
  //     Console.WriteLine("Doing locked stuff");
  // }
  // finally
  // {
  //     if (lockTaken)
  //     {
  //         Monitor.Exit(objectLock);
  //     }
  // }

  private static readonly object objectLock = new();

  private static void DoSomething() {
    lock (objectLock) {
      Console.WriteLine("Doing locked stuff");
    }
  }

  // If the lock is a System.Threading.Lock, the code is simpler:

  // using (improvedLock.EnterScope())
  // {
  //     Console.WriteLine("Doing other locked stuff");
  // }

  private static readonly Lock improvedLock = new();

  private static void DoSomethingElse() {
    lock (improvedLock) {
      Console.WriteLine("Doing other locked stuff");
    }
  }
}