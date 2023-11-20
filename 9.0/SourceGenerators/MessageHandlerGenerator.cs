using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Text;
using System.Text.RegularExpressions;

namespace SourceGenerators;

[Generator]
public class MessageHandlerGenerator : ISourceGenerator {
  public void Initialize(GeneratorInitializationContext context) {
    context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
  }

  static string GetEventName(string message) =>
    Regex.Replace(message.ToLower(), @"(?:^|_)([a-z])",
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

      var eventNames = messages.Select(GetEventName);

      var delegates = eventNames.Select(eventName => $@"public delegate void {eventName}MessageHandler();");

      builder.AppendLine(String.Join("\n", delegates));

      builder.AppendLine(@"
public class MessageHandler {");

      var events = eventNames.Select(eventName => $@"  public event {eventName}MessageHandler {eventName};");
      builder.AppendLine(String.Join("\n", events));

      builder.Append(@"}
");
    }
    else {
      builder.AppendLine(@"// Error generating file: SyntaxReceiver is null");
    }

    context.AddSource("MessageHandlerGenerator.g.cs",
      SourceText.From(builder.ToString(), Encoding.UTF8));
  }
}