using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SourceGenerators;

public class SyntaxReceiver : ISyntaxReceiver {
  public List<FieldDeclarationSyntax> FieldDeclarations { get; } = new();

  public void OnVisitSyntaxNode(SyntaxNode syntaxNode) {
    if (syntaxNode is FieldDeclarationSyntax fieldDeclaration) {
      if (fieldDeclaration.AttributeLists
          .SelectMany(al => al.Attributes)
          .Any(a => a.Name.ToString() == "HandledMessages" ||
                    a.Name.ToString() == "HandledMessagesAttribute")) {
        FieldDeclarations.Add(fieldDeclaration);
      }
    }
  }
}