using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SourceGenerators;

public class SyntaxReceiver : ISyntaxReceiver {
  //public List<MethodDeclarationSyntax> CandidateMethods { get; } = new();

  public void OnVisitSyntaxNode(SyntaxNode syntaxNode) {
    if (syntaxNode is VariableDeclarationSyntax variableDeclaration) {
      Console.WriteLine($"Found a variable declaration: {variableDeclaration}");
    }
    // if (syntaxNode is MethodDeclarationSyntax methodDeclaration &&
    //     methodDeclaration.AttributeLists.Any(al => al.Attributes.Any(a => a.Name.ToString() == "MyCustomAttribute"))) {
    //   CandidateMethods.Add(methodDeclaration);
    // }
  }
}
