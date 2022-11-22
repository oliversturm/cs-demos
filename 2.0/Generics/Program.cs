// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics {
  class Program {
    static void Main(string[] args) {
    }

    // methods/functions
    static T Create<T>() where T : new() {
      return new T();
    }
  }

  // classes
  public class Factory<T> where T : new() {
    public T Create() {
      return new T();
    }
  }

  // delegates
  public delegate void DoSomethingDelegate<K, V>(K key, V value);

  // interfaces
  public interface IDictionary<K, V> {
    V GetElement(K key);
    void PutElement(K key, V value);
    void DoSomething(DoSomethingDelegate<K, V> goForIt);
  }

  public class Problematic<T> {
    public bool Compare(T one, T other) {
      // Doesn't work
      //return one == other;
      return EqualityComparer<T>.Default.Equals(one, other);

      // There's also Comparer<T>
    }

    public class MyCondition { }

    public T FindElement(MyCondition cond) {
      //if (... can find element according to condition ...)
      //  return foundElement;
      //else

      return default(T);
    }
  }
}
