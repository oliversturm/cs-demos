using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

[Generator]
public class SimpleClassGenerator : ISourceGenerator {
  public void Initialize(GeneratorInitializationContext context) {
    // Initialization logic
    Console.WriteLine("Initializing SimpleClassGenerator");

  }

  public void Execute(GeneratorExecutionContext context) {
    // Retrieve the property name and type from the generator's input
    var propertyName = "MyProperty";
    var propertyType = "string";

    // Generate the source code
    string sourceCode = $@"
using System;

namespace Generated
{{
  public partial class MyGeneratedClass
  {{
    public {propertyType} {propertyName} {{ get; set; }}
  }}
}}
";

    // Add the source code to the compilation
    context.AddSource("MyGeneratedClass", SourceText.From(sourceCode, Encoding.UTF8));
  }
}
