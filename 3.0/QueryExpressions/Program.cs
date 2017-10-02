// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace QueryExpressions {
  class Program {
    static void Main(string[] args) {
      WhereExtensionMethod( );
      //SimplifyWithLinq();               
      //ProjectingAnAnonymousType();     
      //UsingJoins();
      //OrderBy();
      //QueryDirectories();
    }

    #region 1: Example showing Where extension method against customers

    private static void WhereExtensionMethod( ) {
      DataSource ds = new DataSource( );
      List<Customer> customers = ds.GetCustomerList( );

      IEnumerable<Customer> results = customers.Where(
        delegate(Customer c) { return c.City == "London"; });

      ObjectDumper.Write(results);
    }
    #endregion

    #region 2: Shows how the LINQ syntax simplifies this
    private static void SimplifyWithLinq( ) {
      DataSource ds = new DataSource( );
      List<Customer> customers = ds.GetCustomerList( );

      var query =
          from c in customers
          where c.City == "Madrid"
          select c.CompanyName;

      ObjectDumper.Write(query);
    }
    #endregion

    #region 3: Shows projection and anonymous types
    private static void ProjectingAnAnonymousType( ) {
      DataSource ds = new DataSource( );
      List<Customer> customers = ds.GetCustomerList( );

      var results =
           from c in customers
           where c.City == "Nantes"
           select new { c.CustomerID, c.CompanyName };

      ObjectDumper.Write(results);
    }
    #endregion

    #region 4: using a join to produce the intersection of two sets
    private static void UsingJoins( ) {
      DataSource ds = new DataSource( );
      List<Customer> customers = ds.GetCustomerList( );

      Contact[] keyContacts = new Contact[]{
                new Contact{ Key = "ALFKI", 
                  Name = "Homer Simpson" },
                new Contact{ Key = "ANATR", 
                  Name = "Fred Flintstone" }
            };

      var query =
              from k in keyContacts
              join c in customers on k.Key equals c.CustomerID
              select new { c.CustomerID, c.CompanyName, k.Name };

      ObjectDumper.Write(query);
    }
    #endregion

    #region 5: An order by clause can be used to sort results
    private static void OrderBy( ) {
      DataSource ds = new DataSource( );
      List<Customer> customers = ds.GetCustomerList( );

      var query =
           from c in customers
           where c.City == "London"
           orderby c.CompanyName
           select new {
             c.CompanyName,
             c.Address,
             Orders =
               from o in c.Orders
               where o.OrderDate.Year == 1997
               orderby o.OrderDate
               select new { o.OrderDate, o.Total }
           };

      ObjectDumper.Write(query, 1);
    }
    #endregion

    #region 6: We can query anything that supports an IEnumerable
    private static void QueryDirectories( ) {
      DirectoryInfo di = new DirectoryInfo(@"C:\apps");

      var query =
          from d in di.GetDirectories("*", SearchOption.AllDirectories)
          orderby d.Name
          select d.FullName;

      ObjectDumper.Write(query);
    }
    #endregion
  }
}
