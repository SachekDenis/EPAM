﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.SingletonContext;
using Task6;

namespace DataLayerTest
{
    /// <summary>
    /// Defines test class DataBaseCrudTest.
    /// </summary>
    [TestClass]
    public class DataBaseCrudTest
    {

        /// <summary>
        /// The context
        /// </summary>
        DbContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseCrudTest"/> class.
        /// </summary>
        public DataBaseCrudTest()
        {
            DbSqlConnection connection = new DbSqlConnection();
            AdoSqlServerDataLayerFactory factory = new AdoSqlServerDataLayerFactory(connection);
            _context = new DbContext(factory);
        }

        /// <summary>
        /// Defines the test method TestInsertIntoDb.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        [DataRow("PL-31")]
        [TestMethod]
        public void TestInsertIntoDb(string groupName)
        {
            Group group = new Group() { Name = groupName };

            var groupContext = _context.GetGroupDataLayer();

            groupContext.Insert(group);

            var inserterdGroup = groupContext.GetAll().Find(e => e.Name == groupName);

            Assert.IsNotNull(inserterdGroup);

            groupContext.Delete(inserterdGroup.Id);
        }

        /// <summary>
        /// Defines the test method TestDeleteFromDb.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        [DataRow("RK-12")]
        [TestMethod]
        public void TestDeleteFromDb(string groupName)
        {
            Group group = new Group() { Name = groupName };

            var groupContext = _context.GetGroupDataLayer();

            groupContext.Insert(group);

            var inserterdGroup = groupContext.GetAll().Find(e => e.Name == groupName);

            Assert.IsNotNull(inserterdGroup);

            groupContext.Delete(inserterdGroup.Id);

            var deletedGroup = groupContext.GetAll().Find(e => e.Name == groupName);

            Assert.IsNull(deletedGroup);
        }


        /// <summary>
        /// Defines the test method TestUpdateDb.
        /// </summary>
        /// <param name="oldGroupName">Old name of the group.</param>
        /// <param name="newGroupName">New name of the group.</param>
        [DataRow("VL-31", "NH-12")]
        [TestMethod]
        public void TestUpdateDb(string oldGroupName, string newGroupName)
        {

            var groupContext = _context.GetGroupDataLayer();

            Group group = new Group() { Name = oldGroupName };

            group.Id = groupContext.Insert(group);

            group.Name = newGroupName;

            groupContext.Update(group);

            var updatedGroup = groupContext.GetAll().Find(e => e.Name == newGroupName);

            Assert.IsNotNull(updatedGroup);

            groupContext.Delete(updatedGroup.Id);
        }

        /// <summary>
        /// Defines the test method TestReadAllDb.
        /// </summary>
        /// <param name="firstGroupName">First name of the group.</param>
        /// <param name="secondGroupName">Name of the second group.</param>
        [DataRow("RPR-31", "VS-12")]
        [TestMethod]
        public void TestReadAllDb(string firstGroupName, string secondGroupName)
        {

            var groupContext = _context.GetGroupDataLayer();

            Group firstGroup = new Group() { Name = firstGroupName };

            Group secondGroup = new Group() { Name = secondGroupName };

            groupContext.Insert(firstGroup);

            groupContext.Insert(secondGroup);

            var groups = groupContext.GetAll();

            Assert.IsNotNull(groups);

            var firstFindedGroup = groups.Find(e => e.Name == firstGroup.Name);

            var secondFindedGroup = groups.Find(e => e.Name == secondGroup.Name);

            Assert.IsNotNull(firstFindedGroup);
            Assert.IsNotNull(secondFindedGroup);

            groupContext.Delete(firstFindedGroup.Id);
            groupContext.Delete(secondFindedGroup.Id);
        }

        /// <summary>
        /// Defines the test method TestReadOneItemDb.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        [DataRow("UL-31")]
        [TestMethod]
        public void TestReadOneItemDb(string groupName)
        {

            var groupContext = _context.GetGroupDataLayer();

            Group group = new Group() { Name = groupName };

            group.Id = groupContext.Insert(group);

            var findedGroupById = groupContext.Get(group.Id);

            Assert.IsNotNull(findedGroupById);

            groupContext.Delete(findedGroupById.Id);
        }

        /// <summary>
        /// Defines the test method TestArgumentNullMustThrowException.
        /// </summary>
        [TestMethod]
        public void TestArgumentNullMustThrowException()
        {
            var groupContext = _context.GetGroupDataLayer();

            Assert.ThrowsException<ArgumentNullException>(()=>groupContext.Insert(null));
            Assert.ThrowsException<ArgumentNullException>(()=>groupContext.Update(null));
        }

        /// <summary>
        /// Defines the test method TestUpdateUnexestedDb.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        [DataRow("KL-31")]
        [TestMethod]
        public void TestUpdateUnexestedDb(string groupName)
        {

            var groupContext = _context.GetGroupDataLayer();
            
            int lastId = groupContext.GetAll().Last().Id;

            Group group = new Group() { Name = groupName, Id = lastId+1 };

            groupContext.Update(group);

            var updatedGroup = groupContext.GetAll().Find(e => e.Name == groupName);

            Assert.IsNull(updatedGroup);
        }

        /// <summary>
        /// Defines the test method TestInsertConnectedTables.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="fullName">The full name.</param>
        [TestMethod]
        [DataRow("VB-31","M","Kolenkov Mihail Viktorovich")]
        public void TestInsertConnectedTables(string groupName, string gender, string fullName)
        {
            var groupContext = _context.GetGroupDataLayer();

            var studentContext = _context.GetStudentDataLayer();

            Group group = new Group() { Name = groupName };

            group.Id = groupContext.Insert(group);

            Student student = new Student(){ BirthDate = DateTime.Now, GroupId = group.Id, Gender= gender, FullName=fullName };

            student.Id = studentContext.Insert(student);

            var insertedGroup = groupContext.Get(group.Id);

            var insertedStudent = studentContext.Get(student.Id);

            Assert.IsNotNull(insertedGroup);
            Assert.IsNotNull(insertedStudent);

        }
    }
}
