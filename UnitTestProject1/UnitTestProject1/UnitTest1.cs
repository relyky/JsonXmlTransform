using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void Test_SayHello()
    {
      string hello = ScalarValuedFunction.SayHello();
      Assert.AreEqual($"哈囉 at {DateTime.Now:HH:mm:ss}", hello);
    }

    [TestMethod]
    public void Test_Json2Xml()
    {
      string json = @"{
  '@Id': 1,
  'Email': 'james@example.com',
  'Active': true,
  'CreatedDate': '2013-01-20T00:00:00Z',
  'Roles': [
    'User',
    'Admin'
  ],
  'Team': {
    '@Id': 2,
    'Name': 'Software Developers',
    'Description': 'Creators of fine software products and services.'
  }
}";

      string expected_xml = @"<Root Id=""1"">
  <Email>james@example.com</Email>
  <Active>true</Active>
  <CreatedDate>2013-01-20T00:00:00Z</CreatedDate>
  <Roles>User</Roles>
  <Roles>Admin</Roles>
  <Team Id=""2"">
    <Name>Software Developers</Name>
    <Description>Creators of fine software products and services.</Description>
  </Team>
</Root>";

      string xml = ScalarValuedFunction.Json2Xml(json);
      Assert.AreEqual(expected_xml, xml);
    }

    [TestMethod]
    public void Test_Xml2Json()
    {
      string xml = @"<?xml version='1.0' standalone='no'?>
<root>
  <person id='1'>
  <name>Alan</name>
  <url>http://www.google.com</url>
  </person>
  <person id='2'>
  <name>Louis</name>
  <url>http://www.yahoo.com</url>
  </person>
</root>";

      string expected_json = @"{""?xml"":{""@version"":""1.0"",""@standalone"":""no""},""root"":{""person"":[{""@id"":""1"",""name"":""Alan"",""url"":""http://www.google.com""},{""@id"":""2"",""name"":""Louis"",""url"":""http://www.yahoo.com""}]}}";

      string json = ScalarValuedFunction.Xml2Json(xml);
      Assert.AreEqual(expected_json, json);
    }
  }
}
