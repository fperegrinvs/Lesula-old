using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lesula.CodeParser;
using System.Reflection;
using Lesula.Client.Contracts.Models;
using Rhino.Mocks;
using Lesula.Client.Contracts.Base;

namespace Lesula.Core.Tests
{
    [TestClass]
    public class DataTypeCheckerTests
    {
        private FakeAssemblyGenerator generator;

        [TestInitialize]
        public void Init()
        {
            generator =  new FakeAssemblyGenerator();
            // assembly generator
            Context.Container.Register<IAssemblyGenerator>(c => generator);

            // set the current assembly as the fake one
            generator.FakeAssembly = Assembly.GetExecutingAssembly();
        }

        /// <summary>
        /// Try to compile assembly, with success
        /// </summary>
        [TestMethod]
        public void TryCompileAssembly()
        {
            var checker = new DataTypeChecker();

            Assembly a = null;
            var err = checker.TryCompile(new DataType { Name = "Test"}, out a);

            Assert.IsTrue(string.IsNullOrEmpty(err));
        }

        /// <summary>
        /// Try to compile assembly, check if errors are returned
        /// </summary>
        [TestMethod]
        public void TryCompileAssemblyWithErrors()
        {
            var checker = new DataTypeChecker();
            var error = "Error testing";
            generator.Errors = new System.Collections.Generic.List<string>() { error };

            Assembly a = null;
            var err = checker.TryCompile(new DataType { Name = "Test" }, out a);

            Assert.AreEqual(error, err);
        }

        /// <summary>
        /// Try to compile assembly with the wrong name
        /// </summary>
        [TestMethod]
        public void TryCompileAssemblyWrongName()
        {
            var checker = new DataTypeChecker();

            Assembly a = null;
            var err = checker.TryCompile(new DataType { Name = "InvalidName"}, out a);

            Assert.IsTrue(!string.IsNullOrEmpty(err));
        }

        /// <summary>
        /// Try to create instance from the generated assembly
        /// </summary>
        [TestMethod]
        public void TryCreateInstanceSuccess()
        {
            JobData newClass = null;
            var checker = new DataTypeChecker();
            var err = checker.TryCreateInstance(Assembly.GetExecutingAssembly(), "Lesula.Core.Tests.Test", out newClass);
        }
    }

    public class Test : JobData
    {
        public string Name { get; set; }

        public int Age { get; set; }

        /// <summary>
        /// Gets the element unique key
        /// </summary>
        public override byte[] Key
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        /// <summary>
        /// Convert object to a set of cassandra columns
        /// </summary>
        /// <returns>Conversion result</returns>
        public override IRow ToRow()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Convert a set of cassandra columns to an instance of MyDataType
        /// </summary>
        /// <param name="row">Source data</param>
        /// <returns>Conversion result</returns>
        public override JobData FromRow(IRow row)
        {
            throw new System.NotImplementedException();
        }
    }

    public class TestFalse
    {
    }
}
