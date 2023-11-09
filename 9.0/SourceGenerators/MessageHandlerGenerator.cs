using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.Text;
using System.Text;
using System.Text.RegularExpressions;

namespace SourceGenerators;

[Generator]
public class MessageHandlerGenerator : ISourceGenerator {
  public void Initialize(GeneratorInitializationContext context) {
    context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
  }

  public static string GetEventName(string message) =>
    "On" + Regex.Replace(message.ToLower(), @"(?:^|_)([a-z])",
      match => match.Groups[1].Value.ToUpper());

  public void Execute(GeneratorExecutionContext context) {
    var builder = new StringBuilder();

    if (context.SyntaxReceiver is SyntaxReceiver receiver) {
      var messages = receiver.FieldDeclarations
        .SelectMany(fieldDeclaration => fieldDeclaration.Declaration.Variables)
        .Select(variable => variable.Initializer.Value)
        .OfType<CollectionExpressionSyntax>()
        .SelectMany(collection => collection.Elements)
        .OfType<ExpressionElementSyntax>()
        .Select(expressionElement => expressionElement.Expression)
        .OfType<LiteralExpressionSyntax>()
        .Select(literalExpression => literalExpression.Token.ValueText)
        .Distinct();

      // foreach (var fieldDeclaration in receiver.FieldDeclarations) {
      //   foreach (var variable in fieldDeclaration.Declaration.Variables) {
      //     if (variable.Initializer.Value is CollectionExpressionSyntax collection) {
      //       foreach (var element in collection.Elements) {
      //         if (element is ExpressionElementSyntax expressionElement &&
      //             expressionElement.Expression is LiteralExpressionSyntax literalExpression) {
      //         }
      //       }
      //     }
      //   }
      // }
      // }
      //
      // if (context.SyntaxReceiver is SyntaxReceiver receiver) {
      builder.Append(@"

public class MessageHandler {
  public static string[] HandledMessages = new[] {");
      foreach (var message in messages) {
        builder.Append($@"
    ""{message}"",");
      }


      builder.Append(@"
  };
}
");
    }
    else {
      builder.AppendLine(@"// Error generating file: SyntaxReceiver is null");
    }

    context.AddSource("MessageHandlerGenerator",
      SourceText.From(builder.ToString(), Encoding.UTF8));
  }
}