// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace ExpressionTrees {
  class Program {
    static void Main(string[] args) {
      Func<double, double> lambda = e => e * 2 + 1;
      Console.WriteLine(lambda(42.0));

      Expression<Func<double, double>> expression = e => e * 2 + 1;

      // When we write this, we don't execute. Instead, we parse the expression
      Console.WriteLine(expression.ToString());

      // Using the ExpressionDumper class, we can also look at the structure of
      // the expression tree
      ExpressionDumper.Output(expression);

      Expression<Func<Person, bool>> isCalledBoris = p => p.Name == "Boris";

      ExpressionDumper.Output(isCalledBoris);

      //return;

      // First define the parameter to the expression
      ParameterExpression parameterExpression =
        Expression.Parameter(typeof(double), "x");
      // Now let's perform the operations on the parameter
      Expression body = Expression.Add(Expression.Multiply(
        parameterExpression, Expression.Constant(2.0)), Expression.Constant(1.0));

      // Our lambda expression has a body and one or more parameters
      Expression<Func<double, double>> lambdaExpression =
        Expression.Lambda<Func<double, double>>(body, parameterExpression);

      Console.WriteLine(lambdaExpression.ToString());
      // We can compile an expression into a delegate
      Func<double, double> function = lambdaExpression.Compile();

      // Which we then call 
      Console.WriteLine(function(10));
    }
  }

  public class Person {
    public string Name { get; set; }
    public Person() {

    }
  }
}
