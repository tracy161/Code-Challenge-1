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
            Assert.AreEqual("Pacman cannot report the position until it has been placed on the table.", pacman.Error);
        }
        [TestMethod]
        public void PacmanCannotMoveIfNotPlaced()
        {
            var pacman = new Pacman();
            var result = pacman.Move();
            Assert.IsFalse(result);
            Assert.AreEqual("Pacman cannot move until it has been placed on the table.", pacman.Error);
        }

        [TestMethod]
        public void PacmanCannotTurnRightIfNotPlaced()
        {
            var pacman = new Pacman();
            var result = pacman.Right();
            Assert.IsFalse(result);
            Assert.AreEqual("Pacman cannot turn until it has been placed on the table.", pacman.Error);
        }
        [TestMethod]
        public void PacmanCannotBePlacedOutsideTheTable()
        {
            var pacman = new Pacman();
            var result = pacman.Place(-1, 0, Facing.North);
            Assert.IsFalse(result);
            Assert.AreEqual("Pacman cannot be placed outside the table.", pacman.Error);
        }
        [TestMethod]
        public void PacmanCanReportThePositionAfterPlacingAndMoving()
        {
            var pacman = new Pacman();
            var result = pacman.Place(0, 0, Facing.North);
            pacman.Move();
            var report = pacman.Report();
            Assert.IsTrue(result);
            Assert.AreEqual("", pacman.Error);
            Assert.AreEqual("Output: 0,1,NORTH", report);

        }
        [TestMethod]
        public void PacmanCanReportThePositionAfterPlacingandTurning()
        {
            var pacman = new Pacman();
            var result = pacman.Place(0, 0, Facing.North);
            pacman.Left();
            var report = pacman.Report();
            Assert.IsTrue(result);
            Assert.AreEqual("", pacman.Error);
            Assert.AreEqual("Output: 0,0,WEST", report);

        }
        [TestMethod]
        public void PacmanCanReportThePositionAfterPlacingTurningAndMoving()
        {
            var pacman = new Pacman();
            var result = pacman.Place(1, 2, Facing.East);
            pacman.Move();
            pacman.Move();
            pacman.Left();
            pacman.Move();
            var report = pacman.Report();
            Assert.IsTrue(result);
            Assert.AreEqual("", pacman.Error);
            Assert.AreEqual("Output: 3,3,NORTH", report);

        }

    }
}
