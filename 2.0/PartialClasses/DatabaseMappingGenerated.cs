// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

namespace PartialClasses {
  public partial class DatabaseMapping : Baseclass {
    // this part of the class may have been created automatically
    // by a tool, depending on my db structures
    private string strField;
    public string StrField {
      get { return strField; }
      set {
        strField = value;
      }
    }

    private int intField;
    public int IntField {
      get { return intField; }
      set {
        intField = value;
      }
    }
  }
}