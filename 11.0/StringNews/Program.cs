namespace StringNews {
  class Program {
    static void Main(string[] args) {
      // I don't quite like the way this structure is wrapped, but
      // it illustrates pretty well that interpolation parts in C# 11
      // can be complex and stretch over multiple lines.
      var ratingStatement = (int rating) => $"The rating {rating} is {rating switch
      {
        > 95 => "excellent",
        > 75 => "good",
        > 50 => "okay",
        > 40 => "mediocre",
        > 20 => "lackluster",
        _ => "... <silence> ..."
      }}.";

      Console.WriteLine(ratingStatement(76));
      Console.WriteLine(ratingStatement(11));

      var longTextVerbatim = @"
      We've had verbatim strings for a long time. They can be used
      for multi-line string literals. Note that they have to be completely
      unindented if you want no extra spaces at the start of lines.
      ";
      Console.WriteLine();
      Console.WriteLine("Long text (verbatim) following:\n");
      Console.WriteLine(longTextVerbatim);
      Console.WriteLine();

      var longTextRaw = """"
        Raw string literals are denoted by at least three quotes (""") 
        at the start and the end. This example uses four quotes,
        because we want to include three quotes """ as part of the text.
        Note how the base indent of the code is recognized and removed.
        """";
      Console.WriteLine("Long text (raw) following:\n");
      Console.WriteLine(longTextRaw);
      Console.WriteLine();

      var rawInterpolated = $"""
        This is some raw text with a value in it: "{Math.Sin(6.9)}"
        """;
      Console.WriteLine(rawInterpolated);
      Console.WriteLine();

      var rawInterpolatedWithBraces = $$"""
        In this case we want to use curly braces ('{' and '}') in the
        text, so we use two $ signs at the start so that interpolation
        requires a double brace pair: "{{Math.Sin(6.9)}}"
        """;
      Console.WriteLine(rawInterpolatedWithBraces);
      Console.WriteLine();
    }
  }
}
