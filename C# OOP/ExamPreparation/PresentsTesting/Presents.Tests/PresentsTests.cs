namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void PresentConstructorShouldWork()
        {
            Present present = new Present("Toy",1.2);

            Assert.AreEqual("Toy",present.Name);
            Assert.AreEqual(1.2,present.Magic);
        }

        [Test]
        public void CreatePresentShouldWork()
        {
            Present present = new Present("Toy", 1.2);
            Bag bag = new Bag();
            bag.Create(present);
            string toReturn = $"Successfully added present {present.Name}.";
            Assert.AreEqual(toReturn, $"Successfully added present {present.Name}.");
        }
        [Test]
        public void CreatePresentShouldThrowBecauseOfNullPresent()
        {
            Present present = new Present("Toy", 1.2);
            Bag bag = new Bag();
            present = null;

            Assert.Throws<ArgumentNullException>(
                () => 
                {
                    bag.Create(present);
                });
        }
        [Test]
        public void CreatePresentShouldThrowBecausePresentAlreadyExist()
        {
            Present present = new Present("Toy", 1.2);
            Bag bag = new Bag();
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    bag.Create(present);
                });
        }
        [Test]
        public void RemovePresentShouldWork()
        {
            Present present = new Present("Toy", 1.2);
            Bag bag = new Bag();
            bag.Create(present);
            
            Assert.AreEqual(true,bag.Remove(present));
        }
        [Test]
        public void GetPresentWithLeastMagicShouldWork()
        {
            Present present = new Present("Toy", 1.2);
            Present present1 = new Present("Truck", 11);
            Present present2 = new Present("Car", 2);
            Present present3 = new Present("Motorbike", 1.5);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);

            Assert.AreEqual(present, bag.GetPresentWithLeastMagic());
        }
        [Test]
        public void GetPresentByNameShouldWork()
        {
            Present present = new Present("Toy", 1.2);
            Bag bag = new Bag();
            bag.Create(present);

            Assert.AreEqual(present, bag.GetPresent(present.Name));
        }

        [Test]
        public void GetPresentsShouldReturnAllPresentsAsCollection()
        {
            Present present = new Present("Toy", 1.2);
            Present present1 = new Present("Truck", 11);
            Present present2 = new Present("Car", 2);
            Present present3 = new Present("Motorbike", 1.5);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);

            IReadOnlyCollection<Present> presents = bag.GetPresents();
            Assert.AreEqual(presents, bag.GetPresents());
        }

    }
}
