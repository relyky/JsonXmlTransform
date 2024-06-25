using System;
using System.Xml;
using System.Xml.Linq;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;

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

  [SqlFunction(DataAccess = DataAccessKind.Read)]
  public static string Xml2Json(string xml)
  {
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    string json = JsonConvert.SerializeXmlNode(doc);
    return json;
  }

  [SqlFunction(DataAccess = DataAccessKind.Read)]
  public static string Json2Xml(string json)
  {
    XNode node = JsonConvert.DeserializeXNode(json, "Root");
    string xml = node.ToString();
    return xml;
  }
}
