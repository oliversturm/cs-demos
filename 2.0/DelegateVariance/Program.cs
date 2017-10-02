// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateVariance {
  class Program {
    static void Main(string[] args) {
      DelegateContravariance( );
      DelegateCovariance( );
    }

    static void DelegateContravariance( ) {
      AcceptBirdDelegate delegate1 = WorkWithBird;
      AcceptBirdDelegate delegate2 = WorkWithAnimal;
    }

    static void DelegateCovariance( ) {
      GetAnimalDelegate delegate1 = GetAnimal;
      GetAnimalDelegate delegate2 = GetBird;
    }

    static void WorkWithAnimal(Animal animal) {
    }

    static void WorkWithBird(Bird bird) {
    }

    static Animal GetAnimal( ) {
      return new Animal( );
    }

    static Bird GetBird( ) {
      return new Bird( );
    }

    delegate void AcceptBirdDelegate(Bird bird);
    delegate Animal GetAnimalDelegate( );
  }

  public class Animal {
  }

  public class Bird: Animal {
  }
}
