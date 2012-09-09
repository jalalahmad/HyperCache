using HyperCache;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Caching;

namespace HyperCache.Test
{
    
    
    /// <summary>
    ///This is a test class for FunctionCacheTest and is intended
    ///to contain all FunctionCacheTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FunctionCacheTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for FunctionCache Constructor
        ///</summary>
        //[TestMethod()]
        //public void FunctionCacheConstructorTest()
        //{
        //    FunctionCache target = new FunctionCache();
        //    Assert.Inconclusive("TODO: Implement code to verify target");
        //}

        ///// <summary>
        /////A test for FunctionCache Constructor
        /////</summary>
        //[TestMethod()]
        //public void FunctionCacheConstructorTest1()
        //{
        //    ObjectCache cache = null; // TODO: Initialize to an appropriate value
        //    FunctionCache target = new FunctionCache(cache);
        //    Assert.Inconclusive("TODO: Implement code to verify target");
        //}

        ///// <summary>
        /////A test for GenerateKey
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("HyperCache.dll")]
        //public void GenerateKeyTest()
        //{
        //    FunctionCache_Accessor target = new FunctionCache_Accessor(); // TODO: Initialize to an appropriate value
        //    object[] p = null; // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = target.GenerateKey(p);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for Get
        /////</summary>
        ////public void GetTestHelper<TResult>()
        ////{
        ////    FunctionCache target = new FunctionCache(); // TODO: Initialize to an appropriate value
            
        ////    TResult expected = target.Get<DateTime; // TODO: Initialize to an appropriate value
        ////    TResult actual;
        ////    actual = target.Get<TResult>(func);
        ////    Assert.AreEqual(expected, actual);
        ////    Assert.Inconclusive("Verify the correctness of this test method.");
        ////}

        //[TestMethod()]
        //public void GetTest()
        //{
        //    GetTestHelper<GenericParameterHelper>();
        //}

        [TestMethod]
        public void GetTest()
        {
            FunctionCache cache = new FunctionCache();
            var expected1 = cache.Get<DateTime>(this.GetTime);
            var actual1 = cache.Get<DateTime>(this.GetTime);
            Assert.AreEqual<DateTime>(expected1, actual1);

            TestFunc t1 = new TestFunc("jalal");
            TestFunc t2 = new TestFunc("shahab");
            Assert.AreEqual(cache.Get<string>(t1.Test),cache.Get<string>(t1.Test));
            Assert.AreEqual(cache.Get<string>(t2.Test), cache.Get<string>(t2.Test));
            Assert.AreNotEqual(cache.Get<string>(t1.Test), cache.Get<string>(t2.Test));
        }
        private DateTime GetTime()
        {
            return DateTime.Now;
        }
    }

    class TestFunc
    {
        private string _name;
        public TestFunc(string name)
        {
            _name = name;
        }

        public string Test()
        {
            return _name;
        }
    }
}
