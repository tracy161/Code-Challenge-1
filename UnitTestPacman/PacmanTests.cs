using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman;

namespace Pacman.Tests //namesplace has to contain Pacman
{
    [TestClass]
    public class PacmanTests
    {
        [TestMethod]
        public void PacmanCannotReportThePositionIfNotPlaced()
        {
            var pacman = new Pacman();
            var result = pacman.Report();
            Assert.AreEqual("", result);
            Assert.AreEqual("Pacman cannot report the position until it has been placed on the table.", pacman.LastError);
        }
        [TestMethod]
        public void PacmanCannotMoveIfNotPlaced()
        {
            var pacman = new Pacman();
            var result = pacman.Move();
            Assert.IsFalse(result);
            Assert.AreEqual("Pacman cannot move until it has been placed on the table.", pacman.LastError);
        }

        [TestMethod]
        public void PacmanCannotTurnRightIfNotPlaced()
        {
            var pacman = new Pacman();
            var result = pacman.Right();
            Assert.IsFalse(result);
            Assert.AreEqual("Pacman cannot turn until it has been placed on the table.", pacman.LastError);
        }
        [TestMethod]
        public void PacmanCannotBePlacedOutsideTheTable()
        {

        }
        
    }
}
