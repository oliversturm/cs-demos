// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Text;

namespace QueryExpressions {
  public class Order {
    public int OrderID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
  }
}