using System;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// ref→[Example of a CLR Scalar-Valued Function](https://learn.microsoft.com/en-us/sql/relational-databases/clr-integration-database-objects-user-defined-functions/clr-scalar-valued-functions?view=sql-server-ver16#example-of-a-clr-scalar-valued-function)
/// </summary>
public class ScalarValuedFunction
{
  [SqlFunction(DataAccess = DataAccessKind.Read)]
  public static string SayHello()
  {
    return $"哈囉 at {DateTime.Now:HH:mm:ss}";
  }
}
