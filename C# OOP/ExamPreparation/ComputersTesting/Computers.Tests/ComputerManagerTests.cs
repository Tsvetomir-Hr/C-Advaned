using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {

        [Test]
        public void ConstructorShouldWork()
        {
            ComputerManager computerManager = new ComputerManager();

            Assert.AreEqual(0, computerManager.Computers.Count);
        }
        [Test]
        public void ValidateAddComputer()
        {
            ComputerManager computerManager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(
                () => computerManager.AddComputer(null));

            Computer computer = new Computer("Dell", "123", 1500);
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(
               () => computerManager.AddComputer(computer));

            Assert.AreEqual(1, computerManager.Computers.Count);
        }
        [Test]
        public void ValidateRemoveComputer()
        {
            ComputerManager computerManager = new ComputerManager();



            Computer computer = new Computer("Dell", "123", 1500);
            Computer computer2 = new Computer("Dell", "543", 1500);
            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);
            var computerToRemove = computerManager.RemoveComputer("Dell", "123");
            Assert.AreEqual(1, computerManager.Computers.Count);

            Assert.AreEqual(computer, computerToRemove);
        }
        [Test]
        public void ValidateGetComputerMethod()
        {
            ComputerManager computerManager = new ComputerManager();
            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputer(null, "123"));
            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputer("Dell", null));

            Computer computer = new Computer("Dell", "123", 1500);
            Computer computer2 = new Computer("Dell", "543", 1500);
            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);

            Assert.Throws<ArgumentException>(
               () => computerManager.GetComputer("Dell","haksdkas"));

            Assert.Throws<ArgumentException>(
               () => computerManager.GetComputer("bravo", "123"));

            var gotComputer = computerManager.GetComputer("Dell","123");

            Assert.AreEqual(computer, gotComputer);
        }
       
            [Test]
        public void ValidateGetComputersByManufacturer()
        {
            ComputerManager computerManager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputersByManufacturer(null));
          
            Computer computer = new Computer("Dell", "123", 1500);
            Computer computer2 = new Computer("Dell", "543", 1500);

            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);
            ICollection<Computer> computers = computerManager.GetComputersByManufacturer("Del");
            Assert.AreEqual(0, computers.Count);

            computers = computerManager.GetComputersByManufacturer("Dell");

            Assert.AreEqual(2,computers.Count);
        }
    }
}