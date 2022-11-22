// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Globalization;

namespace ExceptionHandling {
  class Program {
    static void Main(string[] args) {
      try {
        throw new Exception("Something went wrong");
      }
      catch (Exception e) {
        Console.WriteLine("Error: {0}", e.Message);
        throw;
      }
      finally {
        Console.WriteLine("Cleaning up");
      }

      // Code smell: no exception parameter with "catch"
      try {
        throw new Exception("Something went wrong");
      }
      catch {
        Console.WriteLine("Oh dear");
        throw;
      }

      // Code smell: wrong "throw"
      try {
        throw new Exception("Something went wrong");
      }
      catch (Exception e) {
        Console.WriteLine("Error: {0}", e.Message);
        throw (e);
      }

      // Code smell: no "throw"
      try {
        throw new Exception("Something went wrong");
      }
      catch (Exception e) {
        Console.WriteLine("Error: {0}", e.Message);
      }

      // Code smell: standard exceptions for everything
      try {
        int error = 47;
        int line = 29387;
        throw new Exception(String.Format("Found error {0} in line {1}", error, line));
      }
      catch (Exception e) {
        Console.WriteLine("Error: {0}", e.Message);
        throw;
      }

    }
  }

  [Serializable]
  public class CustomException : Exception, ISerializable {
    public CustomException() { }

    public CustomException(string message, char additionalInfo) : base(message) {
      this.additionalInfo = additionalInfo;
    }

    public CustomException(string message, char additionalInfo, Exception innerException)
      : base(message, innerException) {
      this.additionalInfo = additionalInfo;
    }

    protected CustomException(SerializationInfo info, StreamingContext context)
      : base(info, context) {
      this.additionalInfo = (char)info.GetValue("AdditionalInfo", typeof(char));
    }

    // Illustration only - .NET Core onwards doesn't use this permission stuff
    [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    public override void GetObjectData(SerializationInfo info, StreamingContext context) {
      base.GetObjectData(info, context);
      info.AddValue("AdditionalInfo", AdditionalInfo);
    }

    public override string Message {
      get {
        return String.Format(CultureInfo.CurrentCulture, "{0}, AdditionalInfo: {1}", base.Message, AdditionalInfo);
      }
    }

    private char additionalInfo;

    public char AdditionalInfo {
      get {
        return additionalInfo;
      }
    }
  }
}
