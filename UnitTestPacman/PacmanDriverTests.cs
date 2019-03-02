using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman.Tests
{
    [TestClass]
    public class PacmanDriverTests
    {
        //this test is used to test types of command lines valid or not
        [TestMethod]
        public void InitialisedPacmanDriver()
        {
            var driver = new PacmanDriver(new Pacman());
            Assert.IsNotNull(driver.Pacman);
        }

        [TestMethod]
        public void EmptyCommandReportsInvalid()
        {
            var driver = new PacmanDriver(new Pacman());
            var response = driver.Command("");
            Assert.AreEqual("Invalid command.", response);
        }

        [TestMethod]
        public void PlaceCommandWithoutArgumentsReportsInvalid()
        {
            var driver = new PacmanDriver(new Pacman());
            var response = driver.Command("PLACE");
            Assert.AreEqual("Invalid command.", response);
        }

        [TestMethod]
        public void InvalidArgumentsRepoprtInvalidCommands()
        {
            var driver = new PacmanDriver(new Pacman());
            var response = driver.Command("abcde");
            Assert.AreEqual("Invalid command.", response);
            response = driver.Command("PLACE 1,A,NORTH");
            Assert.AreEqual("Invalid command.", response);
            response = driver.Command("PLACE A,1,NORTH");
            Assert.AreEqual("Invalid command.", response);
            response = driver.Command("PLACE 1,A,XXX");
            Assert.AreEqual("Invalid command.", response);
        }
    }
}
