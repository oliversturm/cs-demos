// ExpressionDumper.cs: Copyright (C) 2007 Oliver Sturm <oliver@sturmnet.org>
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.IO;
using System.Reflection;

public static class ExpressionDumper {
  private static int indentSize = 2;
  public static int IndentSize {
    get { return indentSize; }
    set {
      indentSize = value;
    }
  }

  private static char indentChar = ' ';
  public static char IndentChar {
    get { return indentChar; }
    set {
      indentChar = value;
    }
  }

  public static void Output(Expression expression) {
    Output(expression, Console.Out);
  }

  public static void Output(Expression expression, TextWriter textWriter) {
    Output(expression, textWriter, 0);
  }

  private static void Output(Expression expression, TextWriter textWriter, int indent) {
    switch (expression.NodeType) {
      case ExpressionType.Add:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.AddChecked:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.And:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.AndAlso:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.ArrayLength:
        Output((UnaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.ArrayIndex:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Call:
        Output((MethodCallExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Coalesce:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Conditional:
        Output((ConditionalExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Constant:
        Output((ConstantExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Convert:
        Output((UnaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.ConvertChecked:
        Output((UnaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Divide:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Equal:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.ExclusiveOr:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.GreaterThan:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.GreaterThanOrEqual:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Invoke:
        Output((InvocationExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Lambda:
        Output((LambdaExpression)expression, textWriter, indent);
        break;
      case ExpressionType.LeftShift:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.LessThan:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.LessThanOrEqual:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.ListInit:
        Output((ListInitExpression)expression, textWriter, indent);
        break;
      case ExpressionType.MemberAccess:
        Output((MemberExpression)expression, textWriter, indent);
        break;
      case ExpressionType.MemberInit:
        Output((MemberInitExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Modulo:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Multiply:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.MultiplyChecked:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Negate:
        Output((UnaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.UnaryPlus:
        Output((UnaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.NegateChecked:
        Output((UnaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.New:
        Output((NewExpression)expression, textWriter, indent);
        break;
      case ExpressionType.NewArrayInit:
        Output((NewArrayExpression)expression, textWriter, indent);
        break;
      case ExpressionType.NewArrayBounds:
        Output((NewArrayExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Not:
        Output((UnaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.NotEqual:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Or:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.OrElse:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Parameter:
        Output((ParameterExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Power:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Quote:
        Output((UnaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.RightShift:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.Subtract:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.SubtractChecked:
        Output((BinaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.TypeAs:
        Output((UnaryExpression)expression, textWriter, indent);
        break;
      case ExpressionType.TypeIs:
        Output((TypeBinaryExpression)expression, textWriter, indent);
        break;
    }
  }

  static void WriteWithIndent(TextWriter textWriter, int indent, string s) {
    textWriter.Write(new String(IndentChar, indent));
    textWriter.Write(s);
  }

  static void WriteLineWithIndent(TextWriter textWriter, int indent, string s) {
    WriteWithIndent(textWriter, indent, s);
    textWriter.WriteLine();
  }

  private static void OutputSubExpression(Expression expression, TextWriter textWriter, int indent, string label) {
    if (expression != null) {
      WriteLineWithIndent(textWriter, indent + IndentSize, label);
      Output(expression, textWriter, indent + 2 * IndentSize);
    }
  }

  private static void OutputExpressionCollection(TextWriter textWriter, int indent,
      IEnumerable<Expression> expressions, string label) {
    bool labelWritten = false;
    foreach (Expression argument in expressions) {
      if (!labelWritten) {
        WriteLineWithIndent(textWriter, indent + IndentSize, label);
        labelWritten = true;
      }
      Output(argument, textWriter, indent + 2 * IndentSize);
    }
  }

  static void Output(BinaryExpression expression, TextWriter textWriter, int indent) {
    WriteLineWithIndent(textWriter, indent,
        String.Format("BinaryExpression:{0}{1}{2} (", expression.NodeType,
        expression.IsLifted ? ", IsLifted" : "",
        expression.IsLiftedToNull ? ", IsLiftedToNull" : ""));

    if (expression.Method != null) {
      WriteLineWithIndent(textWriter, indent + IndentSize,
          String.Format("Method: {0}", expression.Method));
    }

    OutputSubExpression(expression.Conversion, textWriter, indent, "Conversion:");
    OutputSubExpression(expression.Left, textWriter, indent, "Left:");
    OutputSubExpression(expression.Right, textWriter, indent, "Right:");

    WriteLineWithIndent(textWriter, indent, ")");
  }

  static void Output(UnaryExpression expression, TextWriter textWriter, int indent) {
    WriteLineWithIndent(textWriter, indent,
        String.Format("UnaryExpression:{0}{1}{2} (", expression.NodeType,
        expression.IsLifted ? ", IsLifted" : "",
        expression.IsLiftedToNull ? ", IsLiftedToNull" : ""));

    OutputSubExpression(expression.Operand, textWriter, indent, "Operand:");

    WriteLineWithIndent(textWriter, indent, ")");
  }

  static string FormatMethodInfo(MethodInfo methodInfo) {
    return String.Format("{0}.{1}", methodInfo.ReflectedType.Name, methodInfo.Name);
  }

  static void Output(MethodCallExpression expression, TextWriter textWriter, int indent) {
    WriteLineWithIndent(textWriter, indent,
        String.Format("MethodCallExpression {0} (", FormatMethodInfo(expression.Method)));

    OutputExpressionCollection(textWriter, indent, expression.Arguments, "Arguments:");
    OutputSubExpression(expression.Object, textWriter, indent, "Object:");

    WriteLineWithIndent(textWriter, indent, ")");
  }

  static void Output(ConditionalExpression expression, TextWriter textWriter, int indent) {
    WriteLineWithIndent(textWriter, indent, "ConditionalExpression (");

    OutputSubExpression(expression.Test, textWriter, indent, "Test:");
    OutputSubExpression(expression.IfTrue, textWriter, indent, "IfTrue:");
    OutputSubExpression(expression.IfFalse, textWriter, indent, "IfFalse:");

    WriteLineWithIndent(textWriter, indent, ")");
  }

  static void Output(ConstantExpression expression, TextWriter textWriter, int indent) {
    WriteLineWithIndent(textWriter, indent,
        String.Format("ConstantExpression ({0})", expression.Value));
  }

  static void Output(InvocationExpression expression, TextWriter textWriter, int indent) {
    WriteLineWithIndent(textWriter, indent, "InvocationExpression (");

    OutputExpressionCollection(textWriter, indent, expression.Arguments, "Arguments:");
    OutputSubExpression(expression.Expression, textWriter, indent, "Expression:");

    WriteLineWithIndent(textWriter, indent, ")");
  }

  static void Output(LambdaExpression expression, TextWriter textWriter, int indent) {
    WriteLineWithIndent(textWriter, indent, "LambdaExpression (");

    OutputExpressionCollection(textWriter, indent, ExpressionList(expression.Parameters), "Parameters:");
    OutputSubExpression(expression.Body, textWriter, indent, "Body:");

    WriteLineWithIndent(textWriter, indent, ")");
  }

  private static IEnumerable<Expression> ExpressionList<TActualType>(IEnumerable<TActualType> sourceList)
      where TActualType : Expression {
    foreach (TActualType item in sourceList) {
      yield return item;
    }
  }

  static void Output(ListInitExpression expression, TextWriter textWriter, int indent) {
    WriteLineWithIndent(textWriter, indent, "ListInitExpression (");

    OutputSubExpression(expression.NewExpression, textWriter, indent, "NewExpression:");
    foreach (ElementInit elementInit in expression.Initializers) {
      WriteLineWithIndent(textWriter, indent + IndentSize,
          String.Format("ElementInit AddMethod={0} (", FormatMethodInfo(elementInit.AddMethod)));

      OutputExpressionCollection(textWriter, indent + IndentSize, elementInit.Arguments, "Arguments:");

      WriteLineWithIndent(textWriter, indent + IndentSize, ")");
    }

    WriteLineWithIndent(textWriter, indent, ")");
  }

  static void Output(MemberExpression expression, TextWriter textWriter, int indent) {
    WriteLineWithIndent(textWriter, indent,
        String.Format("MemberExpression {0} (", FormatMemberInfo(expression.Member)));

    OutputSubExpression(expression.Expression, textWriter, indent, "Expression:");

    WriteLineWithIndent(textWriter, indent, ")");
  }

  private static string FormatMemberInfo(MemberInfo memberInfo) {
    return String.Format("{0}.{1}", memberInfo.DeclaringType.Name, memberInfo.Name);
  }

  static void Output(MemberInitExpression expression, TextWriter textWriter, int indent) {
    WriteLineWithIndent(textWriter, indent, "MemberInitExpression (");

    OutputSubExpression(expression.NewExpression, textWriter, indent, "NewExpression:");

    foreach (MemberBinding memberBinding in expression.Bindings) {
      WriteLineWithIndent(textWriter, indent + IndentSize,
          String.Format("MemberBinding:{0} {1} ()", memberBinding.BindingType, FormatMemberInfo(memberBinding.Member)));
    }

    WriteLineWithIndent(textWriter, indent, ")");
  }

  static void Output(NewExpression expression, TextWriter textWriter, int indent) {
    WriteLineWithIndent(textWriter, indent, String.Format("NewExpression {0} (", FormatConstructorInfo(expression.Constructor)));

    OutputExpressionCollection(textWriter, indent, expression.Arguments, "Arguments:");
    foreach (MemberInfo memberInfo in expression.Members) {
      WriteLineWithIndent(textWriter, indent + IndentSize, String.Format("Member ({0})", FormatMemberInfo(memberInfo)));
    }

    WriteLineWithIndent(textWriter, indent, ")");
  }

  private static string FormatConstructorInfo(ConstructorInfo constructorInfo) {
    var builder = new StringBuilder();
    builder.AppendFormat("{0}(", constructorInfo.DeclaringType.Name);
    ParameterInfo[] parameters = constructorInfo.GetParameters();
    for (int i = 0; i < parameters.Length; i++) {
      if (i > 0)
        builder.Append(", ");
      builder.Append(parameters[i].ParameterType.Name);
    }
    builder.Append(")");
    return builder.ToString();
  }

  static void Output(NewArrayExpression expression, TextWriter textWriter, int indent) {
    WriteLineWithIndent(textWriter, indent,
        String.Format("NewArrayExpression:{0} (", expression.NodeType));

    OutputExpressionCollection(textWriter, indent, expression.Expressions, "Expressions");

    WriteLineWithIndent(textWriter, indent, ")");
  }

  static void Output(ParameterExpression expression, TextWriter textWriter, int indent) {
    WriteLineWithIndent(textWriter, indent,
        String.Format("ParameterExpression ({0})", expression.Name));
  }

  static void Output(TypeBinaryExpression expression, TextWriter textWriter, int indent) {
    WriteLineWithIndent(textWriter, indent,
        String.Format("TypeBinaryExpression TypeOperand={0} (", FormatType(expression.TypeOperand)));

    OutputSubExpression(expression.Expression, textWriter, indent, "Expression:");

    WriteLineWithIndent(textWriter, indent, ")");
  }

  private static string FormatType(Type type) {
    return type.FullName;
  }
}