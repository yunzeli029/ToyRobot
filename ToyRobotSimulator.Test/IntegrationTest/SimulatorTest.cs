using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator.ApplicationException;
using ToyRobotSimulator.RobotSimulator;

namespace ToyRobotSimulator.Test.IntegrationTest
{
    /// <summary>
    /// Summary description for SimulatorTest
    /// </summary>
    [TestClass]
    public class SimulatorTest
    {
        public SimulatorTest()
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
        [ExpectedException(typeof(InvalidCommandException))]
        public void whenPlaceRobot_2Args_ThenExceptionThrown()
        {
            var simulator = new Simulator();
            simulator.Command(Core.Models.CommandEnum.PLACE,"1,5");
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void whenPlaceRobot_Invalid_X_ThenExceptionThrown()
        {
            var simulator = new Simulator();
            simulator.Command(Core.Models.CommandEnum.PLACE, "a,5,North");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void whenPlaceRobot_Invalid_Y_ThenExceptionThrown()
        {
            var simulator = new Simulator();
            simulator.Command(Core.Models.CommandEnum.PLACE, "1,b,North");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void whenPlaceRobot_Invalid_Direction_ThenExceptionThrown()
        {
            var simulator = new Simulator();
            simulator.Command(Core.Models.CommandEnum.PLACE, "1,2,Test");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void whenPlaceRobot_X_OutOfBoundary_ThenExceptionThrown()
        {
            var simulator = new Simulator();
            simulator.Command(Core.Models.CommandEnum.PLACE, "10,2,North");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void whenPlaceRobot_Y_OutOfBoundary_ThenExceptionThrown()
        {
            var simulator = new Simulator();
            simulator.Command(Core.Models.CommandEnum.PLACE, "1,15,North");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void whenRobotIsNotPlaced_RunOtherCommand_ThenExceptionThrown()
        {
            var simulator = new Simulator();
            simulator.Command(Core.Models.CommandEnum.MOVE);
        }
    }
}
