using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator.Core.Models;

namespace ToyRobotSimulator.Test.UnitTest
{
    /// <summary>
    /// Summary description for DirectionLinkedListTest
    /// </summary>
    [TestClass]
    public class DirectionLinkedListTest
    {
        public DirectionLinkedListTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void InsertFirst_Node_Should_Be_Head()
        {
            var testLinkedList = new DirectionLinkedList<int>();
            testLinkedList.InsertFront(10);
            Assert.AreEqual(10, testLinkedList.Head.value);
        }

        [TestMethod]
        public void InsertLast_Node_Should_Be_Tail()
        {
            var testLinkedList = new DirectionLinkedList<int>();
            testLinkedList.InsertLast(1);
            testLinkedList.InsertLast(10);
            Assert.AreEqual(10, testLinkedList.Tail.value);
        }

        [TestMethod]
        public void WhenAddThreeItems_HeadAndTail_AreLinked()
        {
            var testLinkedList = new DirectionLinkedList<int>();
            testLinkedList.InsertLast(1);
            testLinkedList.InsertLast(10);
            testLinkedList.InsertLast(100);

            Assert.AreEqual(testLinkedList.Head.prev.value, testLinkedList.Tail.value);
            Assert.AreEqual(testLinkedList.Tail.next.value, testLinkedList.Head.value);
        }

        [TestMethod]
        public void GetNumber10_Should_Equal10() {
            var testLinkedList = new DirectionLinkedList<int>();
            testLinkedList.InsertLast(1);
            testLinkedList.InsertLast(10);
            testLinkedList.InsertLast(100);

            var node = testLinkedList.GetNodeByKey(10);
            Assert.AreEqual(10, node.value);
        }
    }
}
