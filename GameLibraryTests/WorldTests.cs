using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Tests
{
    [TestClass()]
    public class WorldTests
    {
        [TestMethod()]
        public void TestNameFromConfig()
        {
            string expectedName = "Far far away";

            World world = new World();

            string actualName = world.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod()]
        public void TestLengthFromConfig() 
        {
            int expected = 20;

            World world = new World();

            int actual = world.WorldLength;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestHeightFromConfig()
        {
            int expected = 20;

            World world = new World();

            int actual = world.WorldHeight;

            Assert.AreEqual(expected, actual);
        }
    }
}