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

  }
}
