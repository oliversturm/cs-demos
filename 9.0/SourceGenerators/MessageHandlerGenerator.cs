using Microsoft.CodeAnalysis;

namespace SourceGenerators;

[Generator]
public class MessageHandlerGenerator : ISourceGenerator {
    public void Initialize(GeneratorInitializationContext context) {
      Console.WriteLine("Initializing MessageHandlerGenerator");
      context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext context) {
    }
}