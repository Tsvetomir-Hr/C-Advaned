namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void ConstructorShouldSetCapacity()
        {
            var robots = new RobotManager(4);

            Assert.AreEqual(4, robots.Capacity);
        }
        [Test]
        public void NegativeCapacityThrows()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-1));
        }
        [Test]
        public void EmptyRobotManagerCount()
        {
            var robots = new RobotManager(12);
            Assert.AreEqual(0, robots.Count);

            robots.Add(new Robot("name", 100));
            robots.Add(new Robot("name1", 100));
            robots.Add(new Robot("name2", 100));
            Assert.AreEqual(3, robots.Count);
        }
        [Test]
        public void AddShouldThrows_RobotWithSameName()
        {
            var robots = new RobotManager(12);

            robots.Add(new Robot("name", 100));
            Assert.Throws<InvalidOperationException>(
            () =>
            {
                robots.Add(new Robot("name", 99));
            });
        }

        [Test]
        public void AddShouldThrows_WhenManagerIsFull()
        {
            var robots = new RobotManager(1);

            robots.Add(new Robot("name", 100));
            Assert.Throws<InvalidOperationException>(
            () =>
            {
                robots.Add(new Robot("123", 99));
            });
        }
        [Test]
        public void RemoveShouldRemoveRobot()
        {
            var robots = new RobotManager(10);

            robots.Add(new Robot("name", 100));

            robots.Remove("name");
            Assert.AreEqual(0, robots.Count);

        }
        [Test]
        public void RemoveShouldNotRemoveRobotAndThrow()
        {
            var robots = new RobotManager(1);

            robots.Add(new Robot("name", 100));

            Assert.Throws<InvalidOperationException>(
            () =>
            {
                robots.Remove("Pesho");
            });
        }
        [Test]
        public void RobotShouldWork()
        {
            var robots = new RobotManager(1);

            var robot1 = new Robot("name", 25);
            robots.Add(robot1);

            robots.Work(robot1.Name,"bachkane",15);

            Assert.AreEqual(10,robot1.Battery);
        }
        [Test]
        public void RobotShouldNotWorkBecauseOfNullRobot()
        {
            var robots = new RobotManager(1);

            var robot1 = new Robot("name", 25);

            robots.Add(robot1);

            Assert.Throws<InvalidOperationException>(
            () =>
            {
                robots.Work("Pesho","Bach",12);
            });
        }
        [Test]
        public void RobotShouldNotWorkBecauseOfLowBattery()
        {
            var robots = new RobotManager(1);

            var robot1 = new Robot("name", 11);

            robots.Add(robot1);

            Assert.Throws<InvalidOperationException>(
            () =>
            {
                robots.Work("name", "Bach", 12);
            });
        }
        [Test]
        public void RobotShouldNotRechargeBatteryBeacauseOfNonExistant()
        {
            var robots = new RobotManager(1);

            var robot1 = new Robot("name", 11);

            robots.Add(robot1);

            Assert.Throws<InvalidOperationException>(
            () =>
            {
                robots.Charge("Stancho");
            });
        }
        [Test]
        public void RobotShouldRechargeBattery()
        {
            var robots = new RobotManager(1);

            var robot1 = new Robot("name", 25);

            robots.Add(robot1);

            robots.Work(robot1.Name,"qko",10);

             robots.Charge("name");
            Assert.AreEqual(robot1.MaximumBattery, robot1.Battery);
        }
    }
}
