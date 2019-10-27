using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator.Core.Components;

namespace ToyRobotSimulator.Test.UnitTest
{
    /// <summary>
    /// Summary description for RobotTest
    /// </summary>
    [TestClass]
    public class RobotTest
    {
        public RobotTest()
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
        public void RobotMoveNorthFromOriginPoint_Y_ShouldEqual_1()
        {
            var robot = new Robot();
            robot.Move();
            Assert.AreEqual(robot.position.Y, 1);
            Assert.AreEqual(robot.position.X, 0);
            Assert.AreEqual(robot.Direction.value, Core.Models.DirectionEnum.NORTH);


        }

        [TestMethod]
        public void RobotFaceNorthRotateLeft_ShouldEqual_West()
        {
            var robot = new Robot();
            robot.RotateLeft();
            Assert.AreEqual(robot.position.Y, 0);
            Assert.AreEqual(robot.position.X, 0);
            Assert.AreEqual(robot.Direction.value, Core.Models.DirectionEnum.WEST);
        }

        [TestMethod]
        public void RobotFaceNorthRotateRight_ShouldEqual_East()
        {
            var robot = new Robot();
            robot.RotateRight();
            Assert.AreEqual(robot.position.Y, 0);
            Assert.AreEqual(robot.position.X, 0);
            Assert.AreEqual(robot.Direction.value, Core.Models.DirectionEnum.EAST);
        }


        [TestMethod]
        public void RobotMoveFromOriginPoint_ShouldNot_FallOff()
        {
            var robot = new Robot();
            robot.RotateLeft(); // facing West 
            Assert.AreEqual(robot.Direction.value, Core.Models.DirectionEnum.WEST);
            Assert.AreEqual(robot.position.X, 0);
            Assert.AreEqual(robot.position.Y, 0);

            robot.Move();
            Assert.AreEqual(robot.Direction.value, Core.Models.DirectionEnum.WEST);
            Assert.AreEqual(robot.position.X, 0);
            Assert.AreEqual(robot.position.Y, 0);

            robot.RotateLeft(); // facing South 
            Assert.AreEqual(robot.Direction.value, Core.Models.DirectionEnum.SOUTH);
            Assert.AreEqual(robot.position.X, 0);
            Assert.AreEqual(robot.position.Y, 0);

            robot.Move();
            Assert.AreEqual(robot.Direction.value, Core.Models.DirectionEnum.SOUTH);
            Assert.AreEqual(robot.position.X, 0);
            Assert.AreEqual(robot.position.Y, 0);
        }

        [TestMethod]
        public void RobotMoveToMaxPosition_ShouldNot_FallOff()
        {
            var robot = new Robot();
            for (var i = 0; i < robot.dimension; i++) {
                robot.Move();
            }
            robot.Move();
            Assert.AreEqual(robot.Direction.value, Core.Models.DirectionEnum.NORTH);
            Assert.AreEqual(robot.position.X, 0);
            Assert.AreEqual(robot.position.Y, robot.dimension-1);
        }


    }
}
