// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Initializers {
  class Program {
    static void Main(string[] args) {
      Person person = new Person {
        Name = "Willy",
        Age = 42
      };

    }
  }

  public class Person {
    //    public Person(string name, int age) {
    //      this.name = name;
    //      this.age = age;
    //    }
    public Person( ) {
    }
    private string name;
    public string Name {
      get { return name; }
      set {
        name = value;
      }
    }
    private int age;
    public int Age {
      get { return age; }
      set {
        age = value;
      }
    }
  }
}
