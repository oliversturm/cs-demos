using System.Runtime.CompilerServices;

namespace Interceptors;

public static class InterceptsStuff {
  const string targetFile = "/Users/oli/git/cs-demos/12.0/Interceptors/Program.cs";

  [InterceptsLocation(targetFile, line: 4, column: 4)]
  public static void InterceptorMethod(this DoesSomething c, int arg) {
    Console.WriteLine($"Interceptor 1. Arg: {arg} -- will call original method");
    c.DoSomething(arg);
  }

  [InterceptsLocation(targetFile, line: 5, column: 4)]
  [InterceptsLocation(targetFile, line: 6, column: 4)]
  public static void OtherInterceptorMethod(this DoesSomething c, int arg) {
    Console.WriteLine($"Interceptor 2: Arg: {arg} -- ignoring original method");
  }
}