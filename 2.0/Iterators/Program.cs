// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Iterators {
  static class Program {
    static void Main(string[] args) {
      // Without interfaces
      //EndlessListWithoutInterfaces list1 = new EndlessListWithoutInterfaces( );
      //foreach (string item in list1) 
      //  Console.WriteLine(item);

      // With interfaces
      //EndlessListWithInterfaces list2 = new EndlessListWithInterfaces( );
      //foreach (object item in list2)
      //  Console.WriteLine(item);

      // With a separate enumerator
      //EndlessList list3 = new EndlessList( );
      //foreach (object item in list3)
      //  Console.WriteLine(item);

      // Using an iterator function
      //IEnumerable<int> list4 = EndlessListFunction( );
      //foreach (int item in list4)
      //  Console.WriteLine(item);

      // With debug output
      Console.WriteLine("Retrieving the list object");
      IEnumerable<int> list = ThreeNumbersDebug();
      Console.WriteLine("Before the foreach loop");
      foreach (int item in list)
        Console.WriteLine("Got value {0}", item);

      // Take the first five elements
      IEnumerable<int> fiveElementList = Take(EndlessListFunction(), 5);
      foreach (int item in fiveElementList)
        Console.WriteLine(item);

      // Take elements from EndlessListFunction, apply a square
      // operation, divide by 2, then cut off the sequence after 
      // 10 elements.
      IEnumerable<int> results =
        Take(
          Apply(
            Apply(EndlessListFunction(),
              Square),
            delegate (int x) { return x / 2; }),
          10);

      foreach (int item in results)
        Console.WriteLine(item);
    }

    public static IEnumerable<int> EndlessListFunction() {
      int val = 0;
      while (true)
        yield return val++;
    }

    public static IEnumerable<int> ThreeNumbers() {
      yield return 3;
      yield return 11;
      yield return 27;
    }

    public static IEnumerable<int> ThreeNumbersDebug() {
      Console.WriteLine("Returning 3");
      yield return 3;
      Console.WriteLine("Returning 11");
      yield return 11;
      Console.WriteLine("Returning 27");
      yield return 27;
    }

    public static IEnumerable<int> Take(IEnumerable<int> source, int count) {
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

    public static int Square(int x) {
      return x * x;
    }

    public static IEnumerable<int> Square(IEnumerable<int> values) {
      foreach (int val in values)
        yield return Square(val);
    }

    public static IEnumerable<int> Apply(IEnumerable<int> values, Func<int, int> calculation) {
      foreach (int val in values)
        yield return calculation(val);
    }

    public static IEnumerable<T> Apply<T>(IEnumerable<T> values, Func<T, T> calculation) {
      foreach (T val in values)
        yield return calculation(val);
    }
  }

  public class EndlessListWithoutInterfaces {
    public EndlessListWithoutInterfaces GetEnumerator() {
      return this;
    }

    public bool MoveNext() {
      return true;
    }

    public object Current {
      get { return "something"; }
    }
  }

  public class EndlessListWithInterfaces : IEnumerable, IEnumerator {
    public EndlessListWithInterfaces() {
    }

    public IEnumerator GetEnumerator() {
      return this;
    }

    public object Current {
      get { return "something"; }
    }

    public bool MoveNext() {
      return true;
    }

    public void Reset() {
    }
  }

  public class EndlessList : IEnumerable {
    public class Enumerator : IEnumerator {
      int val = -1;

      public object Current {
        get { return val; }
      }

      public bool MoveNext() {
        val++;
        return true;
      }

      public void Reset() {
        val = -1;
      }
    }

    public IEnumerator GetEnumerator() {
      return new Enumerator();
    }
  }

  public class EndlessListWithIterators : IEnumerable<int> {
    IEnumerator<int> IEnumerable<int>.GetEnumerator() {
      int val = 0;
      while (true)
        yield return val++;
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return ((IEnumerable<int>)this).GetEnumerator();
    }
  }
}
