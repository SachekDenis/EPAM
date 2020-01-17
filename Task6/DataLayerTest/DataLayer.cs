using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.SingletonContext;
using Task6;

namespace DataLayerTest
{
    [TestClass]
    public class DataLayer
    {
        DbContext _context;
        public DataLayer()
        {
            DbSqlConnection connection = new DbSqlConnection();
            AdoSqlServerDataLayerFactory factory = new AdoSqlServerDataLayerFactory(connection);
            _context = new DbContext(factory);
        }

        [TestMethod]
        public void DbInsert()
        {
            var groupDataLayer = _context.GetGroupDataLayer();

            Group group = new Group() { Name = "ИП-31" };

            groupDataLayer.Insert(group);
        }
    }
}
