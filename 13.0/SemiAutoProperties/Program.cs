namespace SemiAutoProperties;

class Program {
  static void Main(string[] args) {
    TheAnswer answer = new TheAnswer();
    answer.Question = "What is the answer to life, the universe, and everything?";
    answer.Value = 101; // Worth a try
    Console.WriteLine(answer.Value);
  }
}

class TheAnswer {
  // Auto-implemented properties -- ever since C# 3.0
  public string Question { get; set; }

  // Now you can use the `field` identifier to refer to an automatically
  // implemented backing field, and add your own logic.
  // This feature does not work in .NET 9 preview 5.

  // Sample in sharplab works: https://sharplab.io/#v2:EYLgZgpghgLgrgJwgZwLTIgWwJaqnGAe1QAcFCTkAaGEBOAOwB8ABAJgEYBYAKF4DcoCAAQkICZIQbCAvMIYQA7sIAK4yQwAUASl4BvXsKPCAYtgkwAclEwRZwgEQAhQsAdVeAXwDcvXiw4ATk0xCSkAOjMLa1ttXz4eFgBmYXZVdSlhAx5jVJSAgAZTc2QrGzts3NyAcwgYWQA+YTBsCAAbABNvYUMqowx6mSaW9o77QTa4CHCAJQgSNqgAYwhNAHInNaphNYBBNbienONPYy8gA===

  // Note that `field` may collide with existing names, even though
  // it is only a contextual keyword. You can use @field to avoid this.
  public int Value {
    get => field;
    set => field = 42;
  }

}