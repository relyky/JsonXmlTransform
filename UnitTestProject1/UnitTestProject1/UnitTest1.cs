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
  }
}
