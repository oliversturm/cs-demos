// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods {
  using MyStuff;

  class Program {
    static void Main(string[] args) {
      string[] strings = { "To be or not to be",
                           "That is the question",
                           "Whether tis nobler" };

      string hamlet = strings.Concatenate(",");
      Console.WriteLine(hamlet);

      42.DoSomething();

      CallSequence();
    }

    private static void CallSequence() {
      var results =
        SequenceHelpers.Take(
          SequenceHelpers.Apply(
            SequenceHelpers.Apply(
              EndlessListFunction(),
              Square),
            x => x / 2),
          10);

      var results2 =
        EndlessListFunction().
        Apply(Square).
        Apply(x => x / 2).
        Take(10);
    }

    public static IEnumerable<int> EndlessListFunction() {
      int val = 0;
      while (true)
        yield return val++;
    }

    public static int Square(int x) {
      return x * x;
    }
  }
}

namespace MyStuff {
  public static class StringHelpers {
    public static string Concatenate(
      this IEnumerable<string> strings, string separator) {
      StringBuilder buffer = new StringBuilder();
      foreach (string item in strings) {
        buffer.Append(item);
        buffer.Append(separator);
      }
      return buffer.ToString();
    }

    public static int DoSomething(this int value) {
      return 0;
    }
  }

  public static class SequenceHelpers {
    public static IEnumerable<int> Take(this IEnumerable<int> source, int count) {
      int used = 0;
      if (count > used)
        foreach (int item in source)
          if (count > used) {
            yield return item;
            used++;
          }
          else
            yield break;
    }

    public static IEnumerable<T> Apply<T>(this IEnumerable<T> values, Func<T, T> calculation) {
      foreach (T val in values)
        yield return calculation(val);
    }
  }
}
