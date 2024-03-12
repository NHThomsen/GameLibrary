using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using GameLibrary.Classes.World;
using GameLibrary.Logging;

namespace GameLibrary.Tests
{
    [TestClass()]
    public class WorldTests
    {
        private static GameLogging gameLogging;
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            gameLogging = new GameLogging();
        }

        [TestMethod()]
        public void TestNameFromConfig()
        {
            string expectedName = "Far far away";

            World world = new World(gameLogging);

            string actualName = world.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod()]
        public void TestLengthFromConfig() 
        {
            int expected = 20;

            World world = new World(gameLogging);

            int actual = world.WorldLength;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestHeightFromConfig()
        {
            int expected = 20;

            World world = new World(gameLogging);

            int actual = world.WorldHeight;

            Assert.AreEqual(expected, actual);
        }
    }
}