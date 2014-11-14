using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lesula.Core;
using Lesula.Core.Cassandra;
using System.IO;
using System.Reflection;
using Lesula.Client.Contracts.Models;
using Lesula.Admin.Contracts;
using Lesula.CodeParser;

namespace Lesula.IntegrationCodeTests
{
    /// <summary>
    /// Creates and execute a wordcount M/R job using integrated tests and mocks
    /// </summary>
    [TestClass]
    public class WordCountTest
    {
        protected string BasePath { get; set; }

        /// <summary>
        /// Setup the tests
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            BasePath = AppDomain.CurrentDomain.BaseDirectory;

            // IOC
            Context.Container.Register<IDataBase>(c => new DataBase());
            Context.Container.Register<IContext>(c => ThreadContext.CreateInstance());
            Context.Container.Register<IConfigSettings>(c => new AppConfigSettings());
            // assembly generator
            Context.Container.Register<IAssemblyGenerator>(c => new AssemblyGenerator());

            // admin dalc
            Lesula.Admin.Dalc.Register.RegisterAll();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Context.Container.Resolve<IDataBase>().CleanStructure();
        }

        [TestMethod]
        public void WordCount_MainTest()
        {
            // setup database
            var setupErr = Context.Container.Resolve<IDataBase>().CreateStructure();
            Assert.IsTrue(setupErr == null || setupErr.Count == 0, "Error creating database structure");

            //Register book DataType
            var registerBookErr = RegisterBookType();
            Assert.IsTrue(string.IsNullOrEmpty(registerBookErr), "Error creating book datatype: " + registerBookErr);
        }


        private string RegisterBookType()
        {
            try
            {
                var code = File.ReadAllText(this.BasePath + "/content/Book.cs");

                var bookType = new DataType()
                {
                    Name = "Book",
                    Id = Guid.NewGuid(),
                    Code = code
                };

                Context.Container.Resolve<IDataTypeDalc>().SaveDataType(bookType);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
