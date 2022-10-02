using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccesoDatos;
namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserDAO DAO = new UserDAO();
            string a = "profesor";
            string b = "iacc";
            DAO.Login(a, b);
        }
    }
}
