using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccesoDatos;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserDAO DAO = new UserDAO();
            string id = "profesor";
            string clave = "iacc";
            DAO.Login(id,clave);
        }
    }
}
