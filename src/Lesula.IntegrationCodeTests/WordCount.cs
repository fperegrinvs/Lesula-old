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
            // Admin
            // setup database
            var setupErr = Context.Container.Resolve<IDataBase>().CreateStructure();
            Assert.IsTrue(setupErr == null || setupErr.Count == 0, "Error creating database structure");

            //Register book DataType
            var registerBookErr = RegisterBookType();
            Assert.IsTrue(string.IsNullOrEmpty(registerBookErr), "Error creating book datatype: " + registerBookErr);

            //Register word DataType
            var registerWordErr = RegisterWordType();
            Assert.IsTrue(string.IsNullOrEmpty(registerWordErr), "Error creating word datatype: " + registerWordErr);

            //Register wordmapper transformation
            var registerWordMapperErr = RegisterWordMapper();
            Assert.IsTrue(string.IsNullOrEmpty(registerWordMapperErr), "Error creating wordmapper transformation: " + registerWordMapperErr);
        }

        private string RegisterBookType()
        {
            try
            {
                var code = File.ReadAllText(this.BasePath + "/content/Book.cs");

                var bookType = new DataType()
                {
                    Name = "Book",
                    Id =  new Guid("57D03CD6-5A57-4DDD-8498-FE7926206612"),
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

        private string RegisterWordType()
        {
            try
            {
                var code = File.ReadAllText(this.BasePath + "/content/Word.cs");

                var wordType = new DataType()
                {
                    Name = "Word",
                    Id = new Guid("7D4BFF0D-5830-421E-8B02-873A83C22CFB"),
                    Code = code
                };

                Context.Container.Resolve<IDataTypeDalc>().SaveDataType(wordType);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string RegisterWordMapper()
        {
            try
            {
                var code = File.ReadAllText(this.BasePath + "/content/WordMapper.cs");

                var wordType = new DataTransformation()
                {
                    Name = "WordMapper",
                    Id = new Guid("2C293902-7B39-4053-8446-C2951DAFE8E5"),
                    Code = code,
                    JobType = Client.Contracts.Enumerators.TransformationType.Mapper,
                    Dependency = null
                };

                Context.Container.Resolve<ITransformationDalc>().SaveTransformation(wordType);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string RegisterBookDataSource()
        {
            var ds = new DataSource()
            {
                Id = new Guid("9ccbc5bf-467b-44e9-9dba-2ac008095dc9"),
                DataType = new Guid("57D03CD6-5A57-4DDD-8498-FE7926206612") // book,
            };
            return "";
        }
    }
}
